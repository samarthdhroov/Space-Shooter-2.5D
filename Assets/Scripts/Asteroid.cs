using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private float _speed = 18.5f;
    [SerializeField]
    private GameObject _explosion;
    private Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Rotate(Vector3.forward * _speed * Time.deltaTime);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Laser")
        {
            Destroy(this.gameObject,0.1f);
            Destroy(collision.gameObject);
            Instantiate(_explosion, transform.position,Quaternion.identity);
            player.AddScore(20);
        }

        if (collision.tag == "Player")
        {
            Destroy(this.gameObject);
            player.damage();
            Instantiate(_explosion, transform.position, Quaternion.identity);
        }
    }


}
