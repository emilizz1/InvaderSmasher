using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] float moveSpeed;

    Vector3 moveStep;

    private void Start()
    {
        moveStep = new Vector3(0f, -moveSpeed, 0f);
    }

    void Update()
    {
        transform.position += moveStep * Time.deltaTime;
    }
}
