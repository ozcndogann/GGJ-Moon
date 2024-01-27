using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelScript : MonoBehaviour
{
    public static bool Completed1, Completed2, Completed3, Completed4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Shoot.EnemyCounter);
        if (Shoot.EnemyCounter == 5)
        {
            Completed1 = true;
        }
        if(Shoot.EnemyCounter == 10)
        {
            Completed2 = true;
        }
        if (Shoot.EnemyCounter == 15)
        {
            Completed3 = true;
        }
        if (Shoot.EnemyCounter == 20)
        {
            Completed4 = true;
        }
    }
}
