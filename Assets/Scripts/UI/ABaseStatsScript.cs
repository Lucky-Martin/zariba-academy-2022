using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

abstract public class ABaseStatsScript : MonoBehaviour
{
    protected float CurrentValue = 0;
    protected float FinalValue = 0;
    protected float elapsedTime = 0f;
    [SerializeField] [Range(10, 100)]
    public float speed = 50f;


    protected TextMeshProUGUI TextMeshValue;

    public void Start()
    {
        TextMeshValue = transform.Find("ValueTextMesh").gameObject.GetComponent<TextMeshProUGUI>();
    }

    public void Update()
    {
        if(FinalValue != CurrentValue) {
            CurrentValue = Mathf.MoveTowards(CurrentValue, FinalValue, speed * Time.deltaTime);
            UpdateValueText();
        }
    }

    public void triggerValueIncrease(float increase)
    {
        // elapsedTime = 0f;
        FinalValue += increase;
    }

    public void UpdateValueText()
    {
        TextMeshValue.text = Mathf.CeilToInt(CurrentValue).ToString();
    }

    public abstract void HandleEvent(Component sender, object data);
}
