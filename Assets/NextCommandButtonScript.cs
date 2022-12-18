using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextCommandButtonScript : MonoBehaviour
{
    private LineRenderer LineRenderer;
    protected Animator AnimatorController;
    protected bool StartDrag = false;
    protected Vector3 mousePosition;

    public void Start()
    {
        AnimatorController = GetComponent<Animator>();
        LineRenderer = GetComponent<LineRenderer>();
        
    }

    public void OnMouseOver()
    {
        Debug.Log("Enter");
        AnimatorController.SetBool("IsHovered", true);
    }

    public void OnMouseExit()
    {
        Debug.Log("Exit");
        AnimatorController.SetBool("IsHovered", false);
    }

    public void OnMouseCLick()
    {
        Debug.Log("Click");
        //Initial position
        LineRenderer.SetPosition(0, new Vector3(0f, 0f, 0f));
        LineRenderer.positionCount = 2;
        LineRenderer.SetPosition(1, new Vector3(0f, -100f, 0f));
        StartDrag = true;
    }

    public void OnMouseMove()
    {
        if(!StartDrag) {
            return;
        }

        Debug.Log("Mouse Move");
        mousePosition = Input.mousePosition;
        Debug.Log(Input.mousePosition);
        LineRenderer.SetPosition(1, new Vector3(mousePosition.x, mousePosition.y, 0f));
    }

    // public void o
}
