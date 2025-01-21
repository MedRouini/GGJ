using UnityEngine;
using UnityEngine.SceneManagement; // For loading scenes
using UnityEngine.UI; // For UI elements

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject instructionsImage; 

    // Method to start the game
    public void StartGame()
    {
        Debug.Log("Starting the game...");
        // Load the main game scene (replace "GameScene" with your scene name)
        // SceneManager.LoadScene("GameScene");
    }

    // Method to quit the game
    public void QuitGame()
    {
        Debug.Log("Quitting the game...");
        Application.Quit();

        // In the editor, quitting does not work, so log a message for testing
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    // Method to show/hide instructions
    public void ToggleInstructions()
    {
        if (instructionsImage != null)
        {
            bool isActive = instructionsImage.activeSelf;
            instructionsImage.SetActive(!isActive); // Toggle the active state
        }
        else
        {
            Debug.LogWarning("Instructions Image is not assigned!");
        }
    }
}
