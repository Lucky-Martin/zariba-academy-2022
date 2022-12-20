using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SkillIconScript : MonoBehaviour
{

    [SerializeField] protected ASkill skill;
    public GameEvent levelUpSkill;

    protected GameObject ToolTip;

    protected bool isLocked = false;
    protected bool isClickable = true;


    public void Start() {
        ToolTip = transform.Find("ToolTip").gameObject;

        if(!skill) {
            Debug.LogWarning("No Skill Selected");
            return;
        }

        UpdateText();
    }

    public void UpdateText()
    {
        ToolTip.transform.Find("SkillTitle").GetComponent<TextMeshProUGUI>().text = skill.getSkillName();
        ToolTip.transform.Find("SkillDescription").GetComponent<TextMeshProUGUI>().text = skill.getToolTip();
        ToolTip.transform.Find("SkillCost").GetComponent<TextMeshProUGUI>().text = string.Format("Cost {0}", skill.getLevelUpSkillCost());
        ToolTip.transform.Find("SkillLevel").GetComponent<TextMeshProUGUI>().text = string.Format("{0}/{1}", skill.getCurrentSkillLevel(), skill.getMaximumSkillLevel());
    }

    public void HandleHoverIn() {
        ToolTip.GetComponent<Animator>().SetBool("Open", true);
    }

    public void HandleHoverOut() {
        ToolTip.GetComponent<Animator>().SetBool("Open", false);
    }

    public void HandleClick() {
        if(isLocked) {
            return;
        }

        //Do you have enough experience
        

        levelUpSkill?.Raise(this, skill);
    }

    // public void ExperienceChange()

    public void LevelUpSkill(Component sender, object data)
    {
        if(data is ASkill) {
            ASkill leveledUpSkill = (ASkill) data;
            Debug.Log(skill == leveledUpSkill);
            if(skill == leveledUpSkill) {
                skill.setSkillLevel(skill.getCurrentSkillLevel() + 1);
                UpdateText();
            } else {

            }
            // Check if skill is one of the prerequisites;
            // If all the prerequisites have been finished, remove disable overlay
        }
    }
}
