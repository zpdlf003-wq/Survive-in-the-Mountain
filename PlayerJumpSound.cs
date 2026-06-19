using UnityEngine;

public class PlayerJumpSound : MonoBehaviour
{
    public float jumpPower = 5f;
    public AudioClip jumpSound;

    private Rigidbody2D rb = null;
    private AudioSource audioSource = null;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (rb != null)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpPower);
            }

            if (audioSource != null && jumpSound != null)
            {
                audioSource.PlayOneShot(jumpSound, 2f);
            }
        }
    }
}