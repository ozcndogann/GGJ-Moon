using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    public TrailRenderer trail;
    public GameObject particle;
   
    void Start()
    {
        //rb.AddForce(transform.forward * speed);
        

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "EnemyTag")
        {
            Destroy(collision.gameObject);
            Shoot.EnemyCounter++;
        }
        Destroy(this.gameObject);
        Instantiate(particle, collision.transform);
    }
    void Update()
    {
        Vector3 mouseScreenPosition = Input.mousePosition;

        // Convert screen position to world position
        Ray ray = Camera.main.ScreenPointToRay(mouseScreenPosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (ThirdPersonController.canShoot)
            {

                Vector3 targetPosition = hit.point;

                Vector3 direction = (targetPosition - transform.position).normalized;
                // Apply force in that direction
                rb.AddForce(direction * speed);
                Destroy(this.gameObject, 2);
            }
        }
    }
}
