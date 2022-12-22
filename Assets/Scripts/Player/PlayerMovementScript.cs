using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PlayerMovementScript : MonoBehaviour
{
    [SerializeField] public float speed;
    [SerializeField] public float rotationSpeed;
    private Animator animator;
    private Rigidbody body;
    private PlayerCombat playerCombat;
    private GameObject playerGameObject;

    public float wave = 0f;

    [Header("Events")]
    public GameEvent onScoreChange;
    public GameEvent waveCleared;
    public GameEvent addExperience;

    public bool isPlayerDead = false;


    // debuging purposes

    void Start()
    {
        
        body = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        playerCombat = GetComponent<PlayerCombat>();
        playerGameObject = GetComponent<GameObject>();

    }

    // Update is called once per frame
    void Update()
    {
        if(isPlayerDead) {
            return;
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            onScoreChange?.Raise(this, 10000f);
        }

        if(Input.GetKeyDown(KeyCode.K))
        {
            waveCleared?.Raise(this, ++wave);
        }

        if(Input.GetKeyDown(KeyCode.L))
        {
            addExperience?.Raise(this, 10000f);
        }


        if (playerCombat.GetAttackingState())
        {
            animator.SetBool("Walking", false);
            return;
        }


        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        movementDirection.Normalize();

        transform.Translate(movementDirection * speed * Time.deltaTime, Space.World);


        RaycastHit hit;
 
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
 
        if(Physics.Raycast(ray, out hit))
        {
            transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z));
        }


        if (movementDirection != Vector3.zero)
        {
            if (!animator.GetBool("Walking"))
            {
                animator.SetBool("Walking", true);
            }
        }
        else
        {
            animator.SetBool("Walking", false);
        }
    }

    public void HandlePlayerDeath(Component sender, object data)
    {
        if(data is bool) {
            isPlayerDead = (bool) data;
            animator.SetBool("Dead", true);
        }
    }

}
