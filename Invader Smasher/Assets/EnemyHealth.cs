using System.Collections.Generic;
using UnityEditor.iOS;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] Sprite selectedSprite, unselectedSprite;
    [SerializeField] int healthAmount;
    [SerializeField] List<HealthManager.DamageTypes> healthTypesUsed;
    [SerializeField] Canvas canvas;
    [SerializeField] GameObject damageTypePrefab, deathParticles;

    bool selected;

    int damageTaken = 0;
    List<GameObject> damageObjs = new List<GameObject>();
    List<HealthManager.DamageTypes> health = new List<HealthManager.DamageTypes>();

    private void Start()
    {
        SetupStartingHealth();
        
        UpdateHealth();
    }

    private void SetupStartingHealth()
    {
        for (int i = 0; i < healthAmount; i++)
        {
            health.Add(healthTypesUsed[Random.Range(0, healthTypesUsed.Count)]);
        }

        for (int i = 0; i < health.Count; i++)
        {
            damageObjs.Add(Instantiate(damageTypePrefab, canvas.transform));
        }

        float widthBetweenHealth = 2.7f;
        float fullWidh = (damageObjs.Count - 1) * widthBetweenHealth;
        for (int i = 0; i < damageObjs.Count; i++)
        {
            damageObjs[i].GetComponent<RectTransform>().localPosition = new Vector2(-(fullWidh / 2f) + (i * widthBetweenHealth) , 6.25f);
        }
    }

    public void SelectedAsTarget()
    {
        GetComponent<SpriteRenderer>().sprite = selectedSprite;
        selected = true;
        UpdateHealth();
    }

    public HealthManager.DamageTypes GetCurrentHealth()
    {
        return health[damageTaken];
    }

    internal void ResetHealth()
    {
        damageTaken = 0;
        UpdateHealth();
    }

    public void RemoveCurrentHealth()
    {
        damageTaken++;
        if(damageTaken == health.Count)
        {
            EnemyDefeated();
        }
        UpdateHealth();
    }

    public void EnemyDefeated()
    {
        GameObject particles = Instantiate(deathParticles, transform.position, Quaternion.identity, null) as GameObject;
        Destroy(particles, 2f);
        Destroy(gameObject);
    }

    void UpdateHealth()
    {
        float notSelectedSize = 2f, selectedSize = 3f;
        float size = selected ? selectedSize : notSelectedSize;
        for (int i = 0; i < damageObjs.Count; i++)
        {
            damageObjs[i].GetComponent<Image>().sprite = HealthManager.instance.GetDamageSprite(health[i], selected);
            damageObjs[i].GetComponent<RectTransform>().sizeDelta = new Vector2(size, size);
            if (i >= damageTaken)
            {
                
                damageObjs[i].GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
            }
            else
            {
                damageObjs[i].GetComponent<Image>().color = new Color(1f, 1f, 1f, 0.75f);
            }
        }
    }
}
