using UnityEngine;
using UnityEngine.SceneManagement;

public class YourSceneManager : MonoBehaviour
{
    // Function to restart the current scene
    public void RestartScene()
    {
        // Get the name of the currently loaded scene
        string currentSceneName = SceneManager.GetActiveScene().name;

        // Reload the current scene
        SceneManager.LoadScene(currentSceneName);
    }
        
}
