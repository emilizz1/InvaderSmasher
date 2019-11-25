using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageButton : MonoBehaviour
{
    [SerializeField] HealthManager.DamageTypes damageType;

    public void ButtonPressed()
    {
        HealthManager.instance.DealDamage(damageType);
    }
}
