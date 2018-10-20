using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//For the bystander to just run away and destroy when hitting a wall
public class Runner : MonoBehaviour
{
    public float speed = 3.0f;
    public float obstacleRange = 5.0f;
    public Transform detectPlayer;
    public float closeDistance = 8.0f;
    private bool _alive;
    GameObject player;

    private void Start()
    {
        _alive = true;
        player = GameObject.FindGameObjectWithTag("Player");
        detectPlayer = player.transform;
    }
    // Use this for initialization
    void Update()
    {
        if (_alive)
        {
            if(detectPlayer)
            {
                Vector3 offset = detectPlayer.position - transform.position;// Used to find if player is close
                float sqrLen = offset.sqrMagnitude;
                if (sqrLen < closeDistance * closeDistance)
                {
                    //float angle = Random.Range(-110, 110);
                    //transform.Rotate(0, angle, 0);
                    transform.Translate(0, 0, speed * Time.deltaTime);//move
                }
            }
        }
    }
    void OnControllerColliderHit(ControllerColliderHit col)
    {
        if (col.collider.gameObject.tag == "Wall")
        {
            Destroy(this.gameObject);
        }
    }
    public void SetAlive(bool alive)
    {
        _alive = alive;
    }
}
