using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class UIHoverCommands : UIHover
{
    public GameObject resourcePanel;
    public GameObject textToChangeTo;
    // to keep evetything else in text is needed cause if you choose a recourse as well afterwards
    // then the text is changed to the other thing so you need to keep that here too, so if after that they change commands
    // we can close that text
    public GameObject textToClose1;
    public GameObject textToClose2;

    // not going to disable the other ones, i think its better if the command handles both the close and opening of it's components
    // oof but the closure is annoying cause if it handles the closuse then it will close the second when the mouse is not hovering
    // which is not what i want.

    // Rather I want the text to return when you hover something else
    // And at the end when you save is where you should return to the first text
    public void Start()
    {
        // making sure it starts disabled
        if (resourcePanel != null)
        {
            resourcePanel.SetActive(false);
        }
    }

    //Detect if the Cursor starts to pass over the GameObject
    public override void OnPointerEnter(PointerEventData pointerEventData)
    {
        //Output to console the GameObject's name and the following message
        Debug.Log("Cursor Entering " + name + " GameObject");


        //probably on hover of a panel I should close the other panels and open this one somehow
        if (resourcePanel != null)
        {
            resourcePanel.SetActive(true);
        }

        textToChangeTo.SetActive(true);
        textToClose1.SetActive(false);
        textToClose2.SetActive(false);



    }

    //Detect when Cursor leaves the GameObject
    public override void OnPointerExit(PointerEventData pointerEventData)
    {
        //Output the following message with the GameObject's name
        Debug.Log("Cursor Exiting " + name + " GameObject");

        //if don't really want to close the panel when the cursor goes of it
        //if (resourcePanel != null)
        //{
        //    resourcePanel.SetActive(false);
        //}
    }
}
