using UnityEngine;

public class BoarObstacle : MonoBehaviour
{
    public float stayTime = 2f;      // 멧돼지가 화면에 머무는 시간
    public float holdTime = 1f;      // 스페이스를 몇 초 눌러야 사라지는지

    private float timer = 0f;
    private float holdTimer = 0f;

    private PlayerController player;

    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        timer += Time.deltaTime;

        // 스페이스바를 꾹 누르면 게이지 증가
        if (Input.GetKey(KeyCode.Space))
        {
            holdTimer += Time.deltaTime;

            if (holdTimer >= holdTime)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            holdTimer = 0f;
        }

        // 시간 안에 못 없애면 피격
        if (timer >= stayTime)
        {
            if (player != null)
            {
                player.Damage();
            }

            Destroy(gameObject);
        }
    }
}