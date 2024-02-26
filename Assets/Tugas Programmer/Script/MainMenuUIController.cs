using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;


public class MainMenuUIController : MonoBehaviour
{
    public Button exitButton;
    public Button playButton;
    //public Button playButton;
    //public Button exitButton;
    public string changescenePlay = "Pinball_Game";
    private void Start()
    {
        exitButton.onClick.AddListener(ExitGame);
        playButton.onClick.AddListener(PlayGame);
    }



    private void ExitGame()
    {
        Application.Quit();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(changescenePlay);
    }
}