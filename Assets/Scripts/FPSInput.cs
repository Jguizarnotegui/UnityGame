using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Player movement and camara control
public class FPSInput : MonoBehaviour
{
    public float speed = 2.0f;
    private CharacterController _charController;
    public float gravity = -9.8f;
    public bool playerCrouching;

    // Use this for initialization
    void Start()
    {
        _charController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftShift))
        {
            speed = 5;
        } else
        {
            speed = 2;
        }
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;

        if (Input.GetKey(KeyCode.C))
        {
            playerCrouching = true;
        }
        else
        {
            playerCrouching = false;
        }

        if (playerCrouching)
        {
            _charController.height = 0f;
        } else
        {
            _charController.height = 1.5f;
        }
        

        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, speed);
        movement.y = gravity;
        movement *= Time.deltaTime;
        // convert the move from local to global space
        movement = transform.TransformDirection(movement);
        _charController.Move(movement); // move in the global space

        transform.Translate(deltaX * Time.deltaTime, 0, deltaZ * Time.deltaTime);

    }
}
