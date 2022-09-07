using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HudController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI points;
    public Image imageAward;

    public Sprite gold;
    public Sprite silver;
    public Sprite bronze;
    public Sprite sad;

    private void CheckImage()
    {
        if (PlayerManager.GetPoints() > GameManager.MinGoldPoints)
        {
            imageAward.sprite = gold;
        }
        else
        {
            if (PlayerManager.GetPoints() > GameManager.MinSilverPoints)
            {
                imageAward.sprite = silver;
            }
            else
            {
                if (PlayerManager.GetPoints() > GameManager.MinBronzePoints)
                {
                    imageAward.sprite = bronze;
                }
                else
                {
                    imageAward.sprite = sad;
                }
            }
        }
    }

    void Update()
    {
        points.text = PlayerManager.GetPoints().ToString();
        CheckImage();
    }
}
