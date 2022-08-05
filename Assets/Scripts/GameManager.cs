using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Movement player;
    public Joystick joystick;
    public GameObject battleButtonsPanel;
    public BattleManager battleManager;
    
    [HideInInspector]
    public bool IsBattleActive = false;
    [HideInInspector]
    public bool IsPlayerCanMove = true;
    [HideInInspector]
    public bool IsPlayerCanRotateView = true;
    [HideInInspector]
    public bool IsThirdCameraView = true;

    public void EnableBattleMode(BattleZone zone)
    {
        IsBattleActive = true;

        player.ChangeToFirstView(zone.enemy.transform);
        IsPlayerCanMove = true;
        IsPlayerCanRotateView = false;
        battleButtonsPanel.SetActive(true);
    }

    public void ExitFromBattleMode(bool IsWinner)
    {
        IsBattleActive = false;
        player.ChangeToThirdView();
        IsPlayerCanMove = true;
        IsPlayerCanRotateView = true;
        battleButtonsPanel.SetActive(false);

        if (IsWinner)
            battleManager.ShowWinWindow();
        else
            battleManager.ShowLoseWindow();
    }
}
