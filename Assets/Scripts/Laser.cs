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
            Destroy(this.gameObject);
        }

    }
}
