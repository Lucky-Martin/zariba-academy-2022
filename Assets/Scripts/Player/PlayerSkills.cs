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
            castIfAble(SkillType.Fireball);
        }

        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            castIfAble(SkillType.Thunderclap);
        }

        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            castIfAble(SkillType.Blink);
        }

        if(Input.GetKeyDown(KeyCode.Alpha4)) {
            castIfAble(SkillType.RaiseDead);
        }
    }


    public void castIfAble(SkillType skillType) {
        if(playerSkills.IsSkillUnlocked(skillType)) {
            playerSkills.GetSkill(skillType).castSkill(transform.gameObject);
        } else {
            Debug.Log("Skill not unlocked");
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
