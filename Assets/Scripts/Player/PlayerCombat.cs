using System;
using System.Collections;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] public int range;
    [SerializeField] public float damage;

    private bool attacking;
    private Animator animator;
    private WaveSpawner waveSpawner;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        waveSpawner = FindObjectOfType<WaveSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !attacking)
        {
            StartCoroutine(Hit());
        }
    }

    public bool GetAttackingState()
    {
        return attacking;
    }

    IEnumerator Hit()
    {

        attacking = true;
        animator.SetTrigger("Attack");

        yield return new WaitForSeconds(0.7f);

        Collider[] collidedObjects = Physics.OverlapSphere(transform.position, range);
        foreach (Collider collidedObject in collidedObjects)
        {
            if (collidedObject.CompareTag("Enemy"))
            {
                EnemyHealth enemyHealth = collidedObject.gameObject.GetComponent<EnemyHealth>();
                enemyHealth.TakeDamage(damage);
                // if (enemyHealth.Health < 0)
                // {
                //     Destroy(collidedObject.gameObject);
                //     waveSpawner.CheckWaveEnded();
                // }
            }
        }

        yield return new WaitForSeconds(0.3f);

        attacking = false;
    }
}
