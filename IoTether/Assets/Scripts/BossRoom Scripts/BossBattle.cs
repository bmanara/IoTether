using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBattle : MonoBehaviour
{
    [SerializeField] private BossTrigger bossTrigger;
    [SerializeField] private Enemy enemy;
    
    private void Start()
    {
        bossTrigger.OnPlayerEnterTrigger += BossTrigger_OnPlayerEnterTrigger;
    }

    private void BossTrigger_OnPlayerEnterTrigger(object sender, System.EventArgs e)
    {
        StartBattle();
        // Stop subscribing to event once battle starts
        bossTrigger.OnPlayerEnterTrigger -= BossTrigger_OnPlayerEnterTrigger;
    }

    private void StartBattle()
    {
        Debug.Log("Boss Battle Started");
        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        Instantiate(enemy, transform.position + new Vector3(20, 0), Quaternion.identity);
    }
}
