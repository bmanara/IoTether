using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    public TMP_Text pointsText;

    public void Setup(int score)
    {
        gameObject.SetActive(true);
        pointsText.text = "Score: " + score.ToString();
    }

    // For now, this implementation works... kind of
    public void RestartGame()
    {
        // TODO: Use SceneManager to reload the game scene instead
        SceneManager.LoadScene("BrianScene");
    }

    public void MainMenu()
    {
        // TODO: Use SceneManager to load the main menu scene instead
        SceneManager.LoadScene("StartMenuScene");
    }
}
