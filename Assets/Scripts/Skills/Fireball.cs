using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : ASkill
{
    public static int MAXIMUM_LEVEL = 5;
    public override string getSkillName() {
        return "Fireball";
    }

    public override SkillType getSkillType()
    {
        return SkillType.Fireball;
    }

    public override int getLevelUpSkillCost() {
        return currentLevel * 10;
    }
    
    public override int getMaximumSkillLevel()
    {
        return MAXIMUM_LEVEL;
    }

    public override string getToolTip() {
        return "Fires a fireball at where the caster is pointing";
    }

    public override string getIconImage() {
        return "Foo";
    }
}
