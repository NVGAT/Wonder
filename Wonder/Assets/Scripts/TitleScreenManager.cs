using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenManager : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Controls()
    {
        SceneManager.LoadScene("Ctrls");
    }

    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
