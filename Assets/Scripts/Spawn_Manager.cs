using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Manager : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private GameObject _enemyPrefab;
   /* [SerializeField]
    private GameObject _enemyContainer;*/
    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    // Update is called once per frame
    void Update()
    {
     
        
    }

    IEnumerator SpawnRoutine()
    {
        while (true) // We are not going to exit the loop since we dont want the enemy to stop.
        {
            Vector3 _position = new Vector3(Random.Range(-9.21f, 9.21f), 5.42f, 0);
            Instantiate(_enemyPrefab,_position, Quaternion.identity);
            /*yield return null; // Wait 1 frame.*/
            yield return new WaitForSeconds(5.0f);// Wait for 5 seconds.
        }
        
         
    }
}
