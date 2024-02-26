using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeDestroyer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider col)
    {
        string objectName = col.gameObject.name;
        Debug.Log("CubeDestroyer" + objectName);

        Destroy(col.gameObject);

    }
}
