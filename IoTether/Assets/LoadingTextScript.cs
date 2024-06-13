using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoadingTextScript : MonoBehaviour
{
    public TextMeshProUGUI loadingText;

    private void Start()
    {
        StartCoroutine(LoadingText());
    }

    //Doesn't exactly work when loading times are less than 0.1f but might work eventually lol
    IEnumerator LoadingText()
    {
        float elapsedTime = 0f;
        while (true)
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime >= 0.1f)
            {
                loadingText.text = "Now Loading.";
            }
            if (elapsedTime >= 0.2f)
            {
                loadingText.text = "Now Loading..";
            }
            if (elapsedTime >= 0.3f)
            {
                loadingText.text = "Now Loading...";
                elapsedTime = 0f;
            }
            yield return null;
        }
    }
}
