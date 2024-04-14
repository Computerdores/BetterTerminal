using LethalCompanyInputUtils.Api;
using LethalCompanyInputUtils.BindingPathEnums;
using UnityEngine.InputSystem;

namespace Computerdores.BetterTerminal; 

public class InputHandler : LcInputActions {
    [InputAction(KeyboardControl.UpArrow, Name = "Previous Command")]
    public InputAction PrevCommand { get; set; }
    
    [InputAction(KeyboardControl.DownArrow, Name = "Next Command")]
    public InputAction NextCommand { get; set; }
    
    [InputAction(KeyboardControl.LeftAlt, Name = "Auto Complete")]
    public InputAction AutoComplete { get; set; }
}