using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickSave : MonoBehaviour
{
    public GameObject SaveButton;

    public void SaveOnClick()
    {
        //idk if i should do these checks at all honestly
        if (transform.root.Find("Canvas-CommandPanel") != null)
        {
            //and therefore if i should check here also?
            Debug.Log("Command Saved!");
            transform.root.gameObject.GetComponent<CommandableUnit>().ConstructCommand();
            transform.root.Find("Canvas-CommandPanel").gameObject.SetActive(false);
        }
    }
}
