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
    Vector3 targetPosition;
    void Start()
    {
        //rb.AddForce(transform.forward * speed);
        

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

                targetPosition = hit.point;

                Vector3 direction = (targetPosition - transform.position).normalized;
                // Apply force in that direction
                rb.AddForce(direction * speed);
                Destroy(this.gameObject, 2);
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "EnemyTag")
        {
            Destroy(collision.gameObject);
            Shoot.EnemyCounter++;
        }
        Destroy(this.gameObject);


        Instantiate(particle, targetPosition, Quaternion.identity);
    }
}
