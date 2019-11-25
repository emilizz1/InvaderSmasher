using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
    GameObject target;

    private void Update()
    {
        if(target == null)
        {
            target = FindObjectOfType<EnemyMover>().gameObject;
            foreach(EnemyMover enemy in FindObjectsOfType<EnemyMover>())
            {
                if(target.transform.position.y > enemy.transform.position.y)
                {
                    target = enemy.gameObject;
                }
            }
            target.GetComponent<EnemyMover>().SelectedAsTarget();
        }
    }

    public GameObject GetTarget()
    {
        return target;
    }
}
