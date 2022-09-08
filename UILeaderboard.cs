using GRAMOFON;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class UILeaderboard : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Transform m_container;
    [SerializeField] private RectTransform background;

    private List<UILeaderboardItem> unorderedComps = new List<UILeaderboardItem>();
    public void Initialize()
    {
        //background.offsetMin = new Vector2(0, 750);

        GameSettings gameSettings = BootstrapManager.Instance.GetGameSettings();
        List<Competitors> allComps = GameManager.Instance.GetCompetitorsOnLevel();
        for(int i = 0; i < allComps.Count; i++)
        {
            UILeaderboardItem createdItem = Instantiate(gameSettings.LeaderboardItem, m_container);
            createdItem.Initialize(allComps[i]);
            unorderedComps.Add(createdItem);
            if(i >= 1)
            {
                //background.offsetMin = new Vector2(0, background.offsetMin.y - 175f);
            }
        }
        DisplayOrderedItems();
    }
    public void DisplayOrderedItems()
    {
        unorderedComps = InterfaceManager.Instance.OrderAllPlayersInTheField(unorderedComps);
        for(int i = 0; i < unorderedComps.Count; i++)
        {
            unorderedComps[i].FillTheBar(unorderedComps[i].GetTargetCompetitors().GetFallenBrickForThatCompetitor());
            unorderedComps[i].transform.SetSiblingIndex(i + 1);
        }
    }
    public void updateVisualState(CanvasGroup canvasGroup, bool state)
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Join(canvasGroup.DOFade(state ? 1 : 0, 0.5F).SetDelay(state ? 0.5F : 0));
        sequence.OnComplete(() =>
        {
            canvasGroup.interactable = !state;
            canvasGroup.blocksRaycasts = state;
        });

        sequence.Play();
    }
    public List<UILeaderboardItem> GetUIPlayers()
    {
        return unorderedComps;
    }
}
