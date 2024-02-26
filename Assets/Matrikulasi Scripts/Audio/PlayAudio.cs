using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioOnStart : MonoBehaviour
{
    public AudioSource theAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        theAudioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
