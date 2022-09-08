using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Competitors : MonoBehaviour
{
    [SerializeField] private string displayName;
    private int competitionOrder = 0;
    private int fallenBrickForThatCompetitor = 0;
    public string GetDisplayName()
    {
        return displayName;
    }
    public int GetCompetitionORder()
    {
        return competitionOrder;
    }
    public void SetCompetitionOrder(int order)
    {
        competitionOrder = order;
    }
    public void IncreaseFallenBrickForThatCompetitor()
    {
        fallenBrickForThatCompetitor += 1;
    }
    public int GetFallenBrickForThatCompetitor()
    {
        return fallenBrickForThatCompetitor;
    }
    public void ClearBrickCounts()
    {
        fallenBrickForThatCompetitor = 0;
    }
}
