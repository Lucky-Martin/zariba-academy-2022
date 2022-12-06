using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UserInputScript : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;

    private Animator animatorController;
    private Rigidbody body;
    private SceneValues SceneValues;

    void Start()
    {
        animatorController = GetComponent<Animator>();
        body = GetComponent<Rigidbody>();
        animatorController.Play("WK_mage_01_idle_A");

        GameObject sceneValues = GameObject.Find("SceneValues");
        SceneValues = sceneValues.GetComponent<SceneValues>();
        if(SceneValues != null) {
            Debug.Log(SceneValues.HasGameFinished);
        }
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        movementDirection.Normalize();

        // transform.Translate(movementDirection * speed * Time.deltaTime);
        transform.Translate(movementDirection * speed * Time.deltaTime, Space.World);      

        if (movementDirection != Vector3.zero) {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
            animatorController.Play("WK_mage_02_walk");
        } else {
            animatorController.Play("WK_mage_01_idle_A");
        }

        if(body.position.y < -20 && SceneValues != null) {
            SceneValues.HasGameFinished = true;
            SceneManager.LoadScene("MartinMenuScene");
        }
    }
}
