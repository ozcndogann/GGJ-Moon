using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RotatePlayer : MonoBehaviour
{
    private StarterAssetsInputs _input;
    GameObject player;
    ThirdPersonController Third;
    Animator animator;
    LineRenderer line;
    void Start()
    {
        _input = GetComponent<StarterAssetsInputs>();
        player = GameObject.FindGameObjectWithTag("Player");
        animator = player.GetComponent<Animator>();
        line = GameObject.FindGameObjectWithTag("Line").GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_input.move == new Vector2(0, 0) && ThirdPersonController.canShoot)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit pos;
            if (Physics.Raycast(ray, out pos, Mathf.Infinity))
            {
                Vector3 targetPosition = pos.point;
                transform.LookAt(pos.point);
                transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
                line.SetPosition(0, new Vector3((transform.position.x), .7f, transform.position.z)); // Start at the GameObject's position
                line.SetPosition(1, targetPosition); // End at the mouse position in the world
            }
        }
        
    }
}
