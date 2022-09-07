using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;
    private static bool isPaused = false; 

    void Awake()
    {
        if (MenuManager.instance == null)
        {
            MenuManager.instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static void Pause()
    {
        PlayerManager.SetActiveGame(false);
        Time.timeScale = 0;
        isPaused = true;
    }

    public static void UnPause()
    {
        PlayerManager.SetActiveGame(true);
        Time.timeScale = 1;
        isPaused = false;
    }

    public static void ToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public static void Play()
    {
        PlayerManager.Reset();
        SceneManager.LoadScene(1);
        UnPause();
    }

    public static void Exit()
    {
        Application.Quit();
    }

    public static void Log(string sz)
    {
        Debug.Log(sz);
    }

    public static bool IsPause()
    {
       return(isPaused);
    }

}
