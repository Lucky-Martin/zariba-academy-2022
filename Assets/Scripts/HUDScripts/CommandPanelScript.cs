using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandPanelScript : MonoBehaviour
{
    protected Animator AnimatorController;
    protected CommandableUnit unit;

    // Start is called before the first frame update
    void Start()
    {
        AnimatorController = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CloseButton()
    {
        Debug.Log("Close");
        AnimatorController.SetBool("IsOpen", false);
    }

    public void SaveButton()
    {
        Debug.Log("Save");
        AnimatorController.SetBool("IsOpen", false);
    }

    public void OpenPanel()
    {
        AnimatorController.SetBool("IsOpen", true);
    }

    public void ClosePanel()
    {
        AnimatorController.SetBool("IsOpen", false);
    }
}
