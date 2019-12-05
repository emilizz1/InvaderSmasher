using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthCollider : MonoBehaviour
{

    [SerializeField] PlayerHealth health;

    void Start()
    {
        if(health == null)
        {
            health = FindObjectOfType<PlayerHealth>();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<EnemyHealth>())
        {
            collision.GetComponent<EnemyHealth>().EnemyDefeated();
            health.RemoveHealth();
        }
    }
}
