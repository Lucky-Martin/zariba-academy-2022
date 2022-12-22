using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    public float finalScore = 0;
    public float wave = 0;
    public float waveMultiplier = 100;
    public float experience = 0;
    public float experienceMultipler = 100;

    public string title = "YOU HAVE DIED";
    public string waveText = "Wave: {0} x {1}";

    public string experienceText = "Experience: {0} x {1}";
    public string finalScoreText = "Final Score: {0}";

    protected TextMeshProUGUI TitleMesh;
    protected TextMeshProUGUI WaveMesh;
    protected TextMeshProUGUI ExperienceMesh;
    protected TextMeshProUGUI ScoreMesh;
    
    private Animator animator;
    private bool open;

    public void Start()
    {
        animator = GetComponent<Animator>();
        TitleMesh = transform.Find("Title").gameObject.GetComponent<TextMeshProUGUI>();
        WaveMesh = transform.Find("WaveText").gameObject.GetComponent<TextMeshProUGUI>();
        ExperienceMesh = transform.Find("ExperienceText").gameObject.GetComponent<TextMeshProUGUI>();
        ScoreMesh = transform.Find("FinalScore").gameObject.GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        if (open && Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    public float CalculateExperience()
    {
        return finalScore + (experience * experienceMultipler) + (wave * waveMultiplier);
    }


    public void HandleScoreChange(Component sender, object data)
    {   
        if(data is float) {
            finalScore += (float) data;
        }
    }


    public void HandleWaveChange(Component sender, object data)
    {
        if(data is float) {
            wave += (float) data;
        }
    }

    public void HandleExperienceChange(Component sender, object data)
    {
        if(data is float) {
            experience += (float) data;
        }
    }

    public void HandleDeathEvent(Component sender, object data)
    {
        if(data is bool)
        {
            open = true;
            animator.SetBool("Open", true);
            TitleMesh.text = string.Format(title); 
            WaveMesh.text = string.Format(waveText, wave, waveMultiplier); 
            ExperienceMesh.text = string.Format(experienceText, experience, experienceMultipler); 
            ScoreMesh.text = string.Format(finalScoreText, CalculateExperience()); 
        }
    }
}
