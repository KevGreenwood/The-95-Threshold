using UnityEngine;

public class PointController : MonoBehaviour
{
    public Transform tr;
    public Transform playerTR;
    public PlayerController playerController;
    public SpriteRenderer sr_s;
    Vector3 pos;

    void Start()
    {
        ColorController.instance.AddSprite(sr_s);
        ChangePlace();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerController.RecoverPercentage();
            ScoreController.instance.RaiseScore();
            ChangePlace();
        }
    }

    public void ChangePlace()
    {
        pos = Random.insideUnitCircle * 4f;
        while (Vector2.Distance(pos, playerTR.position) < 3.5f)
        {
            pos = Random.insideUnitCircle * 4f;
        }
        tr.position = pos;
    }
}
