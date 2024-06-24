using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PerkSelectManager : MonoBehaviour
{
    public GameObject perkPanel;
    public List<Button> perkButtons;
    public Button confirmButton;
    public TextMeshProUGUI selectedPerkText;

    private string selectedPerk;
    private GameObject droppedPerk;
    // Start is called before the first frame update
    void Start()
    {
        perkPanel.SetActive(false);

        foreach (Button button in perkButtons)
        {
            button.onClick.AddListener(() => OnPerkButtonClicked(button));
        }
        confirmButton.onClick.AddListener(ConfirmSelection);
        
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
            Instantiate(droppedPerk, Vector3.zero, Quaternion.identity);    
        } 
        else
        {
            Debug.Log("No perk selected");
        }
    }

}
