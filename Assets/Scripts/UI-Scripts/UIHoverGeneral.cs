using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class UIHoverGeneral : UIHover
{
    //[SerializeField] private int numberFieldTypesToChange = 3;

    public GameObject disabledPicsPanel;
    public GameObject enabledPicsPanel;
    public GameObject picToEnable;

    public GameObject panelToEnable;
    public GameObject panelToEnable2;
    public GameObject panelToDisable;
    public GameObject panelToDisable2;

    public GameObject disabledTextPanel;
    public GameObject enabledTextPanel;
    public GameObject textToEnable;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void DisableActiveElementsAndActivateTarget(GameObject disabledPanel, GameObject enabledPanel, GameObject target)
    {
        // here comes the problem of also if they close and an enabled element is left at the disabled group
        // at save and close i should disable all elements in the disabled groups

        // put all the gameobjects from the enabled panel to the disabled and disable them
        // put the target object to the enabled panel and enable it.
        if (disabledPanel != null && enabledPanel != null)
        {
            for (int i = 0; i < enabledPanel.transform.childCount; i++)
            {
                enabledPanel.transform.GetChild(i).gameObject.SetActive(false);
                enabledPanel.transform.GetChild(i).SetParent(disabledPanel.transform);
            }

            // we could want to just clear all active objects of a type
            // by not inputting a target to enable
            if (target != null)
            {
                target.transform.SetParent(enabledPanel.transform);
                target.SetActive(true);
            }
        }
    }

    public override void OnPointerEnter(PointerEventData pointerEventData)
    {
        DisableActiveElementsAndActivateTarget(disabledPicsPanel, enabledPicsPanel, picToEnable);
        DisableActiveElementsAndActivateTarget(disabledTextPanel, enabledTextPanel, textToEnable);

        if (panelToEnable != null)
        {
            panelToEnable.SetActive(true);
        }

        if(panelToEnable2 != null)
        {
            panelToEnable2.SetActive(true);
        }

        if (panelToDisable != null)
        {
            panelToDisable.SetActive(false);
        }

        if(panelToDisable2 != null)
        {
            panelToDisable2.SetActive(false);
        }

        RelayCommandParts();
    }

    public override void OnPointerExit(PointerEventData pointerEventData)
    {

    }

    protected void RelayCommandParts()
    {
        // for now the text is always the only child but in case something changes i'll do it like this 
        // finding is probably a heavier operation but doesn't risk us changing something and having the code misfire
        // for a hard to find reason

        if (transform.Find("Text (TMP)") != null)
        {
            string textSelected = transform.Find("Text (TMP)").gameObject.GetComponent<TMP_Text>().text;
            Debug.Log("Hovered over " + textSelected + " and relaying it to construct command");
            switch (textSelected)
            {
                case "Collect":
                case "Fight Enemies":
                case "Build":
                    transform.root.gameObject.GetComponent<CommandableUnit>().SetCommandName(textSelected);
                    break;
                case "Wood":
                    transform.root.gameObject.GetComponent<CommandableUnit>().SetResourceType(ResourceTypes.Wood);
                    break;
                case "Ore":
                    transform.root.gameObject.GetComponent<CommandableUnit>().SetResourceType(ResourceTypes.Ore);
                    break;
                case "Sunflower":
                    transform.root.gameObject.GetComponent<CommandableUnit>().SetResourceType(ResourceTypes.Sunflower);
                    break;

            }
        }
    }
}
