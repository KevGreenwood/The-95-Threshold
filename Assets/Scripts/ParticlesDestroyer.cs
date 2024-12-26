using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesDestroyer : MonoBehaviour
{
    float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= 1)
        {
            Destroy(gameObject);
        }
    }
}
