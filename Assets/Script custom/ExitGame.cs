using UnityEngine;
using UnityEngine.UI;

public class ExitGame : MonoBehaviour
{
    public Button exitButton;

    void Start()
    {
        // Add listener to the exitButton
        exitButton.onClick.AddListener(ExitTheGame);
    }

    // Method to exit the game
    public void ExitTheGame()
    {
        // Quit the application
        Application.Quit();
    }
}
