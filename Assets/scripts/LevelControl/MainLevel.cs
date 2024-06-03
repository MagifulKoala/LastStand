using UnityEngine;
using UnityEngine.SceneManagement;

public class MainLevel : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject deathScreen;
    public EnemySpawner enemySpawner;
    public float difficultyIncreaseTime;
    public int timeReduce;
    bool pauseMenuActive = false;
    bool playerDied = false;
    bool timerReady = true;
    SimpleTimer timer;

    public static MainLevel Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        timer = GetComponent<SimpleTimer>();
        timer.timerFinished.AddListener(IncreaseDifficulty);
        deathScreen.SetActive(false);
        SetPauseStatus();
    }

    private void Update()
    {
        if (!playerDied)
        {
            checkPausePressed();
        }
/*         if (false)
        {
            timer.StartTimer(difficultyIncreaseTime);
            timerReady = false;
        } */
    }

    public void EndRun()
    {
        deathScreen.SetActive(true);
        Time.timeScale = 0;
        playerDied = true;
    }

    void checkPausePressed()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseMenu();
        }
    }

    private void TogglePauseMenu()
    {
        setPauseMenu();
        pauseMenu.SetActive(pauseMenuActive);
    }

    void setPauseMenu()
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

    public void LoadPlayLevel()
    {
        SceneManager.LoadScene("MainLevel");
    }

    public void QuiteGame()
    {
        Application.Quit();
    }

    void IncreaseDifficulty()
    {
        if (enemySpawner.spawnTime > 4)
        {
            enemySpawner.spawnTime -= timeReduce;
        }
        timerReady = true;
    }


}
