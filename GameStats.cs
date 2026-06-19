using UnityEngine;

public class GameStats : MonoBehaviour
{
    public static int avoidedWallCount = 0;
    public static int boarCount = 0;
    public static float survivalTime = 0f;

    public static void ResetStats()
    {
        avoidedWallCount = 0;
        boarCount = 0;
        survivalTime = 0f;
    }
}