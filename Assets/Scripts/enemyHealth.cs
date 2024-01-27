using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class enemyHealth : MonoBehaviour
{
    public Transform player;
    public Slider slider;
    public GameObject canvas;

    private void Start()
    {
        slider.value = 10;
        canvas.SetActive(false);
    }
    private void Update()
    {
        if(player.position.z >= 280)
        {
            canvas.SetActive(true);
        }
    }
    public void SetHealth(int health)
    {
        slider.value = health;
    }

}
