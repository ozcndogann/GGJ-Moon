using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyAI : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;
    Animator playerAnimator;
    Rigidbody rb;
    GameObject Artist, Chef, Baloon;
    //public Rigidbody Playerrb;

    public LayerMask whatIsGround, whatIsPlayer;

    //public float health;

    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;
    public float AngryTime;
    public float HittingTimer;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    //public GameObject projectile;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private void Awake()
    {
        Artist = GameObject.FindGameObjectWithTag("Artist");
        Chef = GameObject.FindGameObjectWithTag("Chef");
        Baloon = GameObject.FindGameObjectWithTag("Baloon");
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        rb = gameObject.GetComponent<Rigidbody>();
        playerAnimator = gameObject.GetComponent<Animator>();
        playerAnimator.SetBool("isRunning", false);
    }

    private void Update()
    {
        if (LevelScript.Completed1 == true)
        {
            Artist.GetComponent<Animator>().SetBool("isDead",true);
            Artist.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        }
        if (LevelScript.Completed2 == true)
        {
            Chef.GetComponent<Animator>().SetBool("isDead", true);
            Artist.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        }
        if (LevelScript.Completed3 == true)
        {
            Baloon.GetComponent<Animator>().SetBool("isDead", true);
            Artist.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        }
        if (LevelScript.Completed4 == true)
        {
            Artist.GetComponent<Animator>().SetBool("isDead", true);
            Artist.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        }
        if ((Mathf.Abs(rb.velocity.x) > 0 || Mathf.Abs(rb.velocity.z) > 0) && !playerAnimator.GetBool("isHitting") && !playerAnimator.GetBool("isAngry"))
        {
            playerAnimator.SetBool("isRunning", true);
        }
        else
        {
            playerAnimator.SetBool("isRunning", false);
        }
        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerAnimator.GetBool("isDead"))
        {
            if (!playerInSightRange /*&& !playerInAttackRange*/) Patroling();
            else if (playerInSightRange /*&& !playerInAttackRange*/ && Vector3.Distance(player.transform.position, transform.position) >= 1.5f)
            {
                transform.LookAt(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z));
                playerAnimator.SetBool("isAngry", true);
                AngryTime += Time.deltaTime;
                if (AngryTime >= 2.8f)
                {
                    playerAnimator.SetBool("isAngry", false);
                    ChasePlayer();
                }

            }

            else if (/*playerInAttackRange &&*/ playerInSightRange && Vector3.Distance(player.transform.position, transform.position) < 1.5f) AttackPlayer();
            if (!playerInSightRange || Vector3.Distance(player.transform.position, transform.position) >= 1.5f)
            {
                if (HittingTimer >= 0.85f)
                {
                    playerAnimator.SetBool("isHitting", false);
                }
            }
            if (playerAnimator.GetBool("isHitting"))
            {
                HittingTimer += Time.deltaTime;
                if (HittingTimer >= 0.85f)
                {
                    //Damage Kýsmý
                }
            }
            else
            {
                HittingTimer = 0;
            }
        }
    }

    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }
    private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
        transform.LookAt(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z));
    }

    private void AttackPlayer()
    {
        //Make sure enemy doesn't move
        agent.SetDestination(transform.position);
        playerAnimator.SetBool("isHitting", true);
        transform.LookAt(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z));

        if (!alreadyAttacked)
        {
            ///Attack code here
            //Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            //Playerrb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            //Playerrb.AddForce(transform.up * 8f, ForceMode.Impulse);
            ///End of attack code

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }
    private void ResetAttack()
    {
        //alreadyAttacked = false;
    }

    public void TakeDamage(int damage)
    {
        //health -= damage;

        //if (health <= 0) Invoke(nameof(DestroyEnemy), 0.5f);
    }
    private void DestroyEnemy()
    {
        //Destroy(gameObject);
    }

    //private void OnDrawGizmosSelected()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawWireSphere(transform.position, attackRange);
    //    Gizmos.color = Color.yellow;
    //    Gizmos.DrawWireSphere(transform.position, sightRange);
    //}
}
