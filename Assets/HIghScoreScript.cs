using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HIghScoreScript : MonoBehaviour
{
    public Button MyButton;

    // Start is called before the first frame update
    void Start()
    {
        MyButton = GetComponent<Button>();

        GameObject sceneValuesObject = GameObject.Find("SceneValues");
        SceneValues sceneValues = sceneValuesObject.GetComponent<SceneValues>();
        if(sceneValues != null) {
            Debug.Log(sceneValues.HasGameFinished);
            if(sceneValues.HasGameFinished) {
                MyButton.interactable = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
