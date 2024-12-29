using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera cam;

    float size1;
    float size2;
    float timer;
    bool goingUp = true;


    void Start()
    {
        size1 = 5.5f;
        size2 = 6f;
    }

    void Update()
    {
        timer += Time.deltaTime;

        cam.orthographicSize = Mathf.Lerp(size1, size2, timer / 10f);

        if (timer > 10f)
        {
            timer = 0f;
            goingUp = !goingUp;
            if (goingUp)
            {
                size1 = 5.5f;
                size2 = 6f;
            }
            else
            {
                size1 = 6f;
                size2 = 5.5f;
            }
        }
    }
}
