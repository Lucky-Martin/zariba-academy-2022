using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkillIconScript : MonoBehaviour
{

    [SerializeField] protected ASkill skill;
    public GameEvent levelUpSkill;
    public GameEvent experienceChange;

    protected GameObject ToolTip;
    protected GameObject ImageOverlay;

    protected bool isLocked = false;
    protected bool isClickable = true;
    protected float userExperience = 0;


    public void Start() {
        ToolTip = transform.Find("ToolTip").gameObject;
        ImageOverlay = transform.Find("DisabledOverlay").gameObject;

        if(!skill) {
            Debug.LogWarning("No Skill Selected");
            return;
        }

        UpdateText();
        UpdateOverlay();
    }

    public void UpdateText()
    {
        ToolTip.transform.Find("SkillTitle").GetComponent<TextMeshProUGUI>().text = skill.getSkillName();
        ToolTip.transform.Find("SkillDescription").GetComponent<TextMeshProUGUI>().text = skill.getToolTip();
        ToolTip.transform.Find("SkillCost").GetComponent<TextMeshProUGUI>().text = string.Format("Cost {0}", skill.getLevelUpSkillCost());
        ToolTip.transform.Find("SkillLevel").GetComponent<TextMeshProUGUI>().text = string.Format("{0}/{1}", skill.getCurrentSkillLevel(), skill.getMaximumSkillLevel());
    }

    public void UpdateOverlay()
    {
        
        Color overlayColor = new Color(1f, 1f, 1f, 0.5f);

        if(skill.getCurrentSkillLevel() == skill.getMaximumSkillLevel()) {
            // Completed E5C424
            overlayColor = new Color(
                0.90f, 
                0.75f, 
                0.15f, 
                0.40f
            );
        } else if(!canLevelSkillUp()) {
            overlayColor = new Color(
                0.00f, 
                0.00f, 
                0.00f, 
                0.40f
            );
        }

        ImageOverlay.transform.GetComponent<Image>().color = overlayColor;
    }

    public bool canLevelSkillUp()
    {
        return skill.getLevelUpSkillCost() <= userExperience && skill.getRequisiteSkills().Count == 0;
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

        Debug.Log("Raising level up event");
        levelUpSkill?.Raise(this, skill);
    }

    // public void ExperienceChange()

    public void LevelUpSkill(Component sender, object data)
    {
        if(data is ASkill) {
            ASkill leveledUpSkill = (ASkill) data;
            Debug.Log("Skill name");
            Debug.Log(skill.getSkillName());
            if(skill == leveledUpSkill && 
                skill.getCurrentSkillLevel() < skill.getMaximumSkillLevel() &&
                canLevelSkillUp() ) {

                experienceChange?.Raise(this, (float)-skill.getLevelUpSkillCost());
                skill.setSkillLevel(skill.getCurrentSkillLevel() + 1);
                
                
                UpdateText();
                UpdateOverlay();

            } else {
                Debug.Log(skill.requiresSkill(leveledUpSkill.getSkillType()));
                if(skill.requiresSkill(leveledUpSkill.getSkillType())) {
                    skill.fulfillPrerequisiteSkill(leveledUpSkill.getSkillType());
                }
            }
            // Check if skill is one of the prerequisites;
            // If all the prerequisites have been finished, remove disable overlay
        }
    }

    public void HandleExperienceChange(Component sender, object data)
    {
        if(data is float) {
            // if(sender != this) {

            // }
            float addedExperience = (float) data;
            userExperience += addedExperience;
            UpdateOverlay();
        }
    }
}
