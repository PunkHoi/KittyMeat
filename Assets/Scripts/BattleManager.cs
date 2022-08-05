using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public Animator playerAnimator;
    public GameObject winWindow;
    public GameObject loseWindow;

    public void Attack()
    {
        if (Random.Range(0, 2) == 0)
            LeftAttack();
        else
            RightAttack();
    }
    public void LeftAttack()
    {
        playerAnimator.SetTrigger("LeftAttack");
    }
    public void RightAttack()
    {
        playerAnimator.SetTrigger("RightAttack");
    }

    public void ShowWinWindow()
    {
        winWindow.SetActive(true);
    }
    public void HideWinWindow()
    {
        winWindow.SetActive(false);
    }
    public void ShowLoseWindow()
    {
        loseWindow.SetActive(true);
    }
    public void HideLoseWindow()
    {
        loseWindow.SetActive(false);
    }
}
