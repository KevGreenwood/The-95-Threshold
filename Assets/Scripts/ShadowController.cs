using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowController : MonoBehaviour
{
    public Transform tr;
    public Transform parentTR;
    public float x;
    public float y;

    void Update()
    {
        tr.position = new Vector2(parentTR.position.x + x, parentTR.position.y + y);
    }
}
