using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    float frequency = 0.9f;
    public float timer;

    public GameObject enemy;
    GameObject obj;
    int r;
    bool first = true;
    Vector2 pos;
    float radius = 5.7f;

    void Update()
    {
        if (GameController.instance.state != 2) return;

        timer += Time.deltaTime;

        if (timer > frequency)
        {
            timer = 0;
            obj = Instantiate(enemy);

            pos = Random.insideUnitCircle.normalized * radius;
            obj.transform.position = new Vector2(pos.x, pos.y);

            /*
            int r = Random.Range(1, 5);

            if (r == 1)
            {
                obj.transform.position = new Vector2(Random.Range(-6f, 6f), -6f);
            }
            else if (r == 2)
            {
                obj.transform.position = new Vector2(Random.Range(-6f, 6f), 6f);
            }
            else if (r == 3)
            {
                obj.transform.position = new Vector2(-6f, Random.Range(-6f, 6f));
            }
            else if (r == 4)
            {
                obj.transform.position = new Vector2(6f, Random.Range(-6f, 6f));
            }*/
        }
    }

    public void Restart()
    {
        timer = frequency;
        /*
        if (first)
        {
            timer = frequency;
            first = false;
            return;
        }

        timer = 0;
        obj = Instantiate(enemy);

        pos = Random.insideUnitCircle.normalized * radius;
        obj.transform.position = new Vector2(pos.x, pos.y);*/
    }
}
