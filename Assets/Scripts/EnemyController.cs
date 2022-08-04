using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform player;
    public Health health;
    public float distForDamage;

    public bool CheckForDamage()
    {
        Debug.Log((transform.position - player.position).magnitude);
        return (transform.position - player.position).magnitude < distForDamage;
    }
    public void TryToDamage()
    {
        if (CheckForDamage())
            health.TakeDamage();

    }
}
