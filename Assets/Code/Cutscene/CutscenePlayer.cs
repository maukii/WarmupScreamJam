using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CutscenePlayer : MonoBehaviour
{
    [SerializeField] Image backgroundImage;
    [SerializeField] Image overlayImage;
    [SerializeField] TextMeshProUGUI dialogueText;
    [SerializeField] CutsceneSequence sequence;
    [SerializeField] AudioClip textWritingAudioClip;
    [SerializeField] CanvasGroup conversationCanvasGroup;
    [SerializeField] Image customerImage;
    [SerializeField] CanvasGroup customerCanvasGroup;


    void Start() => StartCoroutine(PlaySequence());

    IEnumerator PlaySequence()
    {
        foreach (var step in sequence.steps)
        {
            yield return step.Play(this);
        }
    }

    public IEnumerator TypeText(string text, float typingSpeed)
    {
        dialogueText.text = "";
        foreach (char c in text)
        {
            dialogueText.text += c;
            AudioSource.PlayClipAtPoint(textWritingAudioClip, Vector3.zero);
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void ClearDialogue() => dialogueText.text = "";

    public IEnumerator ShowOverlay(Sprite sprite, bool animate = false)
    {
        overlayImage.sprite = sprite;
        overlayImage.enabled = true;

        if (animate)
        {
            // TODO: add tween/lerp for smooth entrance
            yield return null;
        }
    }

    public IEnumerator HideOverlay(bool animate = false)
    {
        if (animate)
        {
            // TODO: add tween/lerp for smooth exit
            yield return null;
        }

        overlayImage.enabled = false;
        overlayImage.sprite = null;
    }

    public IEnumerator ChangeBackground(Sprite sprite, bool animate = false, float duration = 1f)
    {
        backgroundImage.sprite = sprite;

        if (animate)
        {
            Color startColor = Color.black;
            Color endColor = Color.white;
            float t = 0f;
            while (t < duration)
            {
                t += Time.deltaTime;
                float normalized = Mathf.Clamp01(t / duration);
                backgroundImage.color = Color.Lerp(startColor, endColor, normalized);
                yield return null;
            }

            yield return null;
        }
    }

    public IEnumerator CustomerEnter(Sprite sprite, float duration = 1f)
    {
        customerImage.sprite = sprite;
        customerImage.enabled = true;

        yield return FadeCanvasAlpha(customerCanvasGroup, 0f, 1f, duration);
    }

    public IEnumerator CustomerExit(float duration = 1f)
    {
        yield return FadeCanvasAlpha(customerCanvasGroup, 1f, 0f, duration);
        customerImage.enabled = false;
        customerImage.sprite = null;
    }

    public IEnumerator ToggleConversationUI(bool state, float duration = 1f, bool clearDialogue = false)
    {
        if (clearDialogue) ClearDialogue();

        var from = state ? 0f : 1f;
        var to = state ? 1f : 0f;
        yield return FadeCanvasAlpha(conversationCanvasGroup, from, to, duration);
    }

    IEnumerator FadeCanvasAlpha(CanvasGroup canvasGroup, float from, float to, float fadeDuration = 1f)
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
