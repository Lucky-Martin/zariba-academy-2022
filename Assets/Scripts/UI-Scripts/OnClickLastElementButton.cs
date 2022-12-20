using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OnClickLastElementButton : MonoBehaviour
{

    public GameObject Button;

    public void AddInfoOnClick()
    {

        if (transform.Find("Text (TMP)") != null)
        {
            string textSelected = transform.Find("Text (TMP)").gameObject.GetComponent<TMP_Text>().text;
            Debug.Log("Selected Direction Is " + textSelected);
            switch (textSelected)
            {
                case "North":
                case "South":
                case "West":
                case "East":
                    transform.root.gameObject.GetComponent<CommandableUnit>().SetDirection(textSelected);
                    break;
                // more cases here incase we add other things as buttons for final parameter selection
                // like if the zombie type you want to fight is the last thing we want to be able to select 
                // for the fight command
            }
        }
    }
}
