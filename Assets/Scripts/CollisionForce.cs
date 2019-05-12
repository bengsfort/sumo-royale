using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionForce : MonoBehaviour
{
    private Vector3 otherFood;
    private Vector3 angleToOtherFood;
    public float collisionForce = 200;

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("food"))
        {
            otherFood = other.gameObject.transform.position;
            angleToOtherFood = this.gameObject.transform.position - otherFood;

            this.gameObject.GetComponent<Rigidbody>().AddForce(angleToOtherFood * collisionForce);
            Debug.Log(angleToOtherFood);
        }
    }

    // Update is called once per frame
    void Update()
    {
        /*
         listen for collision
         if collision
         get game object.transform -> add force to self in opposite direction

         */

    }
}
