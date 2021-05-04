using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private float _speed = 12f;
  
    
    // Update is called once per frame
    void Update()
    {
        upwardMovement();
        laserDestroy();

       
    }

    void upwardMovement()
    {
        transform.Translate(Vector3.up * Time.deltaTime * _speed);
    }

    void laserDestroy()
    {
        if (transform.position.y > 5.70f)
        {
            if(transform.parent == true)                // We are checking if the laser has any parent since we have a triple shot also. In the case, we are interested to destroy the parents also. 
            {
                Destroy(transform.parent.gameObject);
            }

            Destroy(this.gameObject);
        }

    }
}
