using UnityEngine;
using System.Collections;

public class BoarSpawner : MonoBehaviour
{
    public GameObject boarPrefab;

    // 경고 이미지 프리팹
    public GameObject threePrefab;
    public GameObject twoPrefab;
    public GameObject onePrefab;

    // 멧돼지 효과음
    public AudioClip boarSound;

    private AudioSource audioSource;

    // 플레이어 점프 스크립트 추가
    public PlayerJumpSound playerJump;

    // 원래 점프력 저장
    private float originalJumpPower;

    // 멧돼지 등장 시 줄어드는 점프력
    public float reducedJumpPower = 5f;

    public float minTime = 5f;
    public float maxTime = 10f;

    private float nextTime = 0f;

    // 숫자 위치
    private Vector3 warningPosition = new Vector3(5f, -3f, 0f);

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // 원래 점프력 저장
        if (playerJump != null)
        {
            originalJumpPower = playerJump.jumpPower;
        }

        SetNextTime();
    }

    void Update()
    {
        if (Time.time >= nextTime)
        {
            StartCoroutine(WarningAndSpawn());

            SetNextTime();
        }
    }

    IEnumerator WarningAndSpawn()
    {
        // 3
        GameObject three = Instantiate(
            threePrefab,
            warningPosition,
            Quaternion.identity
        );

        Destroy(three, 1f);

        yield return new WaitForSeconds(1f);

        // 2
        GameObject two = Instantiate(
            twoPrefab,
            warningPosition,
            Quaternion.identity
        );

        Destroy(two, 1f);

        yield return new WaitForSeconds(1f);

        // 1
        GameObject one = Instantiate(
            onePrefab,
            warningPosition,
            Quaternion.identity
        );

        Destroy(one, 1f);

        yield return new WaitForSeconds(1f);

        // 멧돼지 등장
        GameObject boar = Instantiate(
            boarPrefab,
            new Vector3(0f, 0f, 0f),
            Quaternion.identity
        );

        // 멧돼지 효과음
        if (audioSource != null && boarSound != null)
        {
            audioSource.PlayOneShot(boarSound, 2f);
        }

        // 점프력 감소
        if (playerJump != null)
        {
            playerJump.jumpPower = reducedJumpPower;
        }

        // 멧돼지 등장 수 증가
        GameStats.boarCount++;

        // 멧돼지 사라질 때까지 대기
        yield return new WaitForSeconds(3f);

        // 멧돼지 삭제
        Destroy(boar);

        // 점프력 원래대로 복구
        if (playerJump != null)
        {
            playerJump.jumpPower = originalJumpPower;
        }
    }

    void SetNextTime()
    {
        nextTime = Time.time + Random.Range(minTime, maxTime);
    }
}