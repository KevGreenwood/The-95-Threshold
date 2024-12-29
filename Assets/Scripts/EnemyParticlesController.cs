using UnityEngine;

public class EnemyParticlesController : MonoBehaviour
{
    float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 1)
        {
            Destroy(gameObject);
        }
    }
}
