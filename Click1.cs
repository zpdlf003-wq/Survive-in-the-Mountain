using UnityEngine;
using UnityEngine.SceneManagement;

// Enter the name of the scene you want to move to in the editor
public class Click1 : MonoBehaviour
{
    public string nextSceneName = "Title";

    // Called when the object is clicked with the mouse
    private void OnMouseDown()
    {
        SceneManager.LoadScene("Title");
    }
}
