using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PauseMenuController : MonoBehaviour
{
    public static PauseMenuController controller { get; private set; }

    [SerializeField] private Button _resumeButton;
    [SerializeField] private Button _quitButton;
    [SerializeField] private Button _mainMenuButton;
    [SerializeField] private GameObject _confirmDialog;  // Reference to the confirmation dialog
    [SerializeField] private TextMeshProUGUI _confirmMessage;       // Reference to the confirmation message text
    [SerializeField] private Button _confirmButton;
    [SerializeField] private Button _cancelButton;
    [SerializeField] private GameObject _mainOptionsScreen; // Reference to the main options screen
    [SerializeField] private GameObject _optionsScreen;

    private System.Action _confirmAction;        // Action to store the confirm action

    private void Awake()
    {
        // Singleton Pattern
        if (controller != null && controller != this)
        {
            Destroy(this);
        }
        else
        {
            controller = this;
        }

        DontDestroyOnLoad(controller);
    }

    private void Start()
    {
        _resumeButton.onClick.AddListener(ResumeGame);
        _quitButton.onClick.AddListener(ShowQuitConfirmation);
        _mainMenuButton.onClick.AddListener(ShowMainMenuConfirmation);
        _confirmButton.onClick.AddListener(ConfirmSelection);
        _cancelButton.onClick.AddListener(CancelSelection);

        _confirmDialog.SetActive(false);         // Ensure the confirmation dialog is initially inactive
        _mainOptionsScreen.SetActive(true);      // Ensure the main options screen is initially active
    }

    public void ResumeGame()
    {
        UIManager.manager.pauseMenu.SetActive(false);
        GameManager.manager.UnpauseGame();
        ResetPauseMenu();  // Reset the pause menu when resuming the game
    }

    public void QuitGame()
    {
        Debug.Log("Quit game");
        Application.Quit();
    }

    public void LaunchMenu()
    {
        GameManager.manager.PauseGame();
        GameManager.manager.LoadStartMenu();
        ResetPauseMenu();  // Reset the pause menu when launching the main menu
    }

    void ShowQuitConfirmation()
    {
        ShowConfirmationDialog("DO YOU WANT TO QUIT?", QuitGame);
    }

    void ShowMainMenuConfirmation()
    {
        ShowConfirmationDialog("RETURN TO THE MAIN MENU?", LaunchMenu);
    }

    void ShowConfirmationDialog(string message, System.Action confirmAction)
    {
        _confirmMessage.text = message;
        _confirmAction = confirmAction;
        _confirmDialog.SetActive(true);
    }

    void ConfirmSelection()
    {
        _confirmAction?.Invoke();
        _confirmDialog.SetActive(false);
    }

    void CancelSelection()
    {
        _confirmDialog.SetActive(false);
    }

    public void ResetPauseMenu()
    {
        _mainOptionsScreen.SetActive(true);  // Ensure the main options screen is shown
        _confirmDialog.SetActive(false);     // Ensure the confirmation dialog is hidden
        _optionsScreen.SetActive(false);     // Ensure the options screen is hidden
    }
}