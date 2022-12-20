using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderclapSkill : ASkill
{
    public static int MAXIMUM_LEVEL = 2;
    public override string getSkillName() {
        return "Thunderclap";
    }

    public override SkillType getSkillType()
    {
        return SkillType.Thunderclap;
    }

    public override int getLevelUpSkillCost() {
        return currentLevel * 10;
    }
    
    public override int getMaximumSkillLevel()
    {
        return MAXIMUM_LEVEL;
    }

    public override string getToolTip() {
        return "Strikes the earth around with Lightning";
    }

    public override string getIconImage() {
        return "Foo";
    }
}
