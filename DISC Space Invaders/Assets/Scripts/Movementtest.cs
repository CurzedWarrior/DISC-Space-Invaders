using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movementtest : MonoBehaviour
{
    public float speed = 5f;

    private Rigidbody2D myRigidBody;
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D> ();
    }

    // Update is called once per frame
    private void Update()
    {
    transform.Translate(speed * Time.deltaTime, 0, 0);
     
    }
    private void OnTriggerEnter2D(Collider2D other)         //When a box collider 2D triggers an other object
    {
        if (other.tag == "Boundary")
        {
            speed *= -1;
        }
    }
}
