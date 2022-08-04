using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Movement player;
    public Joystick joystick;
    public GameObject BattleButtonsPanel;

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
        BattleButtonsPanel.SetActive(true);
    }
}
