using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CommandContentScript : MonoBehaviour
{

    public Vector3 scaleChange = new Vector3(0.25f, 0.25f, 0.25f);
    protected bool StartTrackingMouse = false;
    protected CommandElementScript ExitCommand = null;
    protected CommandElementScript NextCommand = null;
    protected Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if(StartTrackingMouse) {
            // Transform cam = Camera.main.transform;
            // Debug.Log(Input.mousePosition);
            // Debug.Log(cam.InverseTransformPoint(Input.mousePosition));
            Vector3 screenPos = cam.WorldToScreenPoint(Input.mousePosition);
            Debug.Log(screenPos);
        }
    }

    public void scaleDown()
    {
        Debug.Log("aaaaa");
        Debug.Log(scaleChange);

        transform.localScale -= scaleChange;
    }

    public void commandExitClick(CommandElementScript commandCaller)
    {
        Debug.Log("A1234");
    }

    public void pointerEnter()
    {
        Debug.Log("Pointer Enter");
        StartTrackingMouse = true;
    }

    public void pointerExit()
    {
        Debug.Log("Pointer Exit");
        // StartTrackingMouse = false;
    }
}
