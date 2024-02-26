using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    private GameObject segitiga;
    // Start is called before the first frame update
    void Start()
    {
        segitiga = GameObject.FindGameObjectWithTag("Segitiga");
        UnityEngine.Debug.Log(segitiga.name);

        // add component
        segitiga.AddComponent<PolygonCollider2D>();

        // remove component
        Destroy(segitiga.GetComponent<BoxCollider2D>());
    }
}
