using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    Transform target;
    float movementSpeed = 0f, speedUp = 0.05f, startingDistanceToTarget;
    float lastPos;

    private void Update()
    {
        if (target != null)
        {
            PerformMovement();
            PerformRotation();
        }
    }

    private void PerformRotation()
    {
        float differenceInMovement = transform.position.x - lastPos;
        lastPos = transform.position.x;
        float lerp = Mathf.Clamp(movementSpeed, 0, 4f) / 4f;
        float targetPos = differenceInMovement > 0 ? -30f : 30f;
        transform.eulerAngles = new Vector3(0f, 0f, Mathf.LerpAngle(0, targetPos, lerp));
    }

    private void PerformMovement()
    {
        float distanceToTarget = Mathf.Abs(target.position.x - transform.position.x);
        if (distanceToTarget > 0.01f)
        {
            if (distanceToTarget <= startingDistanceToTarget / 3f)
            {
                movementSpeed -= speedUp * 2f;
            }
            else
            {
                movementSpeed += speedUp;
            }
            movementSpeed = Mathf.Clamp(movementSpeed, 0f, 100f);
            transform.position = new Vector3(Mathf.MoveTowards(transform.position.x, target.position.x, movementSpeed * Time.deltaTime), transform.position.y, transform.position.z);
        }
        else
        {
            movementSpeed = 0f;
        }
    }

    public void SetNewTarget(GameObject target)
    {
        this.target = target.transform;
        movementSpeed = 0f;
        startingDistanceToTarget = Mathf.Abs(this.target.position.x - transform.position.x);
    }
}
