using UnityEngine;

public class BackgroundMove : MonoBehaviour
{
    public float speed = 2f;
    public float resetX = -6.4f;
    public float startX = 6.4f;

    void Update()
    {
        float x = transform.position.x;
        float y = transform.position.y;
        float z = transform.position.z;

        x -= speed * Time.deltaTime;

        if (x <= resetX)
        {
            x = startX;
        }

        transform.position = new Vector3(x, y, z);
    }
}