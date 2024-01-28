using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class DialogControl : MonoBehaviour
{
    string[] dialogs = new string[] { "Matt", "Joanne", "Robert" };
    public TMP_Text DialogTMP;
    [SerializeField] private int dialogState ;
    [SerializeField] private GameObject nextButton;
    [SerializeField] private GameObject dialogUI;
    public static bool playersTurn;
    public static bool enemysTurn;
    private PlayerInput _playerInput;
    void Start()
    {
        _playerInput = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInput>();
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
        if (dialogState % 2 == 0 && Cinematic.isCineOn)
        {
            _playerInput.enabled = false;
            playersTurn = true;
            enemysTurn = false;
        }
        else if(dialogState % 2 == 1 && Cinematic.isCineOn)
        {
            _playerInput.enabled = false;
            enemysTurn = true;
            playersTurn = false;
        }
    }
    public void DialogNext()
    {
        dialogState++;
    }
}
