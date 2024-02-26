using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerGameOver : MonoBehaviour
{
    public GameObject gameOverCanvas;

    public Collider bola;

    private void OnTriggerEnter(Collider other)
    {
        if (other == bola)
        {
            // disini game over canvas di aktifkan
            gameOverCanvas.SetActive(true);
        }
    }
}
