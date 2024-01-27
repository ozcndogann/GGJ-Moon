using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierControl : MonoBehaviour
{
    public Transform player;
    private bool Act = false;
    Animator animator;
    public bool Completed1;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if(player.position.z >= 33 && !Act)
        {
            animator.SetBool("isOpening", true);
            Act = true;
        }


        if (Completed1)
        {
            animator.SetBool("isClosing", true);
        }
    }
}
