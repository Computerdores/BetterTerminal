using Computerdores.AdvancedTerminalAPI;
using Computerdores.AdvancedTerminalAPI.Vanillin;
using UnityEngine.InputSystem;

namespace Computerdores.BetterTerminal; 

public class VanillinPlusTerminal : VanillinTerminal {
    private InputFieldDriver _driver;
    
    public VanillinPlusTerminal(InputFieldDriver driver) : base(driver) {
        _driver = driver;
        Plugin.InputHandler.PrevCommand.performed += PrevCommand;
        Plugin.InputHandler.NextCommand.performed += PrevCommand;
        Plugin.InputHandler.AutoComplete.performed += PrevCommand;
    }

    private void PrevCommand(InputAction.CallbackContext context) {
        _driver.Input = "Hi!";
    }

    private void NextCommand(InputAction.CallbackContext context) {
        
    }

    private void AutoComplete(InputAction.CallbackContext context) {
        
    }
    
}