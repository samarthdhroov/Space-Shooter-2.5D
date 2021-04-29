﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] // Attribute that serailizes the data.
                     // It will allow data to be read as well as override from the inspector.
                     // However, other game objects or scripts would not be able to access it. 
    private float _speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, -4.74f, 0);
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * _speed * Time.deltaTime);

    }
}
