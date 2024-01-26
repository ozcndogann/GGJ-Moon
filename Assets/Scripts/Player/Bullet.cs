using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    void Start()
    {
        rb.AddForce(transform.forward * speed);
        Destroy(this.gameObject, 2);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject, 1);

    }
    void Update()
    {
        
    }
}
