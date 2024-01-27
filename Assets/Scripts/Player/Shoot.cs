using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public static int EnemyCounter;
    public GameObject bullet;
    private StarterAssetsInputs _input;
    public GameObject spawnpos;
    public float FireRate;
    float timer;
    void Start()
    {
        _input = GetComponent<StarterAssetsInputs>();
        timer = 91;
    }

    // Update is called once per frame
    void Update()
    {
        if (_input.throwing && Input.GetMouseButton(0))
        {
            timer += Time.deltaTime;
            if (timer >= FireRate)
            {
                timer = 0;
                GameObject go = Instantiate(bullet, spawnpos.transform.position, spawnpos.transform.rotation);
                go.SetActive(true);
            }
        }
        if (!_input.aiming)
        {
            timer = 91;
        }
    }
}
