using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIHoverRecoursesToPic : UIHover
{
    public GameObject pictureToOpen;
    public GameObject pictureToClose1;
    public GameObject pictureToClose2;

    public void Start()
    {
        // making sure it starts disabled
        if (pictureToOpen != null)
        {
            pictureToOpen.SetActive(false);
        }
    }

    //Detect if the Cursor starts to pass over the GameObject
    public override void OnPointerEnter(PointerEventData pointerEventData)
    {
        //Output to console the GameObject's name and the following message
        Debug.Log("Cursor Entering " + name + " GameObject");

        if (pictureToClose1 != null)
        {
            pictureToClose1.SetActive(false);   
        }

        if (pictureToClose2 != null)
        {
            pictureToClose2.SetActive(false);
        }

        //probably on hover of a panel I should close the other panels and open this one somehow
        if (pictureToOpen != null)
        {
            pictureToOpen.SetActive(true);
        }
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