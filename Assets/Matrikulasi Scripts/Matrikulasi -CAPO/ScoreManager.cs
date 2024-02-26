using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private GameObject[] objects;
    // Start is called before the first frame update
    void Start()
    {
        if (objects.Length > 0)
        {
            Debug.Log("Valid cuy");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {

    }
}
