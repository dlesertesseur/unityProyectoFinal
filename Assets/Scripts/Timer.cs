using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    private float timeLeft;
    public bool timerOn;
    public TextMeshProUGUI timerText;

    private void Start()
    {
        this.timeLeft = GameManager.GetTotalTime();
        PlayerManager.SetTimeLeft(GameManager.GetTotalTime());
    }

    void Update()
    {
        if (this.timeLeft > 0)
        {
            this.timeLeft -= Time.deltaTime;
            this.UpdateTimer(this.timeLeft);
        }
        else
        {
            this.timeLeft = 0;
            PlayerManager.SetTimeLeft(0);
        }
    }

    private void UpdateTimer(float currenTime)
    {
        float value;
        float minutes = Mathf.FloorToInt(currenTime / 60);
        float seconds = Mathf.FloorToInt(currenTime % 60);

        if (currenTime >= 0)
        {
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            value = ((currenTime * 255.0f) / GameManager.GetTotalTime());
        }
        else
        {
            timerText.text = string.Format("{0:00}:{1:00}", 0, 0);
            value = 0.0f;
        }

        timerText.color = new Color32(255, (byte)value, (byte)value, 255);

        PlayerManager.SetTimeLeft(currenTime);
    }
}
