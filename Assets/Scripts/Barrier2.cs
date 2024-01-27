using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier2 : MonoBehaviour
{
    public Transform player;
    private bool Act = false;
    Animator animator;
    public bool Completed2;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if (player.position.z >= 111 && !Act)
        {
            animator.SetBool("isOpening", true);
            Act = true;
        }


        if (LevelScript.Completed2)
        {
            animator.SetBool("isClosing", true);
        }
    }
}
