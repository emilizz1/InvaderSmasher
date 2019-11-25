using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] List<HealthManager.DamageTypes> health;
    [SerializeField] Canvas canvas;
    [SerializeField] GameObject damageTypePrefab;

    private void Start()
    {
        UpdateHealth();
    }

    public void SelectedAsTarget()
    {
        UpdateHealth();
    }

    public HealthManager.DamageTypes GetCurrentHealth()
    {
        return health[0];
    }

    public void RemoveCurrentHealth()
    {
        health.RemoveAt(0);
        UpdateHealth();
    }

    void UpdateHealth()
    {
        foreach (HealthManager.DamageTypes type in health)
        {

        }
    }
}
