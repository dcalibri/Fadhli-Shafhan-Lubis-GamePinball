using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
public class GameOverUIController : MonoBehaviour
{
    // reference untuk button
    public Button[] mainMenuButton;

    private void Start()
    {
        // setup event saat button di klik
        //mainMenuButton.onClick.AddListener(MainMenu);


        // Loop through each button in the array
        for (int i = 0; i < mainMenuButton.Length; i++)
        {
            // Add click event listener for each button
            int buttonIndex = i; // Capture the current index for the lambda expression
            mainMenuButton[i].onClick.AddListener(() => MainMenu(buttonIndex));
        }
    }

    public void MainMenu(int buttonIndex)
    {
        // Load the main menu scene
        SceneManager.LoadScene("MainMenu");
    }

    //public void MainMenu()
    //{
    // kembali ke main menu
    //SceneManager.LoadScene("MainMenu");
    //}
}