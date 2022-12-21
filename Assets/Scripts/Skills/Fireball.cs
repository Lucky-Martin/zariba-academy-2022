using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : ASkill
{
    public List<GameObject> vfx = new List<GameObject>();
    public GameObject afterExplosionEffect;
    public Vector3 explosionScaleChange = new Vector3(0.2f, 0.2f, 0.2f);

    [Range(1,100)]
    public float BaseFireRate = 20f;
    private float lastCalledTime = 0f;
    private GameObject effectsToSpawn;

    public static int MAXIMUM_LEVEL = 5;


    public void Start() {
        effectsToSpawn = vfx[0];
    }

    public override string getSkillName() {
        return "Fireball";
    }

    public override SkillType getSkillType()
    {
        return SkillType.Fireball;
    }

    public override int getLevelUpSkillCost() {
        return (currentLevel + 1) * 10;
    }
    
    public override int getMaximumSkillLevel()
    {
        return MAXIMUM_LEVEL;
    }

    public override string getToolTip() {
        return "Fires a fireball at where the caster is pointing";
    }

    protected float getFireRate()
    {
        return BaseFireRate * (currentLevel);
    }
    public override void castSkill(GameObject caster)
    {
        if(Time.time < lastCalledTime) {
            Debug.Log("Still on cooldown");
        }

        lastCalledTime = Time.time + 1 / getFireRate();

        // Caster game object
        base.castSkill(caster);

        GameObject projectile;

        Debug.Log(caster.transform.rotation);
        Debug.Log(caster.transform.position + (caster.transform.forward * 1.25f));

        projectile = Instantiate(
            effectsToSpawn, 
            (
                caster.transform.position + //From caster
                (caster.transform.forward * 1.25f) + //Infront of caster
                (caster.transform.up * 0.50f) //Just above model, so that it doesn't collid with plane
            ), 
            caster.transform.rotation);

        ProjectileSpeed speedScript = projectile.GetComponent<ProjectileSpeed>();
        speedScript.AddCollisionHandler(handleCollision);
    }

    protected void handleCollision(GameObject gameObject, Collision collision) {

        GameObject explosion = Instantiate(
            afterExplosionEffect,
            gameObject.transform.position,
            gameObject.transform.rotation
        );

        explosion.transform.localScale += currentLevel * explosionScaleChange;
        Debug.Log(explosion.transform.localScale);
        // Debug.Log("AAAAAAAAAAAAAAAAAAAAAAAAAA");
    }
}
