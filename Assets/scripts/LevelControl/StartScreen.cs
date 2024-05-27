using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    public void LoadMain()
    {
        SceneManager.LoadScene("MainLevel");
    }

    public void QuiteGame()
    {
        Application.Quit();
    }

}
