using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float spawnTime;
    [SerializeField] List<GameObject> enemies;

    private void Start()
    {
        StartCoroutine(Spawning());
    }

    IEnumerator Spawning()
    {
        while (enemies.Count != 0)
        {
            Spawn();
            yield return new WaitForSeconds(spawnTime);
        }
    }

    void Spawn()
    {
        if (enemies.Count != 0)
        {
            GameObject enemyToSpawn = enemies[Random.Range(0, enemies.Count)];
            Bounds enemyBounds = enemyToSpawn.GetComponent<SpriteRenderer>().bounds;
            Vector3 screenCornerPos = Camera.main.ViewportToWorldPoint(Vector3.one);
            float spawnX = screenCornerPos.x - enemyBounds.size.x;
            Vector3 enemyPos = new Vector3(Random.Range(-spawnX, spawnX), screenCornerPos.y + enemyBounds.size.y);
            Instantiate(enemyToSpawn, enemyPos, Quaternion.identity, transform);
        }
    }
}
