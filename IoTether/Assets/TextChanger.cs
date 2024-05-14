using System.Collections;
using TMPro;
using UnityEngine;

public class TextChanger : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro; // Reference to the TextMeshPro component
    public float changeInterval = 5f; // Time in seconds between text changes

    private void Start()
    {
        if (textMeshPro == null)
        {
            Debug.LogError("TextMeshPro component not assigned.");
            return;
        }

        StartCoroutine(ChangeTextPeriodically());
    }

    private IEnumerator ChangeTextPeriodically()
    {
        while (true) // Infinite loop to keep changing the text
        {
            yield return new WaitForSeconds(changeInterval);

            // Change the text here
            textMeshPro.text = GetNewText();
        }
    }

    private string GetNewText()
    {
        // Return the new text you want to display
        // This could be random text, a message from an array, etc.
        // For simplicity, let's just alternate between two messages
        if (textMeshPro.text == "Welcome!")
        {
            return "Select any gun to get started!";
        }
        else
        {
            return "Welcome!";
        }
    }
}
