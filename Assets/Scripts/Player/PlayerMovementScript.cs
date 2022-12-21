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
        if (Input.GetKeyDown("space"))
        {
            print("space key was pressed");
            onScoreChange?.Raise(this, 50f);
        }

        if(Input.GetKeyDown(KeyCode.Q))
        {
            print("Q key was pressed");
            waveCleared?.Raise(this, ++wave);
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            addExperience?.Raise(this, 20f);
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

}
