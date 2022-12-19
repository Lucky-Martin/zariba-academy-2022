using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveTitleScript : MonoBehaviour
{
    
    [SerializeField] [Range(1, 100)]
    public float TimeOnScreen = 20f;
    [SerializeField]
    public string WaveClearString = "Wave {0} Cleared!";

    private Animator animator;
    protected TextMeshProUGUI TextMeshValue;

    public void Start()
    {
        animator = GetComponent<Animator>();
        TextMeshValue = transform.Find("TitleText").gameObject.GetComponent<TextMeshProUGUI>();
    }

    public void HideTitleScreen() {
        animator.SetBool("StartFadeIn", false);
        animator.SetBool("StartFadeOut", true);
    }

    public void SetWaveText(float value)
    {
        TextMeshValue.text = string.Format(WaveClearString, value);
    }

    public void HandleEvent(Component sender, object data)
    {
        Debug.Log(data);
        if(data is float) {
            animator.SetBool("StartFadeOut", false);
            animator.SetBool("StartFadeIn", true);
            Invoke("HideTitleScreen", TimeOnScreen);
            SetWaveText((float) data);
        }
    }
}
