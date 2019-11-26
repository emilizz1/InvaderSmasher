using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] List<HealthManager.DamageTypes> health;
    [SerializeField] Canvas canvas;
    [SerializeField] GameObject damageTypePrefab;

    bool selected;

    List<GameObject> damageObjs = new List<GameObject>();

    private void Start()
    {
        print(health.Count);
        for (int i = 0; i < health.Count; i++)
        {
            print(i);
            damageObjs.Add( Instantiate(damageTypePrefab, canvas.transform));
        }
        UpdateHealth();
    }

    public void SelectedAsTarget()
    {
        selected = true;
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
        float fullWidh = (damageObjs.Count - 1) * 3f;
        float size = selected ? 1.5f : 2.5f;
        for (int i = 0; i < damageObjs.Count; i++)
        {
            if(health.Count < i)
            {
                damageObjs[i].GetComponent<Image>().sprite = HealthManager.instance.GetDamageSprite(health[i], selected);
                damageObjs[i].GetComponent<RectTransform>().sizeDelta = new Vector2(size, size);
                damageObjs[i].GetComponent<RectTransform>().anchoredPosition = new Vector2((fullWidh / 2f) + 3f * i, 6.25f);
            }
            else
            {
                damageObjs.Remove(damageObjs[i]);
            }
        }
    }
}
