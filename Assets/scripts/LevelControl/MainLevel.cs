using UnityEngine;
using UnityEngine.SceneManagement;

public class MainLevel : MonoBehaviour
{
    public GameObject pauseMenu;
    bool pauseMenuActive = false;

    private void Start()
    {
       SetPauseStatus();     
    }

    private void Update()
    {
        checkPausePressed();
    }

    void checkPausePressed()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseMenu();
            pauseMenu.SetActive(pauseMenuActive);
        }
    }

    void TogglePauseMenu()
    {
        pauseMenuActive = !pauseMenuActive;
        SetPauseStatus();
    }

    void SetPauseStatus()
    {
        Time.timeScale = pauseMenuActive ? 0 : 1;
    }

    public void LoadMain()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuiteGame()
    {
        Application.Quit();
    }


}
