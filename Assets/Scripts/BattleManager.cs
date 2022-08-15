using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public Animator playerAnimator;
    public GameManager gameManager;
    public GameObject winWindow;
    public GameObject loseWindow;
    public GameObject player;

    private BattleZone curZone;
    private Health enemyHealth;
    private Health playerHealth;

    private void Start()
    {
        playerHealth = player.GetComponent<Health>();
    }
    private void Update()
    {
        if (IsWinner || playerHealth.health == 0)
            gameManager.ExitFromBattleMode(curZone);
    }

    public void Initialize(BattleZone zone)
    {
        curZone = zone;
        enemyHealth = zone.enemy.GetComponent<Health>();
    }
    public bool IsWinner
    {
        get { return enemyHealth.health == 0; }
    }   
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
