using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayAudioOnPressBtn : MonoBehaviour
{
    public AudioSource theAudioSource;
    public Button[] buttons;
    public float MinPitch = 0.9f;
    public float MaxPitch = 1.1f;
    public enum ButtonType
    {
        MultipleButtons,
        FindButtonByName
    }

    public ButtonType buttonType;

    private static PlayAudioOnPressBtn instance; // Singleton instance

    public bool doNotDestroy = false; // Control whether the script persists across scene changes

    private void Awake()
    {
        if (instance == null)
        {
            instance = this; // Set this instance as the singleton instance
            if (doNotDestroy)
            {
                DontDestroyOnLoad(gameObject); // Make the GameObject persist across scene changes
            }
        }
        else
        {
            Destroy(gameObject); // If another instance already exists, destroy this instance
        }
    }

    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded; // Subscribe to the sceneLoaded event
        RestartScript(); // Initial script setup
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        RestartScript(); // Restart the script when a new scene is loaded
    }

    private void RestartScript()
    {
        if (buttonType == ButtonType.MultipleButtons)
        {
            foreach (Button button in buttons)
            {
                button.onClick.AddListener(PlayRandomPitchAudio);
            }
        }
        else if (buttonType == ButtonType.FindButtonByName)
        {
            FindButtonsAndAssignListener();
        }
    }

    // Method to play the audio with random pitch
    void PlayRandomPitchAudio()
    {
        float randomPitch = Random.Range(MinPitch, MaxPitch);
        theAudioSource.pitch = randomPitch;
        theAudioSource.PlayOneShot(theAudioSource.clip);
    }

    // Method to find buttons with names containing "btn" or "Button" prefix and assign listeners
    void FindButtonsAndAssignListener()
    {
        buttons = FindObjectsOfType<Button>();
        foreach (Button button in buttons)
        {
            if (button.name.StartsWith("btn") || button.name.StartsWith("Button"))
            {
                button.onClick.AddListener(PlayRandomPitchAudio);
            }
        }
    }
}
