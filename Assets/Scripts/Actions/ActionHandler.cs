using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionHandler
{
    public IAction ActionToHandle { get; set; }

    public void ExecuteCommand()
    {
        ActionToHandle.Execute();
    }

    public void ShowInfoCommand()
    {
        ActionToHandle.ShowActionInfo();
    }
}
