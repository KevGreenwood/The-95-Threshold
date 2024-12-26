using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class InputController : MonoBehaviour
{
    public static InputController instance;

    public TMP_Text percentageText;
    public PlayerController playerController;
    public bool leftClick;
    public bool rightClick;
    public bool enter;
    public bool escape;
    public bool credits;

    public bool playerInputEnabled = true;

    bool inputGet;
    bool paused;
    float tScale;

    void Start()
    {
        instance = this;
    }

    void Update()
    {
        inputGet = false;
        leftClick = false;
        rightClick = false;
        enter = false;
        escape = false;
        credits = false;

        if (Input.GetMouseButtonDown(0))
        {
            leftClick = true;
        }
        if (Input.GetMouseButton(1))
        {
            rightClick = true;
        }
        if (Input.GetKeyDown("return") || Input.GetKeyDown("space"))
        {
            enter = true;
        }
        if (Input.GetKeyDown("escape"))
        {
            escape = true;
        }
        if (Input.GetKeyDown("c"))
        {
            credits = true;
        }

        inputGet = true;

        if(GameController.instance.state == 2)
        {
            if (enter)
            {
                if (paused)
                {
                    paused = false;
                    playerInputEnabled = true;
                    percentageText.text = playerController.percentage + "";
                    Time.timeScale = tScale;
                }
                else
                {
                    paused = true;
                    playerInputEnabled = false;
                    tScale = Time.timeScale;
                    percentageText.text = "---";
                    Time.timeScale = 0;
                }
            }

            if (escape)
            {
                Time.timeScale = 1;
                SceneManager.LoadScene("Game");
            }
        }else if (GameController.instance.state == 3)
        {
            if (escape)
            {
                Time.timeScale = 1;
                SceneManager.LoadScene("Game");
            }
        }
    }
}
