using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public Animator creditsAnim;
    public Animator menuAnim;
    public GameObject intro;
    public Animator introAnim;
    public Animator camAnim;

    bool buttonPressed;
    bool inCredits;
    float timer;


    void Start()
    {
        
    }

    void Update()
    {
        if(GameController.instance.state == 0 && !buttonPressed)
        {
            if (!inCredits)
            {
                if (InputController.instance.credits)
                {
                    creditsAnim.SetTrigger("in");
                    menuAnim.SetTrigger("out");
                    inCredits = true;
                }
                else if (InputController.instance.enter)
                {
                    GameController.instance.state = 1;
                    buttonPressed = true;
                    menuAnim.SetTrigger("out");
                    intro.SetActive(true);
                    introAnim.SetTrigger("action");
                    AudioController.instance.StartMusic();
                    timer = 0;
                }
                else if (InputController.instance.escape)
                {
                    buttonPressed = true;
                    Application.Quit();
                }
            }
            else
            {
                if (InputController.instance.credits || InputController.instance.enter || InputController.instance.escape)
                {
                    creditsAnim.SetTrigger("out");
                    menuAnim.SetTrigger("in");
                    inCredits = false;
                }
            }
        }

        if (GameController.instance.state == 1)
        {
            timer += Time.deltaTime;

            if (timer >= 46f && !ColorController.instance.start)
            {
                ColorController.instance.start = true;
            }

            if (timer >= 57.4f)
            {
                Invoke("StartGame", 1f);
                camAnim.SetTrigger("game");
                buttonPressed = false;
                timer = 0;
            }

            if(timer > 1f && InputController.instance.enter)
            {
                intro.SetActive(false);
                Invoke("StartGame", 1f);
                camAnim.SetTrigger("game");
                buttonPressed = false;
                timer = 0;
                ColorController.instance.start = true;
            }

            if (timer > 1f && InputController.instance.escape)
            {
                Time.timeScale = 1;
                SceneManager.LoadScene("Game");
            }
        }
    }

    void StartGame()
    {
        GameController.instance.StartGame();
    }
}
