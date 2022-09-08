using TMPro;
using GRAMOFON;
using UnityEngine;
using UnityEngine.UI;

public class UILeaderboardItem : MonoBehaviour
{
    [Header("ComponentElements")]
    [SerializeField] private TMP_Text m_nameText;
    [SerializeField] private Image icon_player;
    [SerializeField] private Image icon_bot;
    [SerializeField] private Slider competitor_progressSlider;

    [Header("No change")]
    [SerializeField] private Competitors targetCompetitor;
    public void Initialize(Competitors target)
    {
        targetCompetitor = target;
        m_nameText.text = targetCompetitor.GetDisplayName();
        if(targetCompetitor.gameObject.tag == "Player")
        {
            icon_player.gameObject.SetActive(true);
            icon_bot.gameObject.SetActive(false);
        }
        else
        {
            icon_player.gameObject.SetActive(false);
            icon_bot.gameObject.SetActive(true);
        }
    }
    public Competitors GetTargetCompetitors()
    {
        return targetCompetitor;
    }
    public void FillTheBar(int currentFallenBrick)
    {
        float ratio;
        if(GameManager.Instance.GetAreaFallenBrickCount() <= 0)
        {
            ratio = 0f;
            competitor_progressSlider.value = ratio;
        }
        else
        {
            ratio = (float)currentFallenBrick / (float)GameManager.Instance.GetAreaFallenBrickCount();
            competitor_progressSlider.value = ratio;
        }
    }
}
