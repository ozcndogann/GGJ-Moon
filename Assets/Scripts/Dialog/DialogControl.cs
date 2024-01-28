using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogControl : MonoBehaviour
{
    string[] dialogs = new string[] { "Matt", "Joanne", "Robert" };
    public TMP_Text DialogTMP;
    [SerializeField] private int dialogState ;
    [SerializeField] private GameObject nextButton;
    [SerializeField] private GameObject dialogUI;
    public static bool playersTurn;
    public static bool enemysTurn;
    void Start()
    {
        
    }

    
    void Update()
    {
        DialogTMP.text = dialogs[dialogState];
        if (dialogs.Length - 1 == dialogState)
        {
            nextButton.SetActive(false);
            playersTurn = true;
            enemysTurn = false;
        }
        //if (dialogState ==  && dialogState ==  && dialogState ==  && dialogState == )
        //{
        //    dialogUI.SetActive(false);
        //}
        if (dialogState % 2 == 0)
        {
            playersTurn = true;
            enemysTurn = false;
        }
        else if(dialogState % 2 == 1)
        {
            enemysTurn = true;
            playersTurn = false;
        }
    }
    public void DialogNext()
    {
        dialogState++;
    }
}
