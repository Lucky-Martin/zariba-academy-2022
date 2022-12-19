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
    private SceneValues SceneValues;
    private Rigidbody body;
    private PlayerCombat playerCombat;

    [Header("Events")]
    public GameEvent onScoreChange;
    public GameEvent waveCleared;
    public GameEvent addExperience;

    // debuging purposes
    public float wave = 0f;

    void Start()
    {
        
        body = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        playerCombat = GetComponent<PlayerCombat>();
        GameObject sceneValues = GameObject.Find("SceneValues");
        if(sceneValues != null) {
            SceneValues = sceneValues.GetComponent<SceneValues>();
            if(SceneValues != null) {
                Debug.Log(SceneValues.HasGameFinished);
            }
        }
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

        if (movementDirection != Vector3.zero)
        {
            if (!animator.GetBool("Walking"))
            {
                animator.SetBool("Walking", true);
            }

            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
        else
        {
            animator.SetBool("Walking", false);
        }

        if(body.position.y < -20 && SceneValues != null) {
            SceneValues.HasGameFinished = true;
            SceneManager.LoadScene("MartinMenuScene");
        }
    }
}
