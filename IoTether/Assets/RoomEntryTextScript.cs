using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class RoomEntryTextScript : MonoBehaviour
{
    public TextMeshProUGUI text;
    public float fadeDuration = 1f;
    public float displayDuration = 2f;

    private CanvasGroup canvasGroup;
    private Coroutine fadeCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        canvasGroup = text.GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = text.gameObject.AddComponent<CanvasGroup>();
        }

        canvasGroup.alpha = 0f;
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (fadeCoroutine != null)
            {
                StopCoroutine(fadeCoroutine);
            }
            fadeCoroutine = StartCoroutine(FadeText(true));
        }
    }


    private IEnumerator FadeText(bool fadeIn)
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
            fadeCoroutine = StartCoroutine(FadeText(false));
        }
    }
}
