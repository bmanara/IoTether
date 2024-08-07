using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBattle : MonoBehaviour
{
    [SerializeField] private BossTrigger bossTrigger;
    [SerializeField] private Enemy enemy;
    [SerializeField] public GameObject boss;

    private List<Vector3> spawnPositions;
    public float spawnRate = 5f;
    private bool isBattleActive = false;

    private void Awake()
    {
        spawnPositions = new List<Vector3>();
        foreach (Transform spawnPosition in transform.Find("Spawn Positions"))
        {
            spawnPositions.Add(spawnPosition.position);
        }
    }

    private void Start()
    {
        bossTrigger.OnPlayerEnterTrigger += BossTrigger_OnPlayerEnterTrigger;
        GameManager.OnGameOver += HandleGameOver;
    }

    private void OnDestroy()
    {
        bossTrigger.OnPlayerEnterTrigger -= BossTrigger_OnPlayerEnterTrigger;
        GameManager.OnGameOver -= HandleGameOver;
    }

    private void BossTrigger_OnPlayerEnterTrigger(object sender, System.EventArgs e)
    {
        StartBattle();
        // Stop subscribing to event once battle starts
        bossTrigger.OnPlayerEnterTrigger -= BossTrigger_OnPlayerEnterTrigger;
    }

    private void StartBattle()
    {
        isBattleActive = true;
        Debug.Log("Boss Battle Started");
        InvokeRepeating("SpawnEnemy", 2f, spawnRate);
        boss.GetComponent<Animator>().SetTrigger("isActive");
        UIManager.manager.ActivateBossHealthBar();
        AudioManager.manager.PlayMusic("Boss");
    }

    public void StopBattle()
    {
        if(!isBattleActive) return;
        isBattleActive = false;
        CancelInvoke("SpawnEnemy");
        UIManager.manager.DeactivateBossHealthBar();
        AudioManager.manager.PlayMusic("Background");
    }

    private void SpawnEnemy()
    {
        if(!isBattleActive) return;

        Vector3 spawnPosition = spawnPositions[Random.Range(0, spawnPositions.Count)];
        Instantiate(enemy, spawnPosition, Quaternion.identity);
    }

    private void HandleGameOver()
    {
        StopBattle();
        bossTrigger.DisableTrigger();
    }
}
