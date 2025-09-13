using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class ConversationSystem : MonoBehaviour
{
    [SerializeField] CanvasGroup canvasGroup;
    [SerializeField] TextMeshProUGUI sentenceLabel;
    [SerializeField] float typingSpeed = 0.05f;
    [SerializeField] float fadeDuration = .5f;

    int currentSentence = 0;
    string[] sentences;
    bool continueConversation = false;


    void Awake()
    {
        sentenceLabel.text = "";
        canvasGroup.alpha = 0;
        ToggleInteractable(false);
    }

    public void StartConversation(string[] sentences)
    {
        this.sentences = sentences;
        StopAllCoroutines();
        StartCoroutine(HandleConversation());
    }

    IEnumerator HandleConversation()
    {
        ToggleInteractable(true);
        yield return FadeCanvasAlpha(0f, 1f);

        sentenceLabel.text = "";
        currentSentence = 0;

        while (currentSentence < sentences.Length)
        {
            yield return StartCoroutine(ShowSentence(sentences[currentSentence]));
            yield return WaitForPlayerInput();
            currentSentence++;
        }

        yield return FadeCanvasAlpha(1f, 0f);
        ToggleInteractable(false);
    }

    void ToggleInteractable(bool interactable)
    {
        canvasGroup.blocksRaycasts = interactable;
        canvasGroup.interactable = interactable;
    }

    IEnumerator ShowSentence(string sentence)
    {
        sentenceLabel.text = "";
        foreach (char letter in sentence)
        {
            // TODO::
            // We can play audio here if we want some typing sound

            sentenceLabel.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        // TODO::
        // We can enable some continue visual here if needed
    }

    IEnumerator WaitForPlayerInput()
    {
        continueConversation = false;

        while (!continueConversation)
        {
            yield return null;
        }

        continueConversation = false;
    }

    public void OnContinueClicked() => continueConversation = true;

    IEnumerator FadeCanvasAlpha(float from, float to)
    {
        float elapsed = 0f;
        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(from, to, elapsed / fadeDuration);
            yield return null;
        }

        canvasGroup.alpha = to;
    }
}
