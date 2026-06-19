using UnityEngine;
using UnityEngine.SceneManagement;

public class Click : MonoBehaviour
{
    public string nextSceneName = "Game";

    private void OnMouseDown()
    {
        GameStats.ResetStats();
        SceneManager.LoadScene(nextSceneName);
    }
}