using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
    public static TargetManager instance;

    GameObject target;
    ShipMovement shipMovement;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        shipMovement = FindObjectOfType<ShipMovement>();
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
            shipMovement.SetNewTarget(target);
            target.GetComponent<EnemyHealth>().SelectedAsTarget();
        }
    }

    public GameObject GetTarget()
    {
        return target;
    }
}
