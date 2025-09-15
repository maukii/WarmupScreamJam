using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CutscenePlayer : MonoBehaviour
{
    [SerializeField] bool skipWriting = false;
    [SerializeField] Image backgroundImage;
    [SerializeField] Image overlayImage;
    [SerializeField] TextMeshProUGUI dialogueText;
    [SerializeField] CutsceneSequence sequence;
    [SerializeField] AudioClip textWritingAudioClip;
    [SerializeField] CanvasGroup conversationCanvasGroup;
    [SerializeField] CanvasGroup fullscreenBlackCanvasGroup;
    [SerializeField] Image customerImage;
    [SerializeField] CanvasGroup customerCanvasGroup;
    [SerializeField] AudioSource audioSource;


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
        if (!skipWriting)
        {
            dialogueText.text = "";
            foreach (char c in text)
            {
                dialogueText.text += c;
                audioSource.pitch = Random.Range(0.85f, 1.15f);
                audioSource.PlayOneShot(textWritingAudioClip);
                yield return new WaitForSeconds(typingSpeed);
            }
        }

        dialogueText.text = text;
    }

    public void ClearDialogue() => dialogueText.text = "";

    public IEnumerator ShowOverlay(Sprite sprite, float duration)
    {
        overlayImage.transform.localScale = Vector3.zero;
        overlayImage.sprite = sprite;
        overlayImage.enabled = true;

        float time = 0f;
        Vector3 startScale = Vector3.zero;
        Vector3 endScale = Vector3.one;
        while (time < duration)
        {
            time += Time.deltaTime;
            float t = time / duration;
            t = 1f - Mathf.Pow(1f - t, 3f);

            overlayImage.transform.localScale = Vector3.LerpUnclamped(startScale, endScale, t);
            yield return null;
        }
    }

    public IEnumerator HideOverlay(float duration)
    {
        float time = 0f;
        Vector3 startScale = Vector3.one;
        Vector3 endScale = Vector3.zero;
        while (time < duration)
        {
            time += Time.deltaTime;
            float t = time / duration;
            t = 1f - Mathf.Pow(1f - t, 3f);

            overlayImage.transform.localScale = Vector3.LerpUnclamped(startScale, endScale, t);
            yield return null;
        }

        overlayImage.enabled = false;
        overlayImage.sprite = null;
    }

    public IEnumerator ChangeBackground(Sprite sprite, float duration = 1f)
    {
        backgroundImage.sprite = sprite;
        yield return FadeCanvasAlpha(fullscreenBlackCanvasGroup, 1f, 0f, duration);
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
