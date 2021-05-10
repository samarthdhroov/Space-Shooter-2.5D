using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private float _speed = 18.5f;
    [SerializeField]
    private GameObject _explosion;
    private Player player;
   /* [SerializeField]
    private GameObject _AsteroidPrefab;
    private AudioSource _ExplosionAudio;*/
    
   
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
       //_ExplosionAudio = _AsteroidPrefab.GetComponent<AudioSource>();
    }

   
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

      // _ExplosionAudio.Play(0);
    }


}
