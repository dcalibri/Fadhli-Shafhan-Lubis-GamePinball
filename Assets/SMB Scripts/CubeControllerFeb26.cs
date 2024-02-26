using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeControllerFeb26 : MonoBehaviour
{
    public int speed = 1;
    public Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        transform.position += ((direction * speed) * Time.deltaTime);
    }

}
