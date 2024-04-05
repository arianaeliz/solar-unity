using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{

    public float speed = 10.0f;
    public float rotSpeed = 80.0f;
    public float boostSpeed = 10.0f;

    public float acceleration = 10.0f;
    float currentSpeed = 0;
    public float maxSpeed = 10.0f;
    public float deceleration = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveSpaceshipAccel();
        //MoveSpaceship();
        //AddBoost();
    }

    void MoveSpaceship()
    {

        //getting user input for forward movement
        float forwardInput = Input.GetAxis("Vertical");
        forwardInput *= speed;

        //getting user input for horizontal movement
        float horizontalInput = Input.GetAxis("Horizontal");
        horizontalInput *= rotSpeed;
        horizontalInput *= Time.deltaTime;

        //moving and rotating the spaceship :)
        this.transform.Translate(Vector3.forward * Time.deltaTime * forwardInput);
        this.transform.Rotate(0, horizontalInput, 0);
    }

    void AddBoost()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            speed += boostSpeed;
        }
        if(Input.GetKeyUp(KeyCode.Space))
        {
            speed -= boostSpeed;
        }
    }

    void MoveSpaceshipAccel()
    {

        //getting user input for forward movement
        float forwardInput = Input.GetAxis("Vertical");

        if(currentSpeed < maxSpeed && currentSpeed > -maxSpeed)
        {
            //make current speed when player is on gas
            currentSpeed += acceleration * forwardInput * Time.deltaTime;
        }
        else
        {
            Decelerate();
        }

        //create deceleration rate so that spaceship stops
        if(forwardInput == 0)
        {
            Decelerate();
        }

        //getting user input for horizontal movement
        float horizontalInput = Input.GetAxis("Horizontal");
        horizontalInput *= rotSpeed;
        horizontalInput *= Time.deltaTime;

        //moving and rotating the spaceship :)
        this.transform.Translate(Vector3.forward * Time.deltaTime * currentSpeed);
        this.transform.Rotate(0, horizontalInput, 0);
    }

    void Decelerate()
    {
        if (currentSpeed > 0)
        {
            currentSpeed -= deceleration * Time.deltaTime;
        }
        if (currentSpeed < 0)
        {
            currentSpeed += deceleration * Time.deltaTime;
        }
    }
}
