using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAreaTracker : MonoBehaviour
{
    private HashSet<GameObject> enemiesInArea = new HashSet<GameObject>();
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            enemiesInArea.Add(collision.gameObject);
            Debug.Log("Enemy entered area. Current Count: " + enemiesInArea.Count);
        }
    }
    
   public int GetEnemyCount()
    {
        return enemiesInArea.Count; 
    }
}
