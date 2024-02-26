using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    public GameObject cubePrefab;
    private Vector3 myPosition;
    //private Quaternion myRotation;

    //scale variant
    public float maxXPos = 1f;
    public float minXPos = 1f;
    public float IntervalSpawn = 2f; // Time between spawns
    public float repeatRate = 3f; // Time between repeated spawns

    private string SpawnBoxesstring = "SpawnCube";


    private bool isSpawning = false;

    // Start is called before the first frame update
    void Start()
    {
        myPosition = transform.position;
        //myRotation = transform.rotation;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isSpawning)
            {
                isSpawning = false;
                CancelInvoke(SpawnBoxesstring); // Changed "Cube Spawned" to "SpawnCube"
            }
            else
            {
                isSpawning = true;
                InvokeRepeating(SpawnBoxesstring, 0f, IntervalSpawn); // Changed "Cube Spawnning" to "SpawnCube"
            }
        }
    }

    private void SpawnCube()
    {

        Vector3 RandomPos = new Vector3
            (
            Random.Range(minXPos, maxXPos), myPosition.y, myPosition.z
            );
        // Spawn the box prefab at the random position with the same rotation as the spawner
        Instantiate(cubePrefab, RandomPos, transform.rotation);
    }

}
