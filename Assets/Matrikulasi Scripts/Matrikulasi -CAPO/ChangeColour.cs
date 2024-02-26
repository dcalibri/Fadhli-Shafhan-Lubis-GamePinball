using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    [SerializeField] private Color newColor;
    private SpriteRenderer _sprite;
    // Start is called before the first frame update
    void Start()
    {
        _sprite = GetComponent<SpriteRenderer>();
        // _sprite.color = newColor;

        // Random color
        _sprite.color = Random.ColorHSV();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
