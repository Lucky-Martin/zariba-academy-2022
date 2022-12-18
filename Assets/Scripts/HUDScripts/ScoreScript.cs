using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    protected static float CurrentScore = 0;
    protected static float FinalScore = 0;
    protected static float elapsedTime = 0f;
    [SerializeField] [Range(10, 100)]
    public static float speed = 50f;


    protected TextMeshProUGUI ScoreValue;

    public void Start()
    {
        // Debug.Log(transform);
        ScoreValue = transform.Find("ScoreValue").gameObject.GetComponent<TextMeshProUGUI>();
    }

    public void Update()
    {
        if(FinalScore != CurrentScore) {
            CurrentScore = Mathf.MoveTowards(CurrentScore, FinalScore, speed * Time.deltaTime);
            UpdateScoreText(CurrentScore);
        }
    }

    public void triggerScoreIncrease(float increase)
    {
        // elapsedTime = 0f;
        FinalScore += increase;
    }

    public void UpdateScoreText(float value)
    {
        ScoreValue.text = Mathf.CeilToInt(value).ToString();
    }

    public void HandleScoreAddition(Component sender, object data)
    {
        Debug.Log("Handle");
        Debug.Log(data);
        Debug.Log(data is float);
        if(data is float) {
            triggerScoreIncrease((float) data);
        }
    }
}
