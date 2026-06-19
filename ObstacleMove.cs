using UnityEngine;

public class ObstacleMove : MonoBehaviour
{
    // 기본 속도
    public float speed = 3f;

    // 시간마다 증가하는 속도
    public float speedIncrease = 0.1f;

    private bool counted = false;

    void Update()
    {
        float x = transform.position.x;
        float y = transform.position.y;
        float z = transform.position.z;

        // 시간에 따라 점점 빨라지는 속도
        float currentSpeed =
            speed +
            (Time.timeSinceLevelLoad * speedIncrease);

        x -= currentSpeed * Time.deltaTime;

        transform.position = new Vector3(x, y, z);

        // 화면 왼쪽 밖으로 나가면 피한 벽으로 카운트
        if (x < -8f && counted == false)
        {
            counted = true;

            GameStats.avoidedWallCount++;

            Destroy(gameObject);
        }
    }
}