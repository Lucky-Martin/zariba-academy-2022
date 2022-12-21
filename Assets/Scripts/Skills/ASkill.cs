using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ASkill : MonoBehaviour
{

    protected int currentLevel = 0;

    public List<SkillType> prerequisiteSkills = new List<SkillType>();

    public abstract string getSkillName();
    public abstract SkillType getSkillType();
    public abstract int getLevelUpSkillCost();

    public abstract string getToolTip();
    public abstract int getMaximumSkillLevel();

    public void addPrerequisiteSkill(SkillType skill) {
        if(!prerequisiteSkills.Contains(skill)) {
            prerequisiteSkills.Add(skill);
        }
    }

    public void fulfillPrerequisiteSkill(SkillType skill) {
        if(prerequisiteSkills.Contains(skill)) {
            prerequisiteSkills.Remove(skill);
        }
    }

    public bool requiresSkill(SkillType skill) {
        return prerequisiteSkills.Contains(skill);
    }

    public List<SkillType> getRequisiteSkills() {
        return prerequisiteSkills;
    }

    public int getCurrentSkillLevel()
    {
        return currentLevel;
    }

    public int setSkillLevel(int newSkillLevel)
    {
        return currentLevel = newSkillLevel;
    }

    public virtual void castSkill(GameObject gameObject)
    {
        Debug.Log("Casting" + getSkillName() + "by" + gameObject.name);
    }
}
