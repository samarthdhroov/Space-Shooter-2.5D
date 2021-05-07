using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Manager : MonoBehaviour
{

    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private GameObject _enemyContainer;
    [SerializeField]
    private GameObject[] _PowerupContainer;
    [SerializeField]
    private GameObject _AsteroidPrefab;

    private bool _StopSpawning = false;
    void Start()
    {
        StartCoroutine(SpawnRoutine());
        StartCoroutine(SpawnPowerupRoutine());
        StartCoroutine(SpawnAsteroid());
    }

    public void OnPlayerDeath()
    {
        _StopSpawning = true;
    }

    IEnumerator SpawnRoutine()
    {
        while (_StopSpawning == false)                                                       //  while (true) - We are not going to exit the loop since we dont want the enemy to stop.
        {
            Vector3 _position = new Vector3(Random.Range(-9.37f, 9.37f), 5.42f, 0);
            GameObject newEnemy = Instantiate(_enemyPrefab,_position, Quaternion.identity); // This line basically first instantiates an enemy object & then we are storing that enemy to another game object. 
            newEnemy.transform.parent = _enemyContainer.transform;                          //  We are containing the enemy object in an enemy container (Empty Object.)                  
            yield return new WaitForSeconds(3.0f);                                          // Wait for 3 seconds. 
                                                                                            // yield return null; Wait 1 frame.
        }
    
    } 

    IEnumerator SpawnPowerupRoutine()
    {
        while (_StopSpawning == false)
        {
            Vector3 _position = new Vector3(Random.Range(-9.37f, 9.37f), 5.42f, 0);
            int randomInt = Random.Range(0, 3);
            GameObject power = Instantiate(_PowerupContainer[randomInt], _position, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(3,8));
        }
    }

    IEnumerator SpawnAsteroid()
    {
        while(_StopSpawning == false)
        {
            Vector3 _position = new Vector3(Random.Range(-9.37f, 9.37f), 6.5f, 0);
            int randomInt = Random.Range(0, 3);
            GameObject power = Instantiate(_AsteroidPrefab,_position, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(5, 15));
        }
    }
}
