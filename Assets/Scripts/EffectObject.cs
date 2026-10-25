using UnityEngine;

public class EffectObject : MonoBehaviour
{
    public float lifetime = 1;

    void Update()
    {
        Destroy(gameObject, lifetime);
    }
}
