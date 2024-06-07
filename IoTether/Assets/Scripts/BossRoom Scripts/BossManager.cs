using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : MonoBehaviour
{
    private GameObject TriggerBox;
    private BossTrigger bossTrigger;

    private GameObject Open;
    private GameObject Close;
    // Start is called before the first frame update
    void Start()
    {
        Open = gameObject.transform.GetChild(0).gameObject;
        Close = gameObject.transform.GetChild(1).gameObject;
        TriggerBox = gameObject.transform.parent.GetChild(0).gameObject;
        bossTrigger = TriggerBox.GetComponent<BossTrigger>();

        Open.SetActive(true);
        Close.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (bossTrigger.isBossTriggered())
        {
            Open.SetActive(false);
            Close.SetActive(true);
        }
        
    }
}
