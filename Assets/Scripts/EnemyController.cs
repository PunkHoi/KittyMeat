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

    private Transform playerTransform;
    private Health playerHealth;

    private bool isAttacking;

    private void Start()
    {
        playerTransform = player.transform;
        playerHealth = player.GetComponent<Health>();
    }

    public void Update()
    {
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
            health.TakeDamage();
            Debug.Log("Враг получил пизды");
        }
        TryToDamage();
    }
    private IEnumerator TryToDamage()
    {
        isAttacking = true;
        if (CheckForDamage())
        {
            playerHealth.TakeDamage();
            Debug.Log("Мы получили пизды");
        }
        yield return new WaitForSeconds(timeForReload);
        isAttacking = false;
    }
}
