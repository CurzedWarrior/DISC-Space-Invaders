using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movementtest : MonoBehaviour
{
    public float speed = 5f;
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
     transform.Translate(speed * Time.deltaTime, 0, 0);
     
    }
    private void OnTriggerEnter2D(Collider2D other)         //When a box collider 2D triggers an other object
    {
        if (other.gameObject.name == "RightBoundary")       //If the object's name is = to "RightBoundary"
        {
            transform.Translate(2 * -speed * Time.deltaTime, 0, 0);     //Translate to the left by double that of movement speed
        }
        if (other.gameObject.name == "Left Boundary")
        {
            transform.Translate(2 * speed *Time.deltaTime,0 , 0);       //Translate to the right by double that of movement speed
        }
    }
}
