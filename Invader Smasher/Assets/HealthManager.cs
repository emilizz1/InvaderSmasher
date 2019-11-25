using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public static HealthManager instance;
    public Sprite selectedYellow, yellow, selectedRed, red, selectedGreen, green, selectedBlue, blue;

    public enum DamageTypes
    {
        Yellow,
        Red, 
        Green,
        Blue
    }

    private void Awake()
    {
        instance = this;
    }

    public void DealDamage(DamageTypes type)
    {
        EnemyHealth enemyHealth = TargetManager.instance.GetTarget().GetComponent<EnemyHealth>();
        if (enemyHealth.GetCurrentHealth() == type)
        {
            enemyHealth.RemoveCurrentHealth();
        }
    }
}
