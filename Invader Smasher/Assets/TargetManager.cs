using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
    public static TargetManager instance;

    GameObject target;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if(target == null)
        {
            target = FindObjectOfType<EnemyHealth>().gameObject;
            foreach(EnemyHealth enemy in FindObjectsOfType<EnemyHealth>())
            {
                if(target.transform.position.y > enemy.transform.position.y)
                {
                    target = enemy.gameObject;
                }
            }
            target.GetComponent<EnemyHealth>().SelectedAsTarget();
        }
    }

    public GameObject GetTarget()
    {
        return target;
    }
}
