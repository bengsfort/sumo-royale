using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScriptTest : MonoBehaviour
{
    static float CONTROLLER_EPSILON = 0.025f;


    public int controller;


    public float soupLevel = 10;
    public float movementSpeed = 10;
    public float drag = 3;

    public 

    /*public KeyCode forward;
    public KeyCode back;
    public KeyCode left;
    public KeyCode right;*/

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {







        Rigidbody rb = GetComponent<Rigidbody>();

        float cx = 0.0f;
        float cy = 0.0f;
        if (controller < 100)
        {
            cx = Input.GetAxis("C" + controller + "_Left Stick X Axis");
            cy = Input.GetAxis("C" + controller + "_Left Stick Y Axis");
            if (Mathf.Abs(cx) < CONTROLLER_EPSILON) cx = 0.0f;
            if (Mathf.Abs(cy) < CONTROLLER_EPSILON) cy = 0.0f;
        } else if (controller == 100)
        {
            if (Input.GetKey(KeyCode.A)) cx -= 0.1f;
            if (Input.GetKey(KeyCode.D)) cx += 0.1f;
            if (Input.GetKey(KeyCode.W)) cy -= 0.1f;
            if (Input.GetKey(KeyCode.S)) cy += 0.1f;
        } else if (controller == 101)
        {
            if (Input.GetKey(KeyCode.LeftArrow)) cx -= 0.1f;
            if (Input.GetKey(KeyCode.RightArrow)) cx += 0.1f;
            if (Input.GetKey(KeyCode.UpArrow)) cy -= 0.1f;
            if (Input.GetKey(KeyCode.DownArrow)) cy += 0.1f;
        }


        // Debug.Log(":" + cx + "," + cy);

        rb.AddForce(movementSpeed * Vector3.right * cx);
        rb.AddForce(movementSpeed * Vector3.back * cy);

        //Temporary fix for throwing objects up in the air
        if (Input.GetKey(KeyCode.Space)) { rb.AddForce(Vector3.up * 100); }

        //If under water
        if (rb.position.y < soupLevel)
        {
            rb.drag = drag;
            rb.AddForce((rb.mass * Physics.gravity.magnitude * 3f) * Vector3.up);
        }

        //If floating or under water
        if (rb.position.y < soupLevel + 1) { rb.drag = drag; }
        //In the air
        else { rb.drag = 0; }


        //bool test2 = Input.GetButtonDown("Keyboard1 Left");
        //Debug.Log(test2);

        /*if (Input.GetKey(KeyCode.A))
        {
            controllers.Left = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            controllers.Right = true;
        }
        if (Input.GetKey(KeyCode.W))
        {
            controllers.Up = true;
        }
        if (Input.GetKey(KeyCode.S))
        {
            controllers.Down = true;
        }

        rb.AddForce(Vector3.right);*/


        }

    }
