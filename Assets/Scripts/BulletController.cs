using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public Transform tr;
    float speed;
    public SpriteRenderer sr_s;

    void Start()
    {
        ColorController.instance.AddSprite(sr_s);
        speed = 10f;
    }

    void Update()
    {
        tr.Translate(Vector2.up * speed * Time.deltaTime);

        if(tr.position.x > 6f || tr.position.x < -6f || tr.position.y > 6f || tr.position.y < -6f)
        {
            Destroy(gameObject);
        }
    }
}
