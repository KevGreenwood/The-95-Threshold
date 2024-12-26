using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject particles;
    Transform playerTR;
    Transform stageTR;
    public Transform tr;
    public Rigidbody2D rb;
    public SpriteRenderer sr_s;

    float speed = 300f;
    float maxSpeed;

    public Renderer particles_s;
    public ParticleSystem ps;
    public ParticleSystem ps_s;
    int seed;
    ParticleSystem.MainModule main;

    void Start()
    {
        playerTR = GameObject.Find("player").transform;
        stageTR = GameObject.Find("Stage").transform;
        ColorController.instance.AddSprite(sr_s);
        maxSpeed = Random.Range(1.5f, 2.75f);
    }

    void Update()
    {
        transform.up = playerTR.position - transform.position;
    }

    void FixedUpdate()
    {
        rb.AddForce(tr.up * speed * Time.deltaTime);
        if (Vector2.Distance(stageTR.position, tr.position) < 4.5f || Vector2.Distance(stageTR.position, tr.position) > 6f)
        {
            rb.linearVelocity = Vector2.ClampMagnitude(rb.linearVelocity, maxSpeed);
        }
        else
        {
            rb.linearVelocity = Vector2.ClampMagnitude(rb.linearVelocity, 0.5f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            particles.transform.position = tr.position;
            particles.transform.parent = tr.parent;

            seed = Random.Range(0, 1000);
            ps.randomSeed = (uint)seed;
            ps_s.randomSeed = (uint)seed;
            main = ps_s.main;
            Color32 c = ColorController.instance.currentColor;
            c.a = 255;
            main.startColor = new ParticleSystem.MinMaxGradient(c, c);
            particles.SetActive(true);

            AudioController.instance.PlayEnemyHit();

            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
