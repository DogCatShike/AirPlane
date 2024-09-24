using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("MyGame / EnemySpawn")]
public class EnemySpawn : MonoBehaviour
{
    public Transform m_enemyPrefab;

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(5, 15));
            Instantiate(m_enemyPrefab, transform.position, Quaternion.identity);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawIcon(transform.position, "item.png", true);
    }
}
