﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBehavior : MonoBehaviour
{
    private float _speed = 3f;
    
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * _speed);    
        if(transform.position.y < -6.0f)
        {
            Destroy(this.gameObject); // The moment powerup goes out of the bottom screen, it gets destroyed.
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            Destroy(this.gameObject);
            Player player = collision.transform.GetComponent<Player>(); // We are first getting the player component of collision object. Its called getting an instance.
            if(player != null)                                          // Now, just to double check if its all good. 
            {
                player.TripleShotActive();                              // If all good, we are activating the method seating in the player script. 
            }
        }
    }
}