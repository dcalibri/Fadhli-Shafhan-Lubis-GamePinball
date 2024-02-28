using TMPro;
using UnityEngine;

public class ScoreUIController : MonoBehaviour
{
    // reference ke text score nya
    // disini menggunakan TMP_Text karena yang dipakai adalah TextMeshPro
    // Jangan salah ya, yang nantinya dimasukan ke sini adalah text angka, bukan title nya
    public TMP_Text[] scoreTexts;
    public TMP_Text[] highestScoreTexts;


    // reference ke score manager
    public ScoreManager scoreManager;

    private void Update()
    {
        // agar lebih mudah, tiap update kita set aja angak score text nya menjadi angka score
        //scoreText.text = scoreManager.score.ToString();
        //highestScoreText.text = scoreManager.highestScore.ToString();
        // Update all score text objects with the current score

        // Update all score text objects with the current score
        foreach (TMP_Text scoreText in scoreTexts)
        {
            scoreText.text = scoreManager.score.ToString();
        }

        // Update all highest score text objects with the highest score
        foreach (TMP_Text highestScoreText in highestScoreTexts)
        {
            highestScoreText.text = scoreManager.highestScore.ToString();
        }


    }
}