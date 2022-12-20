using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickClose : MonoBehaviour
{

    public GameObject closeButton;
    
    public void CloseOnClick()
    {
        if (transform.root.Find("Canvas-CommandPanel") != null)
        {
            transform.root.Find("Canvas-CommandPanel").gameObject.SetActive(false);
        }
    }
}
