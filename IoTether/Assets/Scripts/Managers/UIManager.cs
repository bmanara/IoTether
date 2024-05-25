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

    public TMP_Text nameText;
    public TMP_Text dialogueText;
    public Animator dialogueAnimator;
    private float typingSpeed = 0.02f;

    private Queue<string> sentences;

    private void Awake()
    {
        manager = this;
        sentences = new Queue<string>();
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
        gameOverMenu.SetActive(true);
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
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines(); // Allow user to skip dialogue
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSecondsRealtime(typingSpeed);
        }
    }

    void EndDialogue()
    {
        Time.timeScale = 1; // Unpause game after dialogue
        dialogueAnimator.SetBool("isOpen", false);
    }
}
