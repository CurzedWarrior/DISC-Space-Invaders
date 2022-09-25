using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float Speed = 5f;

    void Update()
    {
        transform.position += transform.up * Speed * Time.deltaTime;
    }
    void OnCollisionEnter(Collision Other)
    {
        Destroy(this.gameObject);
        print("hello");
    }
}
