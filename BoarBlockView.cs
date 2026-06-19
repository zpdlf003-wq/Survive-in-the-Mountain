using UnityEngine;

public class BoarBlockView : MonoBehaviour
{
    public float stayTime = 2f;

    void Start()
    {
        Destroy(gameObject, stayTime);
    }
}