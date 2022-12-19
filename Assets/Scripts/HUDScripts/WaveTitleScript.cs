using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveTitleScript : MonoBehaviour
{
    
    [SerializeField] [Range(5, 100)]
    public float TimeOnScreen = 20f;
    private Animator animator;

    public void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void HideTitleScreen() {
        animator.SetBool("StartFadeIn", false);
        animator.SetBool("StartFadeOut", true);
    }

    public void HandleEvent(Component sender, object data)
    {
        Debug.Log(data);
        if(data is float) {
            animator.SetBool("StartFadeOut", false);
            animator.SetBool("StartFadeIn", true);
            Invoke("HideTitleScreen", TimeOnScreen);
        }
    }
}
