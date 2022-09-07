using UnityEngine;
using UnityEngine.UI;

public class Lifecycle : MonoBehaviour
{
    public GameObject lostPanel = null;
    public GameObject winPanel = null;
    public GameObject pauseMenu = null;
    public Image winImage;

    public Sprite gold;
    public Sprite silver;
    public Sprite bronze;

    private bool activeMenu = false;

    public void ToMainMenu()
    {
        MenuManager.ToMainMenu();
    }

    private void CheckImage()
    {
        if (PlayerManager.GetPoints() > GameManager.MinGoldPoints)
        {
            winImage.sprite = gold;
        }
        else
        {
            if (PlayerManager.GetPoints() > GameManager.MinSilverPoints)
            {
                winImage.sprite = silver;
            }
            else
            {
                if (PlayerManager.GetPoints() > GameManager.MinBronzePoints)
                {
                    winImage.sprite = bronze;
                }
            }
        }
    }

    private void ChekPauseGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (MenuManager.IsPause())
            {
                MenuManager.UnPause();
            }
            else
            {
                MenuManager.Pause();
            }

            activeMenu = !activeMenu;
            if (pauseMenu != null)
            { 
                pauseMenu.SetActive(activeMenu);
            }
        }
    }

    void Update()
    {
        if (PlayerManager.GetTimeLeft() <= 0)
        {
            if (PlayerManager.Lost())
            {
                lostPanel.SetActive(true);
                winPanel.SetActive(false);
            }
            else
            {
                CheckImage();
                winPanel.SetActive(true);
                lostPanel.SetActive(false);
            }
            MenuManager.Pause();
        }

        ChekPauseGame();
    }
}
