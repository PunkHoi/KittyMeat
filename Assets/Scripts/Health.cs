using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int startHealth;
    public Image healthBar;

    [HideInInspector]
    public int health;

    void Start()
    {
        if(healthBar != null)
            healthBar.fillAmount = 1f;
        health = startHealth;
    }

    public void TakeDamage()
    {
        health = Mathf.Max(0, health - 1);
        if (healthBar != null)
            healthBar.fillAmount = (float)health / startHealth;
    }
}
