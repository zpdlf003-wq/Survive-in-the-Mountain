using UnityEngine;
using TMPro;

public class GameOverResult : MonoBehaviour
{
    public TextMeshProUGUI wallResultText;
    public TextMeshProUGUI boarResultText;
    public TextMeshProUGUI timeResultText;

    void Start()
    {
        wallResultText.text = "Wall : " + GameStats.avoidedWallCount;
        boarResultText.text = "Boar : " + GameStats.boarCount;
        timeResultText.text = "Time : " + ((int)GameStats.survivalTime).ToString() + " ";
    }
}