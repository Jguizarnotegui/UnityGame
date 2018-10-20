using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Controls the enemy random spawning
//This Is Where We Would Randomly Spawn One Of The NPC's
public class SceneController : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;
<<<<<<< HEAD
    //[SerializeField]
    //private GameObject enemy2Prefab;
    //[SerializeField]
    //private GameObject bystanderPrefab;
    private GameObject _enemy;
    //private GameObject _enemy2;
    //private GameObject _bystander;
=======
    [SerializeField]
    private GameObject enemy2Prefab;
    [SerializeField]
    private GameObject bystanderPrefab;
    private GameObject _enemy;
    private GameObject _enemy2;
    private GameObject _bystander;
>>>>>>> 8d0716853c44eec68b39bbd9e9e795a840d24c96

    // Randomly generate 1 to 3 enemies
    private int enSpawn;
    // counter for enemies on the map
    private int enemyCount;
    //which enemies to spawn
    private int enemyToSpawn;
    // Use this for initialization
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        int enemy1Count = GameObject.FindGameObjectsWithTag("Enemy1").Length;
<<<<<<< HEAD
        //int enemy2Count = GameObject.FindGameObjectsWithTag("Enemy2").Length;
        //int bystanderCount = GameObject.FindGameObjectsWithTag("Bystander").Length;
        enemyCount = enemy1Count;
            //+ enemy2Count + bystanderCount;
=======
        int enemy2Count = GameObject.FindGameObjectsWithTag("Enemy2").Length;
        int bystanderCount = GameObject.FindGameObjectsWithTag("Bystander").Length;
        enemyCount = enemy1Count + enemy2Count + bystanderCount;
>>>>>>> 8d0716853c44eec68b39bbd9e9e795a840d24c96

        if (enemyCount < 5 || enemyCount < 7)
        {
            enSpawn = Random.Range(1, 4);
            

            for(int i = 0; i <= enSpawn; i++)
            {
<<<<<<< HEAD
                //Debug.Log("Enemy to spawn: " + enemyToSpawn);
                enemyToSpawn = 1;
                    //Random.Range(1, 4);
=======
                Debug.Log("Enemy to spawn: " + enemyToSpawn);
                enemyToSpawn = Random.Range(1, 4);
>>>>>>> 8d0716853c44eec68b39bbd9e9e795a840d24c96
                // Randomize enemy1 spawn location
                float Enemy1x = Random.Range(-22, 18);
                float Enemy1z = Random.Range(-22, 22);

                if (enemyToSpawn == 1)
                {
                    _enemy = Instantiate(enemyPrefab) as GameObject;
<<<<<<< HEAD
                    _enemy.transform.position = new Vector3(Enemy1x, .76f, Enemy1z);
                    float angle = Random.Range(0, 360);
                    _enemy.transform.Rotate(0, angle, 0);
                    //Debug.Log("Enemy 1 spawned");
                }
                //if(enemyToSpawn == 2)
                //{
                //    _enemy2 = Instantiate(enemy2Prefab) as GameObject;
                //    _enemy2.transform.position = new Vector3(Enemy1x, 1.1f, Enemy1z);
                //    float angle = Random.Range(0, 360);
                //    _enemy2.transform.Rotate(0, angle, 0);
                //    Debug.Log("Enemy 2 spawned");
                //}
                //if(enemyToSpawn == 3)
                //{
                //    _bystander = Instantiate(bystanderPrefab) as GameObject;
                //    _bystander.transform.position = new Vector3(Enemy1x, 1.1f, Enemy1z);
                //    float angle = Random.Range(0, 360);
                //    _bystander.transform.Rotate(0, angle, 0);
                //    Debug.Log("bystander spawned");
                //}
=======
                    _enemy.transform.position = new Vector3(Enemy1x, 1.5f, Enemy1z);
                    float angle = Random.Range(0, 360);
                    _enemy.transform.Rotate(0, angle, 0);
                    Debug.Log("Enemy 1 spawned");
                }
                if(enemyToSpawn == 2)
                {
                    _enemy2 = Instantiate(enemy2Prefab) as GameObject;
                    _enemy2.transform.position = new Vector3(Enemy1x, 1.1f, Enemy1z);
                    float angle = Random.Range(0, 360);
                    _enemy2.transform.Rotate(0, angle, 0);
                    Debug.Log("Enemy 2 spawned");
                }
                if(enemyToSpawn == 3)
                {
                    _bystander = Instantiate(bystanderPrefab) as GameObject;
                    _bystander.transform.position = new Vector3(Enemy1x, 1.1f, Enemy1z);
                    float angle = Random.Range(0, 360);
                    _bystander.transform.Rotate(0, angle, 0);
                    Debug.Log("bystander spawned");
                }
>>>>>>> 8d0716853c44eec68b39bbd9e9e795a840d24c96
                
            }
        }
    }
}
