using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Controls the enemy random spawning
//This Is Where We Would Randomly Spawn One Of The NPC's
public class SceneController : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private GameObject enemy2Prefab;
    //[SerializeField]
    private GameObject bystanderPrefab;
    private GameObject _enemy;
    private GameObject _enemy2;
    private GameObject _bystander;

    Vector3 spawn1 = new Vector3(-21.4f, 1.5f, 3.73f);
    Vector3 spawn2 = new Vector3(20.8f, 1.5f, -5.88f);
    Vector3 spawn3 = new Vector3(-3.88f, 1.5f, -7.03f);

    public GameObject spawnPoint1;
    public GameObject spawnPoint2;
    public GameObject spawnPoint3;

    public Transform spawnPointToUse;

    // Randomly generate 1 to 3 enemies
    private int enSpawn;
    // counter for enemies on the map
    private int enemyCount;
    //which enemies to spawn
    private int enemyToSpawn;
    bool enemyAtPoint1 = false;
    bool enemyAtPoint2 = false;
    bool enemyAtPoint3 = false;
    // Use this for initialization
    void Start()
    {
        spawnPoint1 = GameObject.FindGameObjectWithTag("Point1");
        spawnPoint2 = GameObject.FindGameObjectWithTag("Point2");
        spawnPoint3 = GameObject.FindGameObjectWithTag("Point3");
    }
    // Update is called once per frame
    void Update()
    {
        int enemy1Count = GameObject.FindGameObjectsWithTag("Enemy1").Length;
        int enemy2Count = GameObject.FindGameObjectsWithTag("Enemy2").Length;
        int bystanderCount = GameObject.FindGameObjectsWithTag("Bystander").Length;
        enemyCount = enemy1Count + enemy2Count + bystanderCount;

        if (enemyCount < 5 || enemyCount < 7)
        {
            enSpawn = Random.Range(1, 4);
            for(int i = 0; i <= enSpawn; i++)
            {
                enemyToSpawn = Random.Range(1, 3);
                // Randomize enemy1 spawn location
                float Enemy1x = Random.Range(-20, 18);
                float Enemy1z = Random.Range(-20, 20);
                if (enemyToSpawn == 1)
                {
                    _enemy = Instantiate(enemyPrefab) as GameObject;
                    _enemy.transform.position = new Vector3(Enemy1x, .76f, Enemy1z);
                    float angle = Random.Range(0, 360);
                    _enemy.transform.Rotate(0, angle, 0);
                }
                if(enemyToSpawn == 2)
                {
                    int spawnLocation = Random.Range(1, 3);
                    _enemy2 = Instantiate(enemy2Prefab) as GameObject;
                    Debug.Log("Spawn Location: " + spawnLocation);
                    if (spawnLocation == 1 && enemyAtPoint1 == false)
                    {
                        spawnPointToUse = spawnPoint1.transform;
                        _enemy2.transform.position = spawnPointToUse.position;
                        enemyAtPoint1 = true;
                    }
                    if(spawnLocation == 2 && enemyAtPoint2 == false)
                    {
                        spawnPointToUse = spawnPoint2.transform;
                        _enemy2.transform.position = spawnPointToUse.position;
                        enemyAtPoint2 = true;
                    }
                    if(spawnLocation == 3 && enemyAtPoint3 == false)
                    {
                        spawnPointToUse = spawnPoint3.transform;
                        _enemy2.transform.position = spawnPointToUse.position;
                        enemyAtPoint3 = true;
                    }
                    //int spawnPointIndex = Random.Range(0, spawnPoints.Length);

                    //Instantiate(_enemy2, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
                    //_enemy2 = Instantiate(enemy2Prefab) as GameObject;
                    // Spawn in one of the spawn points
                    //_enemy2.transform.position = new Vector3(Enemy1x, 1.1f, Enemy1z);
                    //float angle = Random.Range(0, 360);
                    //_enemy2.transform.Rotate(0, angle, 0);
                }
                //if(enemyToSpawn == 3)
                //{
                //    _bystander = Instantiate(bystanderPrefab) as GameObject;
                //    _bystander.transform.position = new Vector3(Enemy1x, 1.1f, Enemy1z);
                //    float angle = Random.Range(0, 360);
                //    _bystander.transform.Rotate(0, angle, 0);
                //    Debug.Log("bystander spawned");
                //}
            }
        }
    }
}