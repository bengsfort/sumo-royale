using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    //public KeyCode jump;
    //public float jumpforce = 500;
    public float soupLevel = 10;
    public float movementSpeed = 50;
    public float drag = 2;
    



    public KeyCode forward;
    public KeyCode back;
    public KeyCode left;
    public KeyCode right;
    // Update is called once per frame
    void Update()
    {

        Rigidbody rb = GetComponent<Rigidbody>();
        if (Input.GetKey(left))
            rb.AddForce(Vector3.left * movementSpeed);
        if (Input.GetKey(right))
            rb.AddForce(Vector3.right * movementSpeed);
        if (Input.GetKey(forward))
            rb.AddForce(Vector3.forward * movementSpeed);
        if (Input.GetKey(back))
            rb.AddForce(Vector3.back * movementSpeed);

        //Temporary fix for throwing objects up in the air
        if (Input.GetKey(KeyCode.Space)) { rb.AddForce(Vector3.up * 100); }
        
        //If under water
        if (rb.position.y < soupLevel)
        {
            rb.drag = drag;
            rb.AddForce((rb.mass * Physics.gravity.magnitude * 3f) * Vector3.up);
        }
        
        //If floating or under water
        if(rb.position.y < soupLevel + 1) { rb.drag = drag; }
        //In the air
        else { rb.drag = 0; }

       
        //if (Input.GetKey(jump) && rb.position.y < soupLevel + 2)
        //    rb.AddForce(Vector3.up * jumpforce);

        //float collisionForce = 1000;


        //if (!isInsideBowlCircle(rb))
        //{
            
        //}
        //else { rb.AddForce(Vector3.down * floatForce); }
    }
    public bool isInsideBowlCircle(Rigidbody rb)
    {
        float bowlRadius = 10;
        float rby = rb.position.y;
        float rbx = rb.position.x;
        if (System.Math.Sqrt(rby * rby + rbx * rbx) < bowlRadius){ return true; }
        return false;
    }
}
