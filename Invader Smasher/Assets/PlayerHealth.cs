using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] Image health;
    [SerializeField] int healthAmount;

    int currentHealth;

    private void Start()
    {
        currentHealth = healthAmount;
        health.fillAmount = 1f;
    }

    public void RemoveHealth()
    {
        currentHealth--;
        health.fillAmount = 1f / healthAmount * currentHealth;
        if(currentHealth == 0)
        {
            print("Lost");
        }
    }

}
