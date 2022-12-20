using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum SkillType {
    None,
    Bolt,
    Blink,
    Thunderclap
}

public class PlayerSkills 
{
    private List<SkillType> unlockedSkillTypes;

    public PlayerSkills() {
        unlockedSkillTypes = new List<SkillType>();
    }

    public void UnlockSkill(SkillType skillType) {
        if(!unlockedSkillTypes.Contains(skillType)) {
            unlockedSkillTypes.Add(skillType);
        }
    }

    public bool IsSkillUnlocked(SkillType skillType) {
        return unlockedSkillTypes.Contains(skillType);
    }

}
