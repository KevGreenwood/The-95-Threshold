using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    public Transform cursor;
    public SpriteRenderer sr_s;
    public Camera cam;

    void Start()
    {
        Cursor.visible = false;
        ColorController.instance.AddSprite(sr_s);
    }

    void Update()
    {
        cursor.position = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f));
    }
}
