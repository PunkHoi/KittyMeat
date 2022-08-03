using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Movement player;
    public Joystick joystick;

    [HideInInspector]
    public bool IsBattleActive = false;

    public void EnableBattleMode()
    {
        IsBattleActive = true;
        
        player.ChangeToFirstView();
        player.GetComponent<Animator>()?.SetTrigger("StartBattle");
        player.CanMove = false;

        joystick.gameObject.SetActive(false);
    }
}
