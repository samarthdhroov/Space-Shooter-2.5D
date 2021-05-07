using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    private float _speed = 5.0f;
    private Player _playerObject;
    private Animator _enemyAnimator;
  /*  [SerializeField]
    private GameObject _enemyPrefab;*/
    private AudioSource _ExplosionAudio;


    private void Start()
    {
        _playerObject = GameObject.Find("Player").GetComponent<Player>();

        if(_playerObject == null)
        {
            Debug.LogError("Player is Null.");
        }

        _enemyAnimator = GetComponent<Animator>();

        if(_enemyAnimator == null)
        {
            Debug.LogError("Enemy is Null.");
        }

        
        _ExplosionAudio = GetComponent<AudioSource>();
    }
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

    private void OnTriggerEnter2D(Collider2D other)
    {

        /*This method only works when trigger was enabled on game objects. Also, we have used the tag from Unity to identify object*/
        if (other.tag == "Player")
        {
            Player player = other.transform.GetComponent<Player>();

            if (player != null) { // We are checking here if the player component that we are trying to access exists. 
                                  // Only if it does, we would destroy the object. If we had not checked this,
                                  // Unity would have shown an error. Try eliminating this check to see the error.
            _enemyAnimator.SetTrigger("OnEnemyDeath");
                _speed = 0;
                Destroy(this.gameObject, 2.30f);
            player.damage();
            _ExplosionAudio.Play();
            }
           
        }

        if (other.gameObject.tag == "Laser")
        {
            Destroy(other.gameObject);

            if (_playerObject != null)
            {
                _playerObject.AddScore(10);
            }

            _enemyAnimator.SetTrigger("OnEnemyDeath");
            _speed = 0;
            _ExplosionAudio.Play();
            Destroy(this.gameObject,2.30f);
            
        }
     

    }
}
