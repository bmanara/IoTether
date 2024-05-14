using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextUpdateOnPosition : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro; // Reference to the TextMeshPro component
    public Transform character; // Reference to the character Transform
    public Vector3 targetPosition; // The position to trigger the text change
    public float threshold = 1f; // Distance threshold to consider the character has passed the coordinate

    private bool hasTextChanged = false;

    private void Update()
    {
        if (!hasTextChanged && Vector3.Distance(character.position, targetPosition) < threshold)
        {
            UpdateText();
            hasTextChanged = true; // Ensure text is changed only once
        }
    }

    private void UpdateText()
    {
        // Change the text here
        textMeshPro.text = "Select a Weapon to get started!";
    }
}
