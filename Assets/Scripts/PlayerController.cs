using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float distForDamage;

    private Health health;

    private void Start()
    {
        health = GetComponent<Health>();
    }

    public bool CheckForDamage(Transform enemy)
    {
        return (transform.position - enemy.position).magnitude < distForDamage;
    }
    public void TryToDamage(Transform enemy)
    {
        if (CheckForDamage(enemy))
            health.TakeDamage();
    }
}
