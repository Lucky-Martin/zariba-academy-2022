using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandElementScript : MonoBehaviour
{
    public void triggerParentCommandClick()
    {
        CommandContentScript parent = transform.parent.GetComponent<CommandContentScript>();
        parent.commandExitClick(this);
    }
}
