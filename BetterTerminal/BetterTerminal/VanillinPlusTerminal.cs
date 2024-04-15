using System;
using System.Collections.Generic;
using Computerdores.AdvancedTerminalAPI;
using Computerdores.AdvancedTerminalAPI.Vanillin;
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
        if (_history.Count > 1 && _history[1] != text)
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
        //driver.Input = "AutoComplete Placeholder";
    }
    
}