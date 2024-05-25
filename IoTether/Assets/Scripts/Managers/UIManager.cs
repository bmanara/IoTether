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
        dialogueText.text = sentence;
    }

    void EndDialogue()
    {
        dialogueAnimator.SetBool("isOpen", false);
    }
}
