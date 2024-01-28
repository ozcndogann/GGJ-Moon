using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelScript : MonoBehaviour
{
    public static bool Completed1, Completed2, Completed3, Completed4;
    public static int BossCounter;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Shoot.TuvalCounter);
        if (Shoot.TuvalCounter == 5)
        {
            Completed1 = true;
        }
        if(Shoot.OvenCounter == 10)
        {
            Completed2 = true;
        }
        if (Shoot.BaloonCounter == 15)
        {
            Completed3 = true;
        }
        if (BossCounter == 10)
        {
            Completed4 = true;
        }
    }
}
