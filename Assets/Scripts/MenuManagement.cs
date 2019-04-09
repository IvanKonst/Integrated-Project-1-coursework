using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManagement : MonoBehaviour
{
    public GameObject escape;
    public GameObject restart;
    public GameObject resume;
    public static bool isPaused=false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }


        }
    }
    public void Escape()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void Restart()
    {
        SceneManager.LoadScene("mainscenev2");
        Time.timeScale = 1;

    }
    void Pause()
    {
        escape.gameObject.SetActive(true);
        restart.gameObject.SetActive(true);
        resume.gameObject.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
       
    }


    public void Resume()
    {
        escape.gameObject.SetActive(false);
        restart.gameObject.SetActive(false);
        resume.gameObject.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
    }
}
