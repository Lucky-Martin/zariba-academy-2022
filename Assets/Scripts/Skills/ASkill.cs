using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ASkill : MonoBehaviour
{

    protected int currentLevel = 0;

    public abstract string getSkillName();
    public abstract SkillType getSkillType();
    public abstract int getLevelUpSkillCost();

    public abstract string getToolTip();
    public abstract string getIconImage();
    public abstract int getMaximumSkillLevel();
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
