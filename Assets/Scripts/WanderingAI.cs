using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
//Controls enemy movement and shooting for both enemies, enemy 1 follows, enemy 2 doesn't
public class WanderingAI : MonoBehaviour
{
    public float speed = 1.0f;
    public float obstacleRange = 5.0f;
    private bool _alive;
    GameObject player;
    //GameObject controller;
    PlayerCharacter playerHealth;
    //SceneController enemy;
    //GameObject enemyType;
    //GameObject enemy1;
    //GameObject enemy2;
    //GameObject enemy3;
    private Animator _animator;
    bool playerClose = false;

    [SerializeField]
    private GameObject fireballPrefab;
    private GameObject _fireball;

    public Transform detectPlayer;
    NavMeshAgent agent;
    public float closeDistance = 10.0f;
    float attackDistance = 8.0f;

    private void Start()
    {
        _alive = true;
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerCharacter>();
        detectPlayer = player.transform;
        _animator = GetComponent<Animator>();
        _animator.SetBool("playerClose", playerClose);
        agent = GetComponent<NavMeshAgent>();
    }
    // Use this for initialization
    void Update()
    {
        if (_alive)// If enemy is alive
        {
            detectPlayer = player.transform;
            Vector3 offset = detectPlayer.position - transform.position;// Used to find if player is close
            float sqrLen = offset.sqrMagnitude;
            float angle = Vector3.Angle(offset, transform.forward);// Used to find if player is in front of
            if (sqrLen < closeDistance * closeDistance)// If player close
            {
                if (angle > 5.0f /*&& enemy1*/)//if player not in viewing angle
                {
                    transform.LookAt(detectPlayer);// Turns to player
                }
                playerClose = true;
                _animator.SetBool("playerClose", playerClose);
                Ray ray = new Ray(transform.position, transform.forward);// Ray to look forward for player in front
                RaycastHit hit;
                if (Physics.SphereCast(ray, 0.75f, out hit))
                {
                    GameObject hitObject = hit.transform.gameObject;
                    if (hitObject.GetComponent<PlayerCharacter>() && playerHealth._health > 0 )// If raycast hits player and the player is alive then shoot fireball at player
                    {
                        if (gameObject.tag == "Enemy1")
                        {
                            agent.SetDestination(detectPlayer.position);
                            //float step = speed * Time.deltaTime;// Speed at which player is followed                
                            //transform.position = Vector3.MoveTowards(transform.position, detectPlayer.position, step);//Moves toward player but goes through wall to player
                        }
                        if (gameObject.tag == "Bystander")
                        {
                            float distance = Vector3.Distance(transform.position, detectPlayer.transform.position);
                            //Debug.Log("Distance: " + distance);
                            //Run away from player
                            if (distance <  closeDistance)
                            {
                                //vector player to skeleton
                                Vector3 dirToPlayer = transform.position - detectPlayer.transform.position;
                                Vector3 newPos = transform.position + dirToPlayer;

                                agent.SetDestination(newPos);
                            }
                        }
                        if (_fireball == null && attackDistance >= sqrLen && (gameObject.tag == "Enemy1" || gameObject.tag == "Enemy2"))
                        {
                            _animator.SetBool("attackPlayer", true);
                            _fireball = Instantiate(fireballPrefab) as GameObject;// Generate fireball and make it move
                            _fireball.transform.position =
                            transform.TransformPoint(Vector3.forward * 1.5f);
                            _fireball.transform.rotation = transform.rotation;
                            _animator.SetBool("attackPlayer", false);
                        }
                    }
                }
            }
            else
            {
                playerClose = false;
                _animator.SetBool("playerClose", playerClose);
            }
        }
    }
    public void SetAlive(bool alive)
    {
        _alive = alive;
    }
}