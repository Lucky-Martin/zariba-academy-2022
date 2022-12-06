using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DraggableButtonScript : MonoBehaviour
// , IPointerClickHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public void PrintToConsole()
    {
        Debug.Log("Hello!");
        // GameObject canvas = GameObject.FindGameObjectWithTag("Canvas");
        // Transform disabledButton = canvas.transform.Find("DisabledButton");

        // Button buttonToDisable = disabledButton.gameObject.GetComponent<Button>();

        // buttonToDisable.interactable = !buttonToDisable.interactable;
        SceneManager.LoadScene("Martin Scene");
    }
    // public void OnPointerClick(PointerEventData pointerEventData)
    // {
    //     Debug.Log(name + " Game Object Clicked!");
    // }

    // public void OnBeginDrag(PointerEventData eventData)
    // {

    // }

    // public void OnDrag(PointerEventData data)
    // {

    // }

    // public void OnEndDrag(PointerEventData eventData)
    // {

    // }
}
