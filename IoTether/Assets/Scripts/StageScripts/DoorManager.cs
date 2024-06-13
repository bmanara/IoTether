using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorManager : MonoBehaviour
{
    private GameObject Closed;
    private GameObject Opened;
    private bool isOpen = false;
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
        if (enemiesInRoom.childCount == 0 && !isOpen) // Only opens once
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
        PlayAdaptiveText();
       
    }

    private void PlayAdaptiveText()
    {
        UIManager.manager.EnableAdaptiveText();
        UIManager.manager.ChangeText("Room Cleared!");
        UIManager.manager.ChangeTextColour(new Color32(0, 255, 0, 255));
        StartCoroutine(UIManager.manager.FadeText(true, 0.7f, 0.3f));
    }

    public bool checkOpen()
    {
        return isOpen;
    }

}
