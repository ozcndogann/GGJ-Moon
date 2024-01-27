using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogControl : MonoBehaviour
{
    string[] dialogs = new string[] { "Matt", "Joanne", "Robert" };
    public TMP_Text DialogTMP;
    private int dialogState;
    [SerializeField] private GameObject nextButton;
    [SerializeField] private GameObject dialogUI;
    void Start()
    {
        
    }

    
    void Update()
    {
        DialogTMP.text = dialogs[dialogState];
        if (dialogs.Length - 1 == dialogState)
        {
            nextButton.SetActive(false);
        }
        //if (dialogState ==  && dialogState ==  && dialogState ==  && dialogState == )
        //{
        //    dialogUI.SetActive(false);
        //}

    }
    public void DialogNext()
    {
        dialogState++;
    }
}
