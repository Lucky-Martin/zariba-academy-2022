using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] public int speed;
    [SerializeField] public int rotationSpeed;
    [SerializeField] public float attackRange;
    [SerializeField] public int damage;

    [SerializeField] [Range(10,20)] public float experiencePoints = 10;
    [SerializeField] [Range(50,100)]public float scorePoints = 50;
    [SerializeField] [Range(1,10)] public float deathTimer = 10;

    public GameEvent awardSkillPoints;
    public GameEvent awardExperience;
    
    private Animator animator;
    private Vector3 targetPosition;
    private GameObject player;
    private EnemyStates state;
    
    void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public virtual void Update()
    {
        RunToPlayer();
    }

    private void SetAnimationState(AnimationStates state, bool value)
    {
        switch(state) {
            case AnimationStates.Walk:
                animator.SetBool("Walking", value);
                break;
            case AnimationStates.Search:
                animator.SetBool("Searching", value);
                break;
            case AnimationStates.Run:
                animator.SetBool("Running", value);
                break;
            case AnimationStates.Attack:
                animator.SetTrigger("Attack");
                break;
            case AnimationStates.Death:
                animator.SetBool("Dead", value);
            break;
        }
    }

    private void RunToPlayer()
    {
        if (state == EnemyStates.Idle)
        {
            SetAnimationState(AnimationStates.Run, true);
            state = EnemyStates.Running;
        }
        else if (state == EnemyStates.Attacking)
            return;
        
        targetPosition = player.transform.position;

        if (Vector3.Distance(transform.position, targetPosition) < attackRange)
        {
            // Attack player
            state = EnemyStates.Attacking;
            StartCoroutine(Attack());
        }
        else
        {
            if (state == EnemyStates.Attacking)
                return;
            
            // Run to player
            state = EnemyStates.Running;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            Vector3 direction = targetPosition - transform.position;
            Quaternion rotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
        }
    }

    private IEnumerator Attack()
    {
        // Update animation states
        SetAnimationState(AnimationStates.Run, false);
        SetAnimationState(AnimationStates.Attack, true);
        
        yield return new WaitForSeconds(0.7f);

        Collider[] collidedObjects = Physics.OverlapSphere(transform.position, attackRange);
        foreach (Collider collidedObject in collidedObjects)
        {
            if (collidedObject.CompareTag("Player"))
            {
                PlayerHealth playerHealth = collidedObject.gameObject.GetComponent<PlayerHealth>();
                playerHealth.TakeDamage(damage);
            }
        }

        yield return new WaitForSeconds(0.3f);
        state = EnemyStates.Idle;
    }

    public void HandleDeathEvent(Component sender, object data)
    {
        if(data is GameObject && (GameObject) data == gameObject)
        {
            Debug.Log("Score");
            Debug.Log(scorePoints);
            awardSkillPoints?.Raise(this, scorePoints);
            awardExperience?.Raise(this, experiencePoints);
            SetAnimationState(AnimationStates.Death, true);
            Destroy(this, deathTimer);

        }
    }
}
