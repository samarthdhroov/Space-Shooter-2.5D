using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] // Attribute that serailizes the data.
                     // It will allow data to be read as well as override from the inspector.
                     // However, other game objects or scripts would not be able to access it. 
    private float _speed = 15f;
    private float _multiplier = 3.5f;

    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private GameObject _trippleshotPrefab;
    private float _firerate = 0.15f;
    private float _canFire = -1.0f;
    [SerializeField]
    private int _lives = 3;

    private Spawn_Manager spawnManager;
    private bool _trippleshotactive = false;
    private bool _isSpeedBoostActive = false;
    private bool _isShieldActive = false;
    [SerializeField]
    private GameObject shieldVisual;
    [SerializeField]

    private int score;
    private UI_Manager _uiManager;
    /*private bool _rightEngineFailure = false;
    private bool _leftEngineFailure = false;*/
    [SerializeField]
    private GameObject rightBurst;
    [SerializeField]
    private GameObject leftBurst;
  
    private AudioSource _laserAudio;

    
  
    void Start()
    {
        transform.position = new Vector3(0, -4.73f, 0);

        _uiManager = GameObject.Find("Canvas").GetComponent<UI_Manager>();

        spawnManager = GameObject.FindGameObjectWithTag("Spawn_Manager").GetComponent<Spawn_Manager>();

        if(spawnManager == null)
        {
            Debug.LogError("Spawn Manager is Null");
        }

        if(_uiManager == null)
        {
            Debug.LogError("Null UI Manager");
        }

        _laserAudio = _laserPrefab.GetComponent<AudioSource>();
    }

    void Update()
    {
        translation();
        playerMovement();
        fireLaser();
      
    }


    void translation()
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

    void playerMovement()
    {
        //Position Checking Code Below for horizontal axis.

        if (transform.position.x > 9.37f)
        {
            transform.position = new Vector3(-9.37f, transform.position.y, 0);
        }
        else if (transform.position.x < -9.37f)
        {
            transform.position = new Vector3(9.37f, transform.position.y, 0);

        }


        //Position Checking Code Below for Vertical axis. The commented code is the simple implementation. The clamp fuctioned
        //allowed to lock the y position in between provided values.
/*
        if (transform.position.y > -2.5f)
        {
            transform.position = new Vector3(transform.position.x, -2.5f, 0);
        }
        else if (transform.position.y < -4.95f)
        {
            transform.position = new Vector3(transform.position.x, -4.95f, 0);
        }*/

        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -4.95f, -2.5f), 0);
    }

    void fireLaser()
    {

        /*The cooldown system works by a time controlled firing. It is implemented using Time.time which gives the 
         duration of time the game has been running and then comparing it with how long the firing can continue. 
        If the canfire limit is crossed, which means the game has been running more than 0.15 seconds, the next fire 
        will come after 0.15 seconds.*/

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire)
        {

            _canFire = Time.time + _firerate;

            if (_trippleshotactive == true)
            {
                Instantiate(_trippleshotPrefab, transform.position, Quaternion.identity); 
            }
            else {  
            Instantiate(_laserPrefab, transform.position + new Vector3(0, 1.05f, 0), Quaternion.identity);
            }

            _laserAudio.Play(0);
        }
    }

    public void damage()
    {
        if (_isShieldActive == true)
        {
            _isShieldActive = false;
            shieldVisual.SetActive(false);
            return;
        }

        if(_lives == 2)
        {
           // _rightEngineFailure = true;
            rightBurst.SetActive(true);
        } 
        
        if (_lives == 1)
        {
           // _leftEngineFailure = true;
            leftBurst.SetActive(true);
        }
        
        if (_lives < 1)
        {
            spawnManager.OnPlayerDeath();
            Destroy(this.gameObject);
            _uiManager.DisplayGameOver();
        }
        else { 
        _lives -= 1;
        }


        _uiManager.LivesDisplay(_lives);

     
    }

    public void TripleShotActive()
    {
        _trippleshotactive = true;
        StartCoroutine(TripleShotPowerDownRoutine());

    }

    IEnumerator TripleShotPowerDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        _trippleshotactive = false;
      
    }


    public void SpeedBoostActive()
    {
        _isSpeedBoostActive = true;
        _speed *= _multiplier;
        StartCoroutine(SpeedThrust());
    }
    IEnumerator SpeedThrust()
    {
        yield return new WaitForSeconds(5.0f);
        _isSpeedBoostActive = false;
        _speed /= _multiplier;
    }

    public void ShieldActive()
    {
        _isShieldActive = true;
        shieldVisual.SetActive(true);

    }

    public void AddScore(int point)
    {
        score += point;
        _uiManager.UpdateScore(score);
    }



}

