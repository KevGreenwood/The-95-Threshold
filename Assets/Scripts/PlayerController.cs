using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform tr;
    public GameObject bullet;
    public SpriteRenderer sr;
    public SpriteRenderer sr_s;
    public Camera cam;
    public Transform boundaryCircleTR;
    public TMP_Text percentageText;
    float boundaryCircleRad = 4.25f;
    public GameObject particles;
    public Renderer particles_s;
    public ParticleSystem ps;
    public ParticleSystem ps_s;
    int seed;
    ParticleSystem.MainModule main;

    float speed = 700f;
    public int percentage;

    GameObject obj;
    Vector3 pos;
    public bool hit;
    float timer;

    public AudioSource AS1;
    public AudioClip shootClip;
    public AudioClip hitClip;
    public AudioClip shatterClip;
    float pitchS;

    void Start()
    {
        ColorController.instance.AddSprite(sr_s);
        percentage = 100;
    }

    void Update()
    {
        if (GameController.instance.state != 2) return;

        if (InputController.instance.playerInputEnabled)
        {
            if (hit)
            {
                timer += Time.fixedDeltaTime;
                if (timer >= 1.5f)
                {
                    GameController.instance.ResetGame();
                }
            }
            else
            {
                ManageInput();
            }
        }
        ManageBoundary();
    }

    void ManageInput()
    {
        if (InputController.instance.rightClick)
        {
            rb.AddForce(tr.up * speed * Time.deltaTime);
        }
        rb.linearVelocity = Vector2.ClampMagnitude(rb.linearVelocity, 5f);


        if (InputController.instance.leftClick)
        {
            if (Random.Range(1, 101) <= percentage)
            {
                obj = Instantiate(bullet);
                obj.transform.position = tr.position + (tr.up * 0.5f);
                obj.transform.rotation = tr.rotation;
                percentage--;
                percentageText.text = percentage + "";
                PlayShoot();
            }
            else if (!hit)
            {
                hit = true;
                timer = 0;

                particles.transform.position = tr.position;
                seed = Random.Range(0, 1000);
                ps.randomSeed = (uint)seed;
                ps_s.randomSeed = (uint)seed;
                main = ps_s.main;
                Color32 c = ColorController.instance.currentColor;
                c.a = 255;
                main.startColor = new ParticleSystem.MinMaxGradient(c, c);
                particles.SetActive(true);


                sr.enabled = false;
                sr_s.enabled = false;
                /*
                obj = Instantiate(bullet);
                obj.transform.position = tr.position + (tr.up * 0.5f);
                pos = tr.position - obj.transform.position;
                pos.z = 0;
                obj.transform.up = pos;
                */

                PlayShatter();
                Time.timeScale = 0.5f;
            }
        }

        // turn
        pos = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f));
        pos.z = 0;
        tr.up = pos - tr.position;
    }

    void ManageBoundary()
    {
        /*
        pos = Vector3.ClampMagnitude(tr.position, boundaryCircleRad);
        tr.position = pos;
        */
    }

    public void RecoverPercentage()
    {
        percentage = 100;
        percentageText.text = percentage + "";
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && !hit)
        {
            hit = true;
            timer = 0;
            PlayHit();
            Time.timeScale = 0.5f;
        }
    }

    void PlayShoot()
    {
        pitchS = 1f + (100 - percentage) / 50f;
        if (pitchS > 2) pitchS = 2;
        AS1.pitch = pitchS;
        AS1.PlayOneShot(shootClip);
    }

    void PlayHit()
    {
        AS1.pitch = Random.Range(0.9f, 1.1f);
        AS1.PlayOneShot(hitClip);
    }

    void PlayShatter()
    {
        AS1.pitch = Random.Range(0.9f, 1.1f);
        AS1.PlayOneShot(shatterClip);
    }
}
