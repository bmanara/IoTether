using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDoor : MonoBehaviour
{

    private GameObject Open;
    private GameObject Close;

    [SerializeField] private BossTrigger bossTrigger;

    // Start is called before the first frame update
    void Start()
    {
        Open = gameObject.transform.GetChild(0).gameObject;
        Close = gameObject.transform.GetChild(1).gameObject;

        Open.SetActive(true);
        Close.SetActive(false);

        bossTrigger.OnPlayerEnterTrigger += BossTrigger_OnPlayerEnterTrigger;
    }

    private void BossTrigger_OnPlayerEnterTrigger(object sender, System.EventArgs e)
    {
        CloseRoom();
        // Stop subscribing to event once battle starts
        bossTrigger.OnPlayerEnterTrigger -= BossTrigger_OnPlayerEnterTrigger;
    }

    public void CloseRoom()
    {
        Open.SetActive(false);
        Close.SetActive(true);
    }
}
