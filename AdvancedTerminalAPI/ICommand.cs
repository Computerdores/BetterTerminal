﻿namespace Computerdores; 

public interface ICommand {
    public string GetName();

    public string PredictArguments(string partialArgumentsText);

    public (string output, bool clearScreen) Execute(string finalArgumentsText);
}