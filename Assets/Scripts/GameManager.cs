using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static Dictionary<string, float> numberOfDetectionsByEnemy = new Dictionary<string, float>();

    public static int MinGoldPoints = 900;
    public static int MinSilverPoints = 700;
    public static int MinBronzePoints = 200;
    private static float totalTime = 120;

    void Awake()
    {
        if (GameManager.instance == null)
        {
            GameManager.instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static float GetTotalTime()
    {
        return (totalTime);
    }
}
