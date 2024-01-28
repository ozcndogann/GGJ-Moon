using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier3 : MonoBehaviour
{
    public Transform player;
    private bool Act = false;
    Animator animator;
    public bool Completed3;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    IEnumerator WFS()
    {
        yield return new WaitForSeconds(3f);
        animator.SetBool("isClosing", true);
        AudioManager.Instance.PlaySfx("WallOpen");
    }

    // Update is called once per frame
    void Update()
    {
        if (player.position.z >= 198 && !Act)
        {
            animator.SetBool("isOpening", true);
            AudioManager.Instance.PlaySfx("WallOpen");
            Act = true;
        }


        if (LevelScript.Completed3)
        {
            AudioManager.Instance.PlaySfx("Win");
            StartCoroutine(WFS());
        }
    }
}
