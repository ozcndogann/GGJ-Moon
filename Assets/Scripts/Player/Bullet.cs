using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    public TrailRenderer trail;
    void Start()
    {
        rb.AddForce(transform.forward * speed);
        Destroy(this.gameObject, 2);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("enter");
        Destroy(this.gameObject, 0.05f);
    }
    void Update()
    {
        
    }
}
