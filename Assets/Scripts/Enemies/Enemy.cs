using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] public int HP;
    [SerializeField] public int speed;
    [SerializeField] public int rotationSpeed;
    [SerializeField] public int sightRange;
    [SerializeField] public float attackRange;

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
        }
    }

    private void RunToPlayer()
    {
        if (state == EnemyStates.Idle)
        {
            SetAnimationState(AnimationStates.Run, true);
            state = EnemyStates.Running;
        }
        targetPosition = player.transform.position;

        if (Vector3.Distance(transform.position, targetPosition) < attackRange)
        {
            // Attack player
            state = EnemyStates.Attacking;
            SetAnimationState(AnimationStates.Attack, true);
        }
        else 
        {
            // Run to player
            state = EnemyStates.Running;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            Vector3 direction = targetPosition - transform.position;
            Quaternion rotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
        }
    }
}
