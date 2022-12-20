using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkills : MonoBehaviour
{
    // Start is called before the first frame update
    
    protected SkillsContainer playerSkills;
    public GameEvent openSkillMenu;
    private GameObject playerGameObject;
    void Start()
    {
        
        playerSkills = new SkillsContainer();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.P))
        {
            openSkillMenu?.Raise(this, null);
        }
        
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            if(playerSkills.IsSkillUnlocked(SkillType.Fireball)) {
                playerSkills.GetSkill(SkillType.Fireball).castSkill(transform.gameObject);
            } else {
                Debug.Log("Fireball Skill not unlocked");
            }
        }

        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            if(playerSkills.IsSkillUnlocked(SkillType.Blink)) {
                playerSkills.GetSkill(SkillType.Blink).castSkill(transform.gameObject);
            } else {
                Debug.Log("Blink Skill not unlocked");
            }
        }
        
        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            if(playerSkills.IsSkillUnlocked(SkillType.Thunderclap)) {
                playerSkills.GetSkill(SkillType.Thunderclap).castSkill(transform.gameObject);
            } else {
                Debug.Log("Thunderclap Skill not unlocked");
            }
        }
    }

    
    public void HandleSkillLevelUp(Component sender, object data)
    {
        if(data is ASkill) {
            Debug.Log("A skill has been leveled up");

            ASkill skill = (ASkill) data;
            SkillType skillType = skill.getSkillType();

            if(playerSkills.IsSkillUnlocked(skillType)) {
                // Level it up
            } else {
                // Unlock it
                playerSkills.UnlockSkill(skillType, skill);
            }
        }
    }
}
