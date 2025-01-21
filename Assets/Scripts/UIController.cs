using UnityEngine;
using UnityEngine.SceneManagement; // For loading scenes
using UnityEngine.UI; // For UI elements

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject instructionsContainer; // Container holding both background and instructions image
     [SerializeField] private AudioClip clickSound; // Assign the click sound in the Inspector
    [SerializeField] private AudioSource clickAudioSource; // Drag an AudioSource for button clicks
    [SerializeField] private AudioSource backgroundMusicSource; // Drag an AudioSource for background music
    [SerializeField] private float soundDelay = 1f; // Delay for the transition after sound
    // Method to start the game

      private void Start()
    {
         if (instructionsContainer != null)
        {
            instructionsContainer.SetActive(false); // Hide instructions at the start
        }
        // Start playing background music if assigned
        if (backgroundMusicSource != null && !backgroundMusicSource.isPlaying)
        {
            backgroundMusicSource.Play();
        }
        
    }
  public void StartGame()
    {
        Debug.Log("Starting the game...");

        // Stop the background music
        if (backgroundMusicSource != null && backgroundMusicSource.isPlaying)
        {
            backgroundMusicSource.Stop();
        }

        // Play the click sound
        if (clickSound != null && clickAudioSource != null)
        {
            clickAudioSource.PlayOneShot(clickSound);
        }

        // Load the next scene after a delay
        Invoke(nameof(LoadGameScene), soundDelay);
    }

     private void LoadGameScene()
    {
        // Replace "GameScene" with the name of your main game scene
        SceneManager.LoadScene("GameScene");
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

    public void ToggleInstructions()
    {
        // Play the click sound
        if (clickSound != null && clickAudioSource != null)
        {
            clickAudioSource.PlayOneShot(clickSound);
        }

        // Toggle the visibility of the entire instructions container
        if (instructionsContainer != null)
        {
            instructionsContainer.SetActive(!instructionsContainer.activeSelf);
        }
    }

    // Update is called once per frame to check for clicks outside the instructions container
    private void Update()
    {
        if (instructionsContainer.activeSelf && Input.GetMouseButtonDown(0)) // Detect left mouse button click
        {
            // Raycast to check if the click is outside the instructions container
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (!Physics.Raycast(ray, out hit))
            {
                // If the ray does not hit anything, check if the click is outside the instructions container
                if (!RectTransformUtility.RectangleContainsScreenPoint(instructionsContainer.GetComponent<RectTransform>(), Input.mousePosition, Camera.main))
                {
                    // Hide the instructions if the click is outside
                    instructionsContainer.SetActive(false);
                }
            }
        }
    }

}
