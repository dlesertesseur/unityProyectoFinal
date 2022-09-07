using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;
    private static int points = 0;
    private static float timeLeft = 0;

    private static bool activeGame = false;

    void Awake()
    {
        if (PlayerManager.instance == null)
        {
            PlayerManager.instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static void Log(string sz)
    {
        Debug.Log(sz);
    }

    public static void Reset()
    {
        timeLeft = GameManager.GetTotalTime();
        points = 0;
    }

    public static int GetPoints()
    {
        return (points);
    }

    public static bool Lost()
    {
        bool ret = false;
        if (points <= GameManager.MinBronzePoints)
        {
            ret = true;
        }
        return (ret);
    }

    public static void SetTimeLeft(float time)
    {
        timeLeft = time;
    }

    public static float GetTimeLeft()
    {
        return(timeLeft);
    }

    public static bool GetActiveGame()
    {
        return (activeGame);
    }

    public static void SetActiveGame(bool b)
    {
        activeGame = b;
    }

    public static void IncreasePoints(int p)
    {
        points += p;
    }

    public static void DecreasePoints(int p)
    {
        points -= p;
    }
}
