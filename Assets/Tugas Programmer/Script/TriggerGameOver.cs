using UnityEngine;
using UnityEngine.Events;

public class TriggerGameOver : MonoBehaviour
{
    public GameObject gameOverCanvas;
    public Collider bola;
    public UnityEvent onEnterTrigger;

    private void OnTriggerEnter(Collider other)
    {
        if (other == bola)
        {
            // Activate the game over canvas
            gameOverCanvas.SetActive(true);

            // Invoke the UnityEvent
            onEnterTrigger.Invoke();
        }
    }
}