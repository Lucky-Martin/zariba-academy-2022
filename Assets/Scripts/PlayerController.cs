using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject command;

    // Start is called before the first frame update
    void Start()
    {
        command.GetComponent<Command>().Execute(this.gameObject);
    }
}
