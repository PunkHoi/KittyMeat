using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int startHealth;

    public Image healthBar;

    private int curHealth;

    void Start()
    {
        healthBar.fillAmount = 1f;
        curHealth = startHealth;
    }

    public void TakeDamage()
    {
        curHealth = Mathf.Max(0, curHealth - 1);
        if (healthBar != null)
            healthBar.fillAmount = (float)curHealth / startHealth;
    }
}
