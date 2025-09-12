using System.Collections;
using TMPro;
using UnityEngine;

public class ConversationSystem : MonoBehaviour
{
    [SerializeField] CanvasGroup canvasGroup;
    [SerializeField] TextMeshProUGUI sentenceLabel;
    [SerializeField] float typingSpeed = 0.05f;
    [SerializeField] float fadeDuration = .5f;
    [SerializeField] KeyCode skipSentenceWritingKey = KeyCode.Space;

    int currentSentence = 0;
    string[] sentences;


    void Start()
    {
        sentenceLabel.text = "";
        canvasGroup.alpha = 0;
    }

    public void StartConversation(string[] sentences)
    {
        this.sentences = sentences;
        StopAllCoroutines();
        StartCoroutine(HandleConversation());
    }

    IEnumerator HandleConversation()
    {
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
    }

    IEnumerator ShowSentence(string sentence)
    {
        sentenceLabel.text = "";
        foreach (char letter in sentence)
        {
            // TODO::
            // We can play audio here if we want some typing sound

            if (Input.GetKeyDown(skipSentenceWritingKey))
            {
                sentenceLabel.text = sentence;
                break;
            }

            sentenceLabel.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    IEnumerator WaitForPlayerInput()
    {
        while (!Input.GetMouseButtonDown(0))
        {
            yield return null;
        }
    }

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
