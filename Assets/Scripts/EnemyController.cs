using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject player;
    public Health health;
    public float distForDamage;
    public float timeForReload;
    public GameManager gameManager;
    private Transform playerTransform;
    private Health playerHealth;
    private Animator enemyAnimator;
    private Animator playerAnimator;
    private float prevCurrentTime;
    

    private bool isAttacking;

    private void Start()
    {
        playerTransform = player.transform;
        playerHealth = player.GetComponent<Health>();
        enemyAnimator = GetComponent<Animator>();
        playerAnimator = player.GetComponent<Animator>();
        prevCurrentTime= Time.time;
    }

    public void Update()
    {
        //to-do: переписать на while а не кучу вызовов в update()
        if(gameManager.IsBattleActive)
            if (!isAttacking)
                StartCoroutine(TryToDamage());
    }

    public bool CheckForDamage()
    {
        return (transform.position - playerTransform.position).magnitude < distForDamage;
    }
    public void GetEmotionalDamage()
    {
        if (CheckForDamage())
        {
            if (Time.time - prevCurrentTime > timeForReload-1)
            {
                health.TakeDamage();
                playGotDamageAnimation(enemyAnimator);
                Debug.Log("Враг получил по морде");
                prevCurrentTime= Time.time;
            }
        }
    }
    void playGotDamageAnimation(Animator animator)
    {
        animator?.SetTrigger("Probil");
    }
    private IEnumerator TryToDamage()
    {
        isAttacking = true;
        if (CheckForDamage())
        {
            playerHealth.TakeDamage();
            Debug.Log("Мы получили по морде");
        }
        yield return new WaitForSeconds(timeForReload);
        isAttacking = false;
    }
}
