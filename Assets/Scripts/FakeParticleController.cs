using UnityEngine;

public class FakeParticleController : MonoBehaviour
{
    public SpriteRenderer sr_s;
    void Start()
    {
        ColorController.instance.AddSprite(sr_s);
    }
}
