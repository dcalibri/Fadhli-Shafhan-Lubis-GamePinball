using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class entercolider : MonoBehaviour
{
    [SerializeField] private int value;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        UnityEngine.Debug.Log("Score: " + value);
    }
}
