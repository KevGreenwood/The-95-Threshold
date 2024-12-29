using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ColorController : MonoBehaviour
{
    public static ColorController instance;

    public Camera cam;
    public PlayerController playerController;
    public SpriteRenderer offscreen;
    public SpriteRenderer offscreen_s;
    public SpriteRenderer boundary;
    public TMP_Text percentage;
    public TMP_Text score;
    List<SpriteRenderer> sprites = new List<SpriteRenderer>();
    public Color[] colors;
    Color32 previousColor;
    public Color32 currentColor;
    Color32 nextColor;
    float timer = 10;
    int alpha;
    public bool start;

    void Start()
    {
        instance = this;
        sprites.Add(offscreen);
        sprites.Add(offscreen_s);
        sprites.Add(boundary);
        previousColor = cam.backgroundColor;
        nextColor = cam.backgroundColor;
        timer = 30;
    }

    void Update()
    {
        if (!start) return;

        if (timer >= 30)
        {
            timer = 0;
            PickNewColor();
        }

        timer += Time.deltaTime;

        currentColor = Color32.Lerp(previousColor, nextColor, timer / 30f);

        for (int i = 0; i < sprites.Count; i++)
        {
            if (sprites[i] != null)
            {
                sprites[i].color = currentColor;
            }
            else
            {
                sprites.RemoveAt(i);
                i--;
            }
        }
        cam.backgroundColor = currentColor;

        if (playerController.percentage > 95)
        {
            alpha = 20 + (200 - (playerController.percentage * 2));
        }
        else
        {
            alpha = 100 + (200 - (playerController.percentage * 2));
        }
        if (alpha > 255) alpha = 255;
        currentColor.a = (byte)alpha;
        percentage.color = currentColor;

        alpha = 20 + (ScoreController.instance.score * 10);
        if (alpha > 255) alpha = 255;
        currentColor.a = (byte)alpha;
        score.color = currentColor;
    }

    void PickNewColor()
    {
        previousColor = nextColor;
        while (nextColor.Equals(previousColor))
        {
            nextColor = colors[Random.Range(0, colors.Length)];
        }
    }

    public void AddSprite(SpriteRenderer sr)
    {
        sprites.Add(sr);
    }
}
