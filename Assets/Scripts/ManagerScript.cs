using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerScript : MonoBehaviour
{
    public static ManagerScript Instance { get; private set; }
    public static int Counter { get; private set; }
 
    // Use this for initialization
    void Start () 
    {
        Instance = this;
    }
 
    public void IncrementCounter()
    {
        Counter++;
        UIScript.Instance.UpdatePointsText();
    }
 
    public void RestartGame()
    {
        PlayGamesScript.AddScoreToLeaderboard(GPGSIds.leaderboard_reach_100_points, Counter);
        Counter = 0;
        UIScript.Instance.UpdatePointsText();
    }
}
