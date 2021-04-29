using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] // Attribute that serailizes the data.
                     // It will allow data to be read as well as override from the inspector.
                     // However, other game objects or scripts would not be able to access it. 
    private float _speed = 15f;
  
    void Start()
    {
        transform.position = new Vector3(0, -4.74f, 0);
        
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);

        /*
          Below is the real code that would do the translation on axes.However the consice
          implementation has been done in the lines below.The reason is that since both
          inputs are going to oscilate between - 1 to 1, it makes sense to get rid of the new vector
          and take the default key input in the calculation. 
         
        transform.Translate(vector3.right(1, 0, 0) * horizontalInput * _speed * Time.deltaTime);
        transform.Translate(vector3.up(0, 1, 0) * verticalInput * _speed * Time.deltaTime); 
        
         */

        transform.Translate(direction * _speed * Time.deltaTime); 

        /*
        Here, the direction vector is what
        transform.translate(vector3) needed as argument. But to make things smoother, we are multiplying
        the vector with speed and time. 
        */
    }
}
