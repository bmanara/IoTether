using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomClearLogic : MonoBehaviour
{
    private GameObject Closed;
    private GameObject Opened;
    private bool isOpen = false;
    public Transform enemiesInRoom;
    public bool finalDoor = false;
    
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

    [ContextMenu("Close")]
    private void Close()
    {
        Closed.SetActive(true);
        Opened.SetActive(false);
        isOpen = false;
    }
    [ContextMenu("Open")]
    private void Open()
    {
        Closed.SetActive(false);
        Opened.SetActive(true);
       // Debug.Log("Door Opened");
        isOpen = true;
    }

    private void LoadScene()
    {
        GameManager.manager.NextLevel();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && finalDoor && isOpen)
        {
            Debug.Log("Player walked through door");
            LoadScene();
        }
    }
}
