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

    //FadeText fields
    private float fadeDuration = 0.7f;
    private float displayDuration = 0.3f;
    
    // Start is called before the first frame update
    void Start()
    {
        Closed = gameObject.transform.GetChild(0).gameObject;
        Opened = gameObject.transform.GetChild(1).gameObject;
        Close();
        
    }

    public bool canOpen()
    {
        return enemiesInRoom.childCount == 0 && !isOpen;
    }

    // Update is called once per frame
    public void Update()
    {
        if (canOpen()) // Only opens once
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
    protected virtual void Open()
    {
        Closed.SetActive(false);
        Opened.SetActive(true);
       // Debug.Log("Door Opened");
        isOpen = true;
        PlayAdaptiveText();
       
    }

    protected virtual void PlayAdaptiveText()
    {
        Color green = new Color32(0, 255, 0, 255);
        UIManager.manager.PlayAdaptiveText("Room Cleared!", green, fadeDuration, displayDuration, 45);
    }

    public bool checkOpen()
    {
        return isOpen;
    }

}
