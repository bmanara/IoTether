using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TriggerOpen : MonoBehaviour
{
    private GameObject Door;
    [SerializeField]
    private Transform enemiesInRoom;
    private bool RoomClear = false;

    private void Awake()
    {
        Door = gameObject;
    }


    //if number of enemies = 0 then change to true
    private void Update()
    {

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
        Debug.Log("Door Opened");

    }

    [ContextMenu("Close")]
    private void Close()
    {
        Door.SetActive(true);

    }
}
