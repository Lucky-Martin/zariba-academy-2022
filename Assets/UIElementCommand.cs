using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIElementCommand : CommandElementScript
{
    public bool IsClicked = false;

    public void clickNextCommand()
    {
        IsClicked = !IsClicked;
        triggerParentCommandClick();
    }
}
