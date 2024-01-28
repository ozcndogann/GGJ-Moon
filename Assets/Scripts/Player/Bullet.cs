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
    public enemyHealth enemyH;
    public static int h = 10;
    void Start()
    {
        //rb.AddForce(transform.forward * speed);
        Destroy(particle, 1);

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
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "EnemyTag")
        {
            Destroy(collision.gameObject);
            Shoot.EnemyCounter++;
        }
        if (collision.gameObject.tag == "Boss")
        {
            LevelScript.BossCounter++;
            h--;
            Debug.Log("Hit");
        }
        Destroy(this.gameObject);
        var cloneParticle = Instantiate(particle, targetPosition, Quaternion.identity);
        Destroy(cloneParticle, 1);
        AudioManager.Instance.PlaySfx("Test");
        if (collision.CompareTag("Tuval"))
        {
            AudioManager.Instance.PlaySfx("Hit");
        }
        else if (collision.CompareTag("Oven"))
        {
            AudioManager.Instance.PlaySfx("OvenBoom");
        }
        else if (collision.CompareTag("Baloon"))
        {
            AudioManager.Instance.PlaySfx("BaloonBoom");
        }
        else
        {
            AudioManager.Instance.PlaySfx("GroundHit");
        }
    }
}
