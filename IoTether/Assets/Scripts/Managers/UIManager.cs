using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager manager { get; private set; }

    public HealthBarController healthBar;
    public EnergyBarController energyBar;
    public GameObject UIBar;
    public GameObject gameOverMenu;
    public GameObject pickUpPanel;
    public GameObject interactPanel;
    public GameObject pauseMenu;

    public TMP_Text nameText;
    public TMP_Text dialogueText;
    public Animator dialogueAnimator;
    private float typingSpeed = 0.02f;
    private bool isTyping = false;
    private string previousSentence = "";

    public TextMeshProUGUI roomText;
    private CanvasGroup canvasGroup;

    private Queue<string> sentences;

    public GameObject LoadingScreen;

    private void Awake()
    {
        
        sentences = new Queue<string>();
        if (manager != null)
        {
            Destroy(this.gameObject);
            return;
        }
        manager = this;
        GameObject.DontDestroyOnLoad(this.gameObject);

        canvasGroup = roomText.GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = roomText.gameObject.AddComponent<CanvasGroup>();
        }

        canvasGroup.alpha = 0f; // initialise text to invisible at the start of the game
        EnterScene();
    }

    [ContextMenu("Enter Scene")]
    public void EnterScene()
    {
        UIBar.SetActive(true);

        LoadingScreen.SetActive(false);
    }

    [ContextMenu("Enter Load")]
    public void EnterLoad()
    {
        UIBar.SetActive(false);

        LoadingScreen.SetActive(true);
    }


    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        EnterScene();
        Debug.Log("Scene loaded: " + scene.name);
    }



    public void DestroySelf()
    {
        Destroy(gameObject);
        manager = null;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseMenu.activeSelf)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    void Resume()
    {
        pauseMenu.SetActive(false);
        GameManager.manager.UnpauseGame();
    }

    private void Pause()
    {
        pauseMenu.SetActive(true);
        GameManager.manager.PauseGame();
    }

    private void OnEnable()
    {
        GameManager.OnGameOver += EnableGameOverMenu;
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        throw new System.NotImplementedException();
    }

    private void OnDisable()
    {
        GameManager.OnGameOver -= EnableGameOverMenu;
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void EnableGameOverMenu()
    {
        gameOverMenu
            .GetComponent<GameOverController>()
            .Setup(GameManager.manager.GetScore());
    }

    public void SetMaxHealth(int maxHealth)
    {
        healthBar.SetMaxHealth(maxHealth);
    }

    public void SetHealth(int health)
    {
        healthBar.SetHealth(health);
    }

    public void SetMaxEnergy(int maxEnergy)
    {
        energyBar.SetMaxEnergy(maxEnergy);
    }

    public void SetEnergy(int energy)
    {
        energyBar.SetEnergy(energy);
    }

    public void StartDialogue(Dialogue dialogue)
    {
        GameManager.manager.PauseGame(); // Pause game during dialogue
        dialogueAnimator.SetBool("isOpen", true);

        nameText.text = dialogue.name;

        sentences.Clear(); // Clear the queue

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (isTyping)
        {
            StopAllCoroutines(); // Allow user to skip dialogue
            dialogueText.text = previousSentence;
            isTyping = false;
            return;
        }

        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        
        string sentence = sentences.Dequeue();
        previousSentence = sentence;
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        isTyping = true;
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSecondsRealtime(typingSpeed);
        }
        isTyping = false;
    }

    void EndDialogue()
    {
        GameManager.manager.UnpauseGame(); // Unpause game after dialogue
        dialogueAnimator.SetBool("isOpen", false);
    }

    public void EnablePickUpPanel()
    {
        pickUpPanel.SetActive(true);
    }

    public void DisablePickUpPanel()
    {
        pickUpPanel.SetActive(false);
    }

    public void EnableInteractPanel()
    {
        interactPanel.SetActive(true);
    }

    public void DisableInteractPanel() 
    {         
        interactPanel.SetActive(false);
    }


    // Room Adaptive text methods

    public void EnableAdaptiveText()
    {
        roomText.gameObject.SetActive(true);
    }

    public IEnumerator FadeText(bool fadeIn, float fadeDuration, float displayDuration)
    {
        float startAlpha = canvasGroup.alpha;
        float endAlpha = fadeIn ? 1f : 0f;
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / fadeDuration);
            yield return null;
        }
        canvasGroup.alpha = endAlpha;

        if (fadeIn)
        {
            yield return new WaitForSeconds(displayDuration);
            StartCoroutine(FadeText(false, fadeDuration, displayDuration));
        }
    }

    public void ChangeText(string newText)
    {
        roomText.text = newText;
    }

    public void ChangeTextColour(Color newColour)
    {
        roomText.color = newColour;
    }
}
