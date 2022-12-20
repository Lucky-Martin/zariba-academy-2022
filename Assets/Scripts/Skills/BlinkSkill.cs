using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkSkill : ASkill
{
    public static int MAXIMUM_LEVEL = 2;
    public override string getSkillName() {
        return "Blink";
    }

    public override SkillType getSkillType()
    {
        return SkillType.Blink;
    }

    public override int getLevelUpSkillCost() {
        return currentLevel * 10;
    }
    
    public override int getMaximumSkillLevel()
    {
        return MAXIMUM_LEVEL;
    }

    public override string getToolTip() {
        return "Moves a short distance";
    }

    public override string getIconImage() {
        return "Foo";
    }
}
