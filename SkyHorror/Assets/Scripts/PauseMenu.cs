using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool GameIsPaused = false;
    public GameObject pauseMenuUi;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(!GameIsPaused)
            {
                Pause();
            }
            else
            {
                Resume();
            }
        }
    }

    private void Pause()
    {
        Time.timeScale = 0;
        pauseMenuUi.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        GameIsPaused = true;
    }
    public void Resume()
    {
        Time.timeScale = 1f;
        pauseMenuUi.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        GameIsPaused = false;
    }  
    
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
    public void Restart()
    {        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
