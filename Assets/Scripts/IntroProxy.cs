using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IntroProxy : MonoBehaviour
{
    public TMP_Text percentage;

    public GameObject particles;

    void ReducePercentage()
    {
        string s = percentage.text;
        int n = int.Parse(s);
        n--;
        percentage.text = n + "";
    }

    void RecoverPercentage()
    {
        percentage.text = "100";
    }

    void PlayerDead()
    {
        particles.SetActive(true);
    }

    void DeactivateParticles()
    {
        particles.SetActive(false);
    }
}
