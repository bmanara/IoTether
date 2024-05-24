using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomClearLogic : MonoBehaviour
{
    private GameObject Closed;
    private GameObject Opened;
    public Transform enemiesInRoom;
    // Start is called before the first frame update
    void Start()
    {
        Closed = gameObject.transform.GetChild(0).gameObject;
        Opened = gameObject.transform.GetChild(1).gameObject;
        Close();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemiesInRoom.childCount == 0)
        {
            Open();
        }   
        
    }

    private void Close()
    {
        Closed.SetActive(true);
        Opened.SetActive(false);
    }

    private void Open()
    {
        Closed.SetActive(false);
        Opened.SetActive(true);
    }
}
