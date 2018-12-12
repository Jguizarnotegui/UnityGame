using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
//Controls the enemy random spawning
//This Is Where We Would Randomly Spawn One Of The NPC's
public class SceneController : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private GameObject enemy2Prefab;
    [SerializeField]
    private GameObject bystanderPrefab;
    private GameObject _enemy;
    private GameObject _enemy2;
    private GameObject _bystander;

    //public string enemyType;
    GameObject player;
    PlayerCharacter playerPosition;
    Vector3 defaultPosition;

    //enemy kill count for UI
    public Text killCount;
    public int killCountTracker;
    int oldCount;

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
        killCountTracker = 0;
        player = GameObject.FindGameObjectWithTag("Player");
        playerPosition = player.GetComponent<PlayerCharacter>();
        spawnPoint1 = GameObject.FindGameObjectWithTag("spawnPoint1");
        spawnPoint2 = GameObject.FindGameObjectWithTag("spawnPoint2");
        spawnPoint3 = GameObject.FindGameObjectWithTag("spawnPoint3");

        int enemy1Count = GameObject.FindGameObjectsWithTag("Enemy1").Length;
        int enemy2Count = GameObject.FindGameObjectsWithTag("Enemy2").Length;
        int bystanderCount = GameObject.FindGameObjectsWithTag("Bystander").Length;
        enemyCount = enemy1Count + enemy2Count + bystanderCount;
        
        //
        if (enemyCount < 5 || enemyCount < 7)
        {
            enSpawn = Random.Range(1, 4);
            for (int i = 0; i <= enSpawn; i++)
            {
                enemyToSpawn = Random.Range(1, 4);
                Debug.Log("Enemy To Spawn: " + enemyToSpawn);
                // Randomize enemy1 spawn location
                float Enemy1x = Random.Range(-22, 18);
                float Enemy1z = Random.Range(-22, 22);
                if (enemyToSpawn == 1)
                {
                    _enemy = Instantiate(enemyPrefab) as GameObject;
                    _enemy.transform.position = new Vector3(Enemy1x, .76f, Enemy1z);
                    float angle = Random.Range(0, 360);
                    _enemy.transform.Rotate(0, angle, 0);
                }
                if (enemyToSpawn == 2)
                {
                    int spawnLocation = Random.Range(1, 4);
                    //_enemy2 = Instantiate(enemy2Prefab) as GameObject;
                    //Debug.Log("Spawn Location: " + spawnLocation);
                    if (spawnLocation == 1 && enemyAtPoint1 == false)
                    {
                        Debug.Log("Location1");
                        spawnPointToUse = spawnPoint1.transform;
                        _enemy2 = Instantiate(enemy2Prefab) as GameObject;
                        _enemy2.transform.position = spawnPointToUse.position;
                        enemyAtPoint1 = true;
                    }
                    if (spawnLocation == 2 && enemyAtPoint2 == false)
                    {
                        Debug.Log("Location2");
                        spawnPointToUse = spawnPoint2.transform;
                        _enemy2 = Instantiate(enemy2Prefab) as GameObject;
                        _enemy2.transform.position = spawnPointToUse.position;
                        enemyAtPoint2 = true;
                    }
                    if (spawnLocation == 3 && enemyAtPoint3 == false)
                    {
                        Debug.Log("Location3");
                        spawnPointToUse = spawnPoint3.transform;
                        _enemy2 = Instantiate(enemy2Prefab) as GameObject;
                        _enemy2.transform.position = spawnPointToUse.position;
                        enemyAtPoint3 = true;
                    }
                }
                if (enemyToSpawn == 3)
                {
                    _bystander = Instantiate(bystanderPrefab) as GameObject;
                    _bystander.transform.position = new Vector3(Enemy1x, .76f, Enemy1z);
                    float angle = Random.Range(0, 360);
                    _bystander.transform.Rotate(0, angle, 0);
                }
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        int enemy1Count = GameObject.FindGameObjectsWithTag("Enemy1").Length;
        int enemy2Count = GameObject.FindGameObjectsWithTag("Enemy2").Length;
        int bystanderCount = GameObject.FindGameObjectsWithTag("Bystander").Length;
        enemyCount = enemy1Count + enemy2Count + bystanderCount;
        //Kill detect
        if (enemyCount < oldCount)
        {
            //Kill count display
            killCountTracker = ++killCountTracker;
            killCount.text = killCountTracker.ToString();
        }
        oldCount = enemyCount;
        defaultPosition = playerPosition.transform.position;

        
        if (enemyCount < 5 || enemyCount < 7)
        {
            //killCountTracker = ++killCountTracker;
            enSpawn = Random.Range(1, 4);
            for(int i = 0; i <= enSpawn; i++)
            {
                enemyToSpawn = Random.Range(1, 4);
                //Debug.Log("Enemy To Spawn: " + enemyToSpawn);
                // Randomize enemy1 spawn location
                float Enemy1x = Random.Range(defaultPosition.x - 15, defaultPosition.x + 15);
                float Enemy1z = Random.Range(defaultPosition.z - 15, defaultPosition.z + 15);
                if (enemyToSpawn == 1)
                {
                    _enemy = Instantiate(enemyPrefab) as GameObject;
                    _enemy.transform.position = new Vector3(Enemy1x, .76f, Enemy1z);
                    float angle = Random.Range(0, 360);
                    _enemy.transform.Rotate(0, angle, 0);
                }
                if(enemyToSpawn == 2)
                {
                    int spawnLocation = Random.Range(1, 4);
                    //_enemy2 = Instantiate(enemy2Prefab) as GameObject;
                    //Debug.Log("Spawn Location: " + spawnLocation);
                    if (spawnLocation == 1 && enemyAtPoint1 == false)
                    {
                        Debug.Log("Location1");
                        spawnPointToUse = spawnPoint1.transform;
                        _enemy2 = Instantiate(enemy2Prefab) as GameObject;
                        _enemy2.transform.position = spawnPointToUse.position;
                        enemyAtPoint1 = true;
                    }
                    if(spawnLocation == 2 && enemyAtPoint2 == false)
                    {
                        Debug.Log("Location2");
                        spawnPointToUse = spawnPoint2.transform;
                        _enemy2 = Instantiate(enemy2Prefab) as GameObject;
                        _enemy2.transform.position = spawnPointToUse.position;
                        enemyAtPoint2 = true;
                    }
                    if(spawnLocation == 3 && enemyAtPoint3 == false)
                    {
                        Debug.Log("Location3");
                        spawnPointToUse = spawnPoint3.transform;
                        _enemy2 = Instantiate(enemy2Prefab) as GameObject;
                        _enemy2.transform.position = spawnPointToUse.position;
                        enemyAtPoint3 = true;
                    }
                }
                if (enemyToSpawn == 3)
                {
                    _bystander = Instantiate(bystanderPrefab) as GameObject;
                    _bystander.transform.position = new Vector3(Enemy1x, .76f, Enemy1z);
                    float angle = Random.Range(0, 360);
                    _bystander.transform.Rotate(0, angle, 0);
                }
            }
        }
    }
}