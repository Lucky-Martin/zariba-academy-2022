using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillsContainer 
{
    private Dictionary<SkillType, ASkill> unlockedSkills;

    public SkillsContainer() {
        unlockedSkills = new Dictionary<SkillType, ASkill>();
    }

    public void UnlockSkill(SkillType skillName, ASkill skill) {
        if(!unlockedSkills.ContainsKey(skillName)) {
            unlockedSkills.Add(skillName, skill);
        }
    }

    public bool IsSkillUnlocked(SkillType skillName) {
        return unlockedSkills.ContainsKey(skillName);
    }

    public ASkill? GetSkill(SkillType skillName)
    {
        if(unlockedSkills.ContainsKey(skillName)) {
            return unlockedSkills[skillName];
        }
        return null;
    }

}
