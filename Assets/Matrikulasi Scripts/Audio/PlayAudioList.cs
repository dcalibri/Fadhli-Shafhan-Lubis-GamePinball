using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioList : MonoBehaviour
{
    public AudioSource[] theAudioSource;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            theAudioSource[0].Play();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            theAudioSource[1].Play();
        }


    }
}