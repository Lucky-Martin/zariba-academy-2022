using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneValues : MonoBehaviour
{
    public bool HasGameFinished = false;
    private static SceneValues instance = null;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(this.gameObject);
            return;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
    }
}
