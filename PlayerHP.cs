using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerHP : MonoBehaviour
{
    public Image heart1;
    public Image heart2;
    public Image heart3;

    public Sprite fullHeart;
    public Sprite emptyHeart;

    public AudioClip damageSound;

    // 표정 이미지
    public Sprite normalFace;
    public Sprite damageFace;

    // 플레이어 SpriteRenderer
    private SpriteRenderer sr;

    private AudioSource audioSource;
    private int hp = 3;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        sr = GetComponent<SpriteRenderer>();

        heart1.sprite = fullHeart;
        heart2.sprite = fullHeart;
        heart3.sprite = fullHeart;

        // 시작 표정
        sr.sprite = normalFace;
    }

    public void Damage()
    {
        hp--;

        // 피격 소리
        if (audioSource != null && damageSound != null)
        {
            audioSource.PlayOneShot(damageSound, 2f);
        }

        // 찌푸리는 표정 실행
        StartCoroutine(DamageFace());

        if (hp == 2)
        {
            heart3.sprite = emptyHeart;
        }
        else if (hp == 1)
        {
            heart2.sprite = emptyHeart;
        }
        else if (hp == 0)
        {
            heart1.sprite = emptyHeart;
            SceneManager.LoadScene("GameOver");
        }
    }

    IEnumerator DamageFace()
    {
        sr.sprite = damageFace;

        yield return new WaitForSeconds(1f);

        sr.sprite = normalFace;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Damage();
        }
    }
}