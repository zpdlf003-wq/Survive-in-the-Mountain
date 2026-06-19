using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject redWallPrefab;
    public GameObject blueWallPrefab;
    public GameObject yellowWallPrefab;

    public float spawnX = 7f;

    // 640x480 기준, Scale Y = 3 벽이 화면 안에 들어오도록 범위 축소
    public float minY = -1.2f;
    public float maxY = 1.2f;

    public float spawnTime = 2f;

    private float nextSpawnTime = 0f;

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnWall();

            nextSpawnTime = Time.time + spawnTime;
        }
    }

    void SpawnWall()
    {
        GameObject selectedWall = null;

        int randomNumber = Random.Range(0, 3);

        if (randomNumber == 0)
        {
            selectedWall = redWallPrefab;
        }
        else if (randomNumber == 1)
        {
            selectedWall = blueWallPrefab;
        }
        else
        {
            selectedWall = yellowWallPrefab;
        }

        // 위아래 랜덤은 유지하되,
        // 너무 넓게 나오지 않도록 제한
        float randomY = Random.Range(minY, maxY);

        Vector3 spawnPosition =
            new Vector3(spawnX, randomY, 0f);

        Instantiate(
            selectedWall,
            spawnPosition,
            Quaternion.identity
        );
    }
}