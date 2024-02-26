using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBump : MonoBehaviour
{
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Glass")
        {
            audioSource.Play();
            UnityEngine.Debug.Log(gameObject.name + "Collided with Glass");

        }
    }

}