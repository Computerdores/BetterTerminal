using System;
using System.Collections.Generic;
using System.Linq;
using Computerdores.AdvancedTerminalAPI;
using Computerdores.AdvancedTerminalAPI.Vanillin;
using HarmonyLib;
using UnityEngine.InputSystem;

namespace Computerdores.BetterTerminal; 

public class VanillinPlusTerminal : VanillinTerminal {
    private readonly List<string> _history = new() { "" };

    private int _index;

    private int Index {
        get => _index;
        set {
            _index = Math.Clamp(value, 0, _history.Count-1);
            driver.Input = _history[_index];
        }
    }
    
    public VanillinPlusTerminal(InputFieldDriver driver) : base(driver) {
        Plugin.InputHandler.PrevCommand.performed += PrevCommand;
        Plugin.InputHandler.NextCommand.performed += NextCommand;
        Plugin.InputHandler.AutoComplete.performed += AutoComplete;
    }

    protected override void OnSubmit(string text) {
        base.OnSubmit(text);
        if (!wrapper.TerminalInUse) return;
        Index = 0;
        if (_history.Count > 1 && _history[1] == text) return;
        _history.Insert(1, text);
    }

    private void PrevCommand(InputAction.CallbackContext context) {
        if (!wrapper.TerminalInUse) return;
        Index++;
    }

    private void NextCommand(InputAction.CallbackContext context) {
        if (!wrapper.TerminalInUse) return;
        Index--;
    }

    private void AutoComplete(InputAction.CallbackContext context) {
        if (!wrapper.TerminalInUse) return;
        if (currentCommand != null) {
            if (currentCommand is IPredictable predictable) {
                driver.Input = predictable.PredictInput(driver.Input, this);
            }
        } else {
            string[] words = driver.Input.Split(' ');
            if (words.Length == 1) {
                if (FindCommand(words[0]) is { } command)
                    driver.Input = command.GetName() + " ";
            } else {
                ICommand cmd = FindCommand(words[0]);
                if (cmd is IPredictable predictable) {
                    driver.Input = $"{cmd.GetName()} {predictable.PredictInput(words.Skip(1).Join(delimiter: " "), this)}";
                }
            }
        }
    }
    
}