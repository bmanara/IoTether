using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager manager { get; private set; }

    public HealthBarController healthBar;
    public GameObject gameOverMenu;
    public GameObject pickUpPanel;
    public GameObject interactPanel;

    public TMP_Text nameText;
    public TMP_Text dialogueText;
    public Animator dialogueAnimator;
    private float typingSpeed = 0.02f;
    private bool isTyping = false;
    private string previousSentence = "";

    private Queue<string> sentences;

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
    }

    private void OnEnable()
    {
        GameManager.OnGameOver += EnableGameOverMenu;
    }

    private void OnDisable()
    {
        GameManager.OnGameOver -= EnableGameOverMenu;
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

    public void StartDialogue(Dialogue dialogue)
    {
        Time.timeScale = 0; // Pause game during dialogue
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
        Time.timeScale = 1; // Unpause game after dialogue
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
}
