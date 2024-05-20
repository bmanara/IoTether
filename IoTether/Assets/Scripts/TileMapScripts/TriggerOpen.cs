using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TriggerOpen : MonoBehaviour
{
    private GameObject Door;
    [SerializeField]
    private Transform enemiesInRoom;
    private bool RoomClear = false;

    private void Start()
    {
        Door = gameObject;
    }


    //if number of enemies = 0 then change to true
    private void Update()
    {
        if (enemiesInRoom != null)
        {
            Debug.Log("enemies:" + enemiesInRoom.childCount);
        }

        if (enemiesInRoom.childCount == 0)
        {
            RoomClear = true;
            Open(); 
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
