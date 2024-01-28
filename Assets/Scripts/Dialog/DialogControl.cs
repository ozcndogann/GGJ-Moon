using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class DialogControl : MonoBehaviour
{
    string[] dialogs = new string[] { "Ahh! It is tough being the only adventurous monkey in this wide-open space...  ",
        "I wish I could stumble upon something to MAKE ME LAUGH.", "", 
        "Ha! It would be a blast to bother this goofy painter alien. Let the intergalactic mischief begin!" ,
        "Who dares to disturb my precious paintings? The finest masterpieces on this moon, no doubt!",
        " It is because you are the only painter here. monkey laugh ", "",
        "Aah! My cooking skills are out of this world. I mean... out of this moon.",
        "The fun is doubling up even more! Say goodbye to your moon pizzas, little chef alien!",
        "There is no monkey in this space who can lay a finger on my pizzas.", "",
        "What's the use of balloons on the moon? I say they're for popping!",
        "You little monkey, you've gone too far.",
        "My job is to go too far! monkey laugh", "",
        "Someone has to stop you little monkey. And guess what? I've got the rocket fuel for it!",
        "Oh, come on! You are just a 'lunar-tic' trying to bring me down!",
        "Do you think you are funny with these word jokes, huh?",
        "Well, what can I say? When life gives you moons, make 'lunar-tic' jokes!",
        "Enough! Cut it out with that lunar jokes. Get ready to defend yourself!", ""};
    public TMP_Text DialogTMP;
    [SerializeField] private int dialogState, dialogState1, dialogState2, dialogState3, dialogState4;
    [SerializeField] private GameObject nextButton;
    [SerializeField] private GameObject dialogUI;
    public static bool playersTurn;
    public static bool enemysTurn;
    private PlayerInput _playerInput;
    private GameObject player;
    public TMP_Text Instructiontext;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        _playerInput = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInput>();
    }

    
    void Update()
    {
        if (player.transform.position.z >= 280)
        {
            Instructiontext.text = "Destroy the enemy!";
            DialogTMP.text = dialogs[dialogState];
        }
        else if (player.transform.position.z >= 198)
        {
            Instructiontext.text = "Explode the baloons!";
            DialogTMP.text = dialogs[dialogState];
        }
        else if (player.transform.position.z >= 111)
        {
            Instructiontext.text = "Explode the ovens!";
            DialogTMP.text = dialogs[dialogState];
            DialogTMP.text = dialogs[dialogState];
        }
        else if (player.transform.position.z >= 33)
        {
            Instructiontext.text = "Aim with the right click and explode the canvases with the left click. The spell you throw goes to the location of the Cursor.";
            DialogTMP.text = dialogs[dialogState];
        }
        else
        {
            Instructiontext.text= "Press next to skip the dialogue.";
            DialogTMP.text = dialogs[dialogState];
        }
        
        if (dialogState == 2 || dialogState == 6 || dialogState == 10 || dialogState == 14 || dialogState == 20)
        {
            Debug.Log("boþ");
            dialogUI.SetActive(false);
            Instructiontext.gameObject.SetActive(false);
            _playerInput.enabled = true;
            playersTurn = true;
            enemysTurn = false;
        }

        if(player.transform.position.z >= 33)
        {
            if (dialogState == 2)
            {
                dialogState = 3;
            }
        }

        if (player.transform.position.z >= 111)
        {
            if (dialogState == 6)
            {
                dialogState = 7;
            }
        }

        if (player.transform.position.z >= 198)
        {
            if (dialogState == 10)
            {
                dialogState = 11;
            }
        }

        if (player.transform.position.z >= 280)
        {
            if (dialogState == 14)
            {
                dialogState = 15;
            }
        }

        if (dialogState == 0 || dialogState == 1 || dialogState == 3 || dialogState == 5 || dialogState == 8 || dialogState == 11 || dialogState == 13 || dialogState == 16 || dialogState == 18)
        {
            dialogUI.SetActive(true);
            Instructiontext.gameObject.SetActive(true);
            _playerInput.enabled = false;
            playersTurn = true;
            enemysTurn = false;
        }
        else if(dialogState == 4 || dialogState == 7 || dialogState == 9 || dialogState == 12 || dialogState == 15 || dialogState == 17|| dialogState == 19 )
        {
            dialogUI.SetActive(true);
            Instructiontext.gameObject.SetActive(true);
            _playerInput.enabled = false;
            enemysTurn = true;
            playersTurn = false;
        }
        //if (dialogState1 % 2 == 0)
        //{
        //    _playerInput.enabled = true;
        //    playersTurn = true;
        //    enemysTurn = false;
        //}
        //else if (dialogState1 % 2 == 1)
        //{
        //    _playerInput.enabled = false;
        //    enemysTurn = true;
        //    playersTurn = false;
        //}
        //if (dialogState1 % 3 == 0)
        //{
        //    _playerInput.enabled = true;
        //    playersTurn = true;
        //    enemysTurn = false;
        //}
        //else if (dialogState1 % 3 == 1)
        //{
        //    _playerInput.enabled = false;
        //    enemysTurn = true;
        //    playersTurn = false;
        //}
        //if (dialogState1 % 4 == 0)
        //{
        //    _playerInput.enabled = true;
        //    playersTurn = true;
        //    enemysTurn = false;
        //}
        //else if (dialogState1 % 4 == 1)
        //{
        //    _playerInput.enabled = false;
        //    enemysTurn = true;
        //    playersTurn = false;
        //}
    }
    public void DialogNext()
    {
        dialogState++;
    }
}
