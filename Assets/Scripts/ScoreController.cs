using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{
    public static ScoreController instance;
    public TMP_Text scoreText;
    public Animator cam;

    public int score;

    public AudioSource AS1;
    public AudioClip clip;
    public AudioClip wohoo;

    bool end;
    public AudioSource musicAS;

    void Start()
    {
        instance = this;
        ResetScore();
    }

    void Update()
    {
        if (end && musicAS.volume > 0)
        {
            musicAS.volume -= Time.deltaTime / 10f;
        }
    }

    public void RaiseScore()
    {
        score++;
        UpdateScore();

        PlayScore();

        if (score >= 11 && !end)
        {
            GameController.instance.state = 3;
            cam.SetTrigger("end");
            Invoke("Reset", 1f);
            Invoke("PlayCheer", 5f);
            end = true;
        }
    }

    public void ResetScore()
    {
        score = 0;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = score + "";
    }

    void PlayScore()
    {
        AS1.pitch = 1 + score/20f;
        AS1.PlayOneShot(clip);
    }

    void PlayCheer()
    {
        AS1.pitch = 1;
        AS1.PlayOneShot(wohoo);
    }

    void Reset()
    {
        GameController.instance.ResetGame();
    }
}
