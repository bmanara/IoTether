using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PerkPanelController : MonoBehaviour
{
    public GameObject perkPanel;
    public List<Button> perkButtons;
    public Button confirmButton;
    public TextMeshProUGUI selectedPerkText;

    private string selectedPerk;
    private GameObject droppedPerk;

    private bool hasPerk = false;
    // Start is called before the first frame update
    void Start()
    {
        perkPanel.SetActive(false);

        foreach (Button button in perkButtons)
        {
            button.onClick.AddListener(() => OnPerkButtonClicked(button));
        }
        confirmButton.onClick.AddListener(ConfirmSelection);

        UIManager.manager.onDialogueFinish += DisplayPerkPanel;
        
    }


    private void OnDisable()
    {
        Debug.Log("unsubscribed to onDialogueFinish");
        UIManager.manager.onDialogueFinish -= DisplayPerkPanel;
    }
    
    public void DisplayPerkPanel()
    {
        if (!hasPerk)
        {
            hasPerk = true;
            Debug.Log("Displaying Perk Selection Panel.");
            if (perkPanel == null)
            {
                Debug.LogError("perkPanel is null!");
                return;
            }

            perkPanel.SetActive(true);
            GameManager.manager.PauseGame();
            Debug.Log("Perk Panel should now be visible.");

        }
        
    }
    void OnPerkButtonClicked(Button clickedButton)
    {
        selectedPerk = clickedButton.GetComponentInChildren<TextMeshProUGUI>().text;
        selectedPerkText.text = "Selected Perk: " + selectedPerk;
        droppedPerk = clickedButton.GetComponent<PerkButton>().droppedPerk;
    }

    [ContextMenu("Open Perk Panel")]
    public void OpenPerkPanel()
    {
        perkPanel.SetActive(true);
    }

    void ConfirmSelection()
    {
        if (!string.IsNullOrEmpty(selectedPerk))
        {
            Debug.Log("Selected Perk: " + selectedPerk);
            perkPanel.SetActive(false);
            GameObject player = GameObject.Find("Player");
            GameManager.manager.UnpauseGame();
            Instantiate(droppedPerk, player.transform.position + Vector3.down, Quaternion.identity);    
        } 
        else
        {
            Debug.Log("No perk selected");
            selectedPerkText.text = "No perk selected";
        }
    }

}
