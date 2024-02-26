using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform startPos, endPos;
    [SerializeField] private int speed;
    [SerializeField] private GameObject ballPrefab;
    private Vector2 targetPos;
    // Start is called before the first frame update
    void Start()
    {
        targetPos = endPos.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, startPos.position) < 0.1f)
        {
            targetPos = endPos.position;
        }

        if (Vector2.Distance(transform.position, endPos.position) < 0.1f)
        {
            targetPos = startPos.position;
        }

        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Debug.Log("aku dipencet");
            Instantiate(ballPrefab, transform.position, Quaternion.identity);
        }
    }
}
