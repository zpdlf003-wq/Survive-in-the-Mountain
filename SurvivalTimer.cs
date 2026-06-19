using UnityEngine;
using UnityEngine.UI;

public class SurvivalTimer : MonoBehaviour
{
    public Text timerText;

    private float time = 0f;

    void Update()
    {
        time += Time.deltaTime;

        GameStats.survivalTime = time;

        if (timerText != null)
        {
            timerText.text = "Time : " + ((int)time).ToString();
        }
    }
}