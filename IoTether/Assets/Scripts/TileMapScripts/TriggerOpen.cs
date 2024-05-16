using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TriggerOpen : MonoBehaviour
{
    private GameObject Door;
    [SerializeField]
    private GameObject TriggerBox;
    private EnemyAreaTracker enemyAreaTracker;
    bool enemiesDefeated = false;

    private void Start()
    {
        enemyAreaTracker = TriggerBox.GetComponent<EnemyAreaTracker>();

        Door = gameObject;

        if(enemyAreaTracker != null)
        {
            Debug.Log("enemies: " + enemyAreaTracker.GetEnemyCount());
        }
    }


    //if number of enemies = 0 then change to true
    private void Update()
    {
        if (enemyAreaTracker != null)
        {
            Debug.Log("enemies: " + enemyAreaTracker.GetEnemyCount());
        }

        if (enemyAreaTracker.GetEnemyCount() == 0)
        {
            enemiesDefeated = true;
            //Open(); - To be implemented once enemy collision bug is fixed 
        }
    }



    [ContextMenu("Open")]
    private void Open()
    {
        Door.SetActive(false);

    }

    [ContextMenu("Close")]
    private void Close()
    {
        Door.SetActive(true);

    }
}
