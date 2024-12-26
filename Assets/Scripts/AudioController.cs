using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController instance;
    public AudioSource AS;
    public AudioClip song1;
    public AudioClip song2;
    bool started;
    bool firstSong;
    public AudioSource AS2;
    public AudioClip enemyHit;

    void Start()
    {
        instance = this;
    }

    void Update()
    {
        if(started && !AS.isPlaying)
        {
            if (firstSong)
            {
                AS.clip = song2;
                AS.Play();
            }
            else
            {
                AS.clip = song1;
                AS.Play();
            }

            firstSong = !firstSong;
        }
    }

    public void StartMusic()
    {
        started = true;
        firstSong = true;
        AS.clip = song1;
        AS.Play();
    }

    public void PlayEnemyHit()
    {
        AS2.pitch = Random.Range(0.9f, 1.1f);
        AS2.PlayOneShot(enemyHit);
    }
}
