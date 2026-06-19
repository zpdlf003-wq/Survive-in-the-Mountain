using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float jumpPower = 5f;

    public Image[] hearts;          // 하트 이미지 3개
    public Sprite fullHeart;        // 꽉 찬 하트
    public Sprite emptyHeart;       // 빈 하트

    public Sprite normalSprite;     // 기본 캐릭터 이미지
    public Sprite damageSprite;     // 다친 캐릭터 이미지

    public GameObject gameOverUI;   // 게임오버 UI

    private Rigidbody2D rb = null;
    private SpriteRenderer sr = null;

    private int hp = 3;
    private bool isInvincible = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

        hp = hearts.Length;

        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].sprite = fullHeart;
        }

        if (sr != null)
        {
            sr.sprite = normalSprite;
        }

        gameOverUI.SetActive(false);
    }

    void Update()
    {
        // 스페이스바로 점프
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (rb != null)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpPower);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // 벽에 닿으면 피격
        if (collision.gameObject.CompareTag("Wall"))
        {
            Damage();
        }
    }

    public void Damage()
    {
        if (isInvincible == true)
        {
            return;
        }

        hp--;

        if (hp >= 0)
        {
            hearts[hp].sprite = emptyHeart;
        }

        StartCoroutine(DamageEffect());

        if (hp <= 0)
        {
            GameOver();
        }
    }

    IEnumerator DamageEffect()
    {
        isInvincible = true;

        // 피격 이미지로 변경
        if (sr != null)
        {
            sr.sprite = damageSprite;
        }

        // 3초 동안 다친 이미지 유지
        yield return new WaitForSeconds(3f);

        // 기본 이미지로 복귀
        if (sr != null)
        {
            sr.sprite = normalSprite;
        }

        // 총 1초 무적보다 3초 이미지가 더 길기 때문에
        // 여기서는 이미지가 돌아올 때 무적도 해제
        isInvincible = false;
    }

    void GameOver()
    {
        gameOverUI.SetActive(true);
        Time.timeScale = 0f;
    }
}