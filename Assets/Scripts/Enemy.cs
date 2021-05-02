using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    private float _speed = 8.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        downwardMovement();
        respawn();

        
    }

    void downwardMovement()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
    }

    void respawn()
    {
        float x = Random.Range(9.21f, -9.21f);
        if (transform.position.y < -5.41f)
        {
            transform.position = new Vector3(x,5.35f, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        /*This method only works when trigger was enabled on game objects. Also, we have used the tag from Unity to identify object*/
        if (other.tag == "Player")
        {
            Player player = other.transform.GetComponent<Player>();

            if (player != null) { // We are checking here if the player component that we are trying to access exists. 
                                  // Only if it does, we would destroy the object. If we had not checked this,
                                  // Unity would have shown an error. Try eliminating this check to see the error.
            Destroy(this.gameObject);
            player.damage();
            
            }

        }

        if (other.gameObject.tag == "Laser")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
