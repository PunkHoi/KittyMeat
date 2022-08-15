using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
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

    private Movement playerMovement;
    private Animator playerAnimator;

    private void Start()
    {
        playerMovement = player.GetComponent<Movement>();
        playerAnimator = player.GetComponent<Animator>();
    }

    public void EnableBattleMode(BattleZone zone)
    {
        Debug.Log("Battle mode enabled");
        playerMovement.ChangeToFirstView(zone.enemy.transform);
        IsPlayerCanMove = true;
        IsPlayerCanRotateView = false;
        battleButtonsPanel.SetActive(true);

        IsBattleActive = true;
        battleManager.enabled = true;
        battleManager.Initialize(zone);
    }

    public void ExitFromBattleMode(BattleZone zone)
    {
        playerMovement.ChangeToThirdView();
        IsPlayerCanMove = true;
        IsPlayerCanRotateView = true;
        battleButtonsPanel.SetActive(false);

        if (battleManager.IsWinner)
            battleManager.ShowWinWindow();
        else
            battleManager.ShowLoseWindow();
        zone.toShow.SetActive(false);
        zone.enemy.SetActive(false);

        playerAnimator.SetTrigger("StandInIdle");

        IsBattleActive = false;
        battleManager.enabled = false;
    }
}
