using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ButtonsUI : MonoBehaviour
{

	public bool GameIsPaused = false;
	public GameObject pauseMenuUI;

    /*
        public int index;
        public string levelName;

        public Image black;
        public Animator anim;*/

    void Start()
    {
        GameIsPaused = false;
        //Time.timeScale = 1;
    }

    void Update()
	{
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            /*if(Time.timeScale == 0)//GameIsPaused)
			{
                Time.timeScale = 1;
				Resume();
			}
			else if(Time.timeScale == 1)
			{
                Time.timeScale = 0;
				Pause();
			}*/

            if (GameIsPaused)
            {
                Time.timeScale = 1;
                Resume();
            }
            else
            {
                Time.timeScale = 0;
                Pause();
            }
            GameIsPaused = !GameIsPaused;
        }
	}
    
	
	
	public void MainScreen()
	{
		SceneManager.LoadScene(0);
	}
	
	public void StartGame()
	{
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
	
	public void Resume()
	{
		pauseMenuUI.SetActive(false);
		Time.timeScale = 1f;
		GameIsPaused = false;
	}
	
	public void Pause()
	{
		pauseMenuUI.SetActive(true);
		Time.timeScale = 0f;
		GameIsPaused = true;
	}

    public void TryAgain()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
	
	public void QuitGame()
	{
        print("You quit the game!");
		Application.Quit();
	}

    /*private void OnTriggerEnter2D(Collider2D enter)
    {
        if(enter.CompareTag("Player"))
        {
            SceneManager.LoadScene(index);

            SceneManager.LoadScene(levelName);
        }
    }*/
}

