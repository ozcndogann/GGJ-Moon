using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier4 : MonoBehaviour
{
    public Transform player;
    private bool Act = false;
    Animator animator;
    public bool Completed4;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if (player.position.z >= 280 && !Act)
        {
            animator.SetBool("isOpening", true);
            Act = true;
        }


        if (Completed4)
        {
            animator.SetBool("isClosing", true);
        }
    }
}
