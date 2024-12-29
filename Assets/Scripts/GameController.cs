using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public PlayerController playerController;
    public PointController pointController;
    GameObject[] objs;
    public int state; // 0 = press start, 1 = intro, 2 = game, 3 = end
    public EnemySpawner enemySpawner;

    void Start()
    {
        instance = this;
    }

    public void ResetGame()
    {
        objs = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject obj in objs)
        {
            Destroy(obj);
        }
        objs = GameObject.FindGameObjectsWithTag("Bullet");
        foreach (GameObject obj in objs)
        {
            Destroy(obj);
        }

        Time.timeScale = 1f;

        playerController.tr.position = Vector3.zero;
        playerController.tr.rotation = Quaternion.identity;
        playerController.rb.linearVelocity = Vector3.zero;
        playerController.sr.enabled = true;
        playerController.sr_s.enabled = true;
        playerController.particles.SetActive(false);
        playerController.RecoverPercentage();
        playerController.hit = false;
        pointController.ChangePlace();
        enemySpawner.Restart();
        ScoreController.instance.ResetScore();
    }

    public void StartGame()
    {
        state = 2;
    }
}
