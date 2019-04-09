using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject play;
    public GameObject howtoplay;
    public GameObject exit;
    public GameObject returntomainmenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Play()
    {
        SceneManager.LoadScene("mainscenev2");
    }
    public void Howtoplay()
    {
        SceneManager.LoadScene("Howtoplay");
    }

    public void Exit()
    {
        
        Application.Quit();

    }
    public void ReturntoMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    
}
