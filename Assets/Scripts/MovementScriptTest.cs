using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScriptTest : MonoBehaviour
{
    static float CONTROLLER_EPSILON = 0.025f;

    public Camera Cam;

    public int PlayerID = -1;
    public int controller;


    public float soupLevel = 10;
    public float movementSpeed = 10;
    public float drag = 3;

    /*public KeyCode forward;
    public KeyCode back;
    public KeyCode left;
    public KeyCode right;*/

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerID >= 0)
        {
            var cameraScript = Cam.GetComponent<Main>();
            Player player = cameraScript.Players.Find(p => p.ID == PlayerID);
            if (player == null)
            {
                Debug.Log("Player ID " + PlayerID + " not found!");
                return;
            }
            player.MovementScript = this;
        }
    }

    // Update is called once per frame
    void Update()
    {

        ControllerInputs inputs = getControllerInputs();

        Rigidbody rb = GetComponent<Rigidbody>();

        // Debug.Log(":" + cx + "," + cy);

        rb.AddForce(movementSpeed * Vector3.right * inputs.cx);
        rb.AddForce(movementSpeed * Vector3.back * inputs.cy);

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

    private ControllerInputs getControllerInputs()
    {
        ControllerInputs res = new ControllerInputs();
        if (controller < 100)
        {
            res.cx = Input.GetAxis("C" + controller + "_Left Stick X Axis");
            res.cy = Input.GetAxis("C" + controller + "_Left Stick Y Axis");
            if (Mathf.Abs(res.cx) < CONTROLLER_EPSILON) res.cx = 0.0f;
            if (Mathf.Abs(res.cy) < CONTROLLER_EPSILON) res.cy = 0.0f;
        }
        else if (controller == 100)
        {
            if (Input.GetKey(KeyCode.A)) res.cx -= 0.1f;
            if (Input.GetKey(KeyCode.D)) res.cx += 0.1f;
            if (Input.GetKey(KeyCode.W)) res.cy -= 0.1f;
            if (Input.GetKey(KeyCode.S)) res.cy += 0.1f;
        }
        else if (controller == 101)
        {
            if (Input.GetKey(KeyCode.LeftArrow)) res.cx -= 0.1f;
            if (Input.GetKey(KeyCode.RightArrow)) res.cx += 0.1f;
            if (Input.GetKey(KeyCode.UpArrow)) res.cy -= 0.1f;
            if (Input.GetKey(KeyCode.DownArrow)) res.cy += 0.1f;
        }
        return res;
    }

    private class ControllerInputs
    {
        public float cx { get; set; }
        public float cy { get; set; }
        public bool A { get; set; }
    }

}
