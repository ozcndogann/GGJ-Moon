using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject buttonContainer;
    [SerializeField] GameObject optionsPanel;
    [SerializeField] GameObject creditsPanel;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void Play()
    {
        SceneManager.LoadScene(sceneBuildIndex:1);
    }
    public void Options()
    {
        buttonContainer.SetActive(false);
        optionsPanel.SetActive(true);
    }
    public void Credits()
    {
        buttonContainer.SetActive(false);
        creditsPanel.SetActive(true);
    }
    public void Close()
    {
        optionsPanel.SetActive(false);
        creditsPanel.SetActive(false);
        buttonContainer.SetActive(true);
    }
}
