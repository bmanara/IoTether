using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAreaTracker : MonoBehaviour
{
    private HashSet<GameObject> enemiesInArea = new HashSet<GameObject>();
    private int enemyCount = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision.gameObject.name == "Player")
        {
            enemiesInArea.Add(collision.gameObject);
            enemyCount = enemiesInArea.Count;
            //Debug.Log("Enemy entered area. Current Count: " + enemiesInArea.Count);

        }
    }
    
   public int GetEnemyCount()
    {
        return enemyCount;
    }

    [ContextMenu("Reduce")]
    void ReduceCount()
    {
        enemyCount--;
    }
}
