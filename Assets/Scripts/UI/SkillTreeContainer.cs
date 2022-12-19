using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTreeContainer : MonoBehaviour
{
    private Animator animator;
    private bool isOpened = false;

    public void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void HandleEvent(Component sender, object data)
    {
        isOpened = !isOpened;
        animator.SetBool("Open", isOpened);
    }
}
