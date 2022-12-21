using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : ASkill
{
    public List<GameObject> vfx = new List<GameObject>();
    public GameObject afterExplosionEffect;
    public Vector3 explosionScaleChange = new Vector3(0.2f, 0.2f, 0.2f);


    [Range(1,100)]
    public int maximumLevel = 5;
    [Range(1,100)]
    public int perLevelUpCost = 10;

    [Range(0,100)]
    public float perLevelCooldownReduction = 1;

    [Range(1,100)]
    public float cooldownTime = 10f;


    [Range(1,20)]
    public float afterExplosionEffectTime = 10;


    [Range(1,100)]
    public float baseMainDamage = 10;

    [Range(1,100)]
    public float perLevelMainDamageMultiplier = 10;

    [Range(1,100)]
    public float baseSideDamage = 10;
    [Range(1,100)]
    public float perLevelSideDamageMultiplier = 10;

    [Range(1,100)]
    public float baseExplosionRange = 3;

    [Range(1,100)]
    public float perLevelRangeMultiplier = 10;


    public float calculateSideDamage()
    {
        return baseSideDamage + currentLevel * perLevelSideDamageMultiplier;
    }

    public float calculateExplosionRange()
    {
        return baseExplosionRange + currentLevel * perLevelRangeMultiplier;
    }

    public float calculateMainDamage()
    {
        return baseMainDamage + currentLevel * perLevelMainDamageMultiplier;
    }



    
    private GameObject effectsToSpawn;
    private float nextAvailableTime = 0f;


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
        return maximumLevel;
    }

    public override string getToolTip() {
        return "Fires a fireball at where the caster is pointing";
    }

    
    public float getCooldownTime()
    {
        return cooldownTime - (currentLevel * perLevelCooldownReduction);
    }

    public override void castSkill(GameObject caster)
    {
        if(Time.time < nextAvailableTime) {
            return;
        }
        nextAvailableTime = Time.time + getCooldownTime();

        GameObject projectile = handleShootingEffects(caster);

        ProjectileSpeed speedScript = projectile.GetComponent<ProjectileSpeed>();
        speedScript.AddCollisionHandler(handleCollision);
    }

    protected GameObject handleShootingEffects(GameObject caster)
    {
        return Instantiate(
            effectsToSpawn, 
            (
                caster.transform.position + //From caster
                (caster.transform.forward * 1.25f) + //Infront of caster
                (caster.transform.up * 0.50f) //Just above model, so that it doesn't collid with plane
            ), 
            caster.transform.rotation);
    }

    protected GameObject handleExplossionEffects(GameObject gameObject, Collision collision)
    {
        GameObject explosion = Instantiate(
            afterExplosionEffect,
            gameObject.transform.position,
            gameObject.transform.rotation
        );

        explosion.transform.localScale += currentLevel * explosionScaleChange;

        Destroy(explosion, afterExplosionEffectTime);
        
        return explosion;
    } 

    protected void handleCollision(GameObject gameObject, Collision collision) 
    {
        float mainDamage = calculateMainDamage();

        // Aplly main damage to collided element
        EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
        if(enemyHealth) {
            applyDamage(enemyHealth, mainDamage);
        }

        //Apply side damage to other things in range;
        applyExplosionRangeDamage(gameObject.transform.position);
        handleExplossionEffects(gameObject, collision);
    }

    protected void applyExplosionRangeDamage(Vector3 explosionCenter)
    {
        Collider[] collidedObjects = Physics.OverlapSphere(
            explosionCenter, 
            calculateExplosionRange()
        );

        float sideDamage = calculateSideDamage();

        foreach (Collider collidedObject in collidedObjects)
        {
            if(collidedObject.gameObject.GetComponent<EnemyHealth>()) {
                applyDamage(collidedObject.gameObject.GetComponent<EnemyHealth>(), sideDamage);
            }
        }
    }

    protected void applyDamage(EnemyHealth enemy, float damage)
    {
        enemy.TakeDamage(damage);
    }
}
