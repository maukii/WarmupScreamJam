using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "TextStep", menuName = "Cutscene/Steps/Text")]
public class KTextStep : CutsceneStep
{
    [TextArea] public string text;
    [TextArea] public string character;
    public float typingSpeed = 0.05f;
    public bool waitForInput = true;


    public override IEnumerator Play(CutscenePlayer player)
    {
        yield return player.TypeText(text, typingSpeed);

        if (waitForInput)
        {
            yield return new WaitUntil(() => Input.anyKey);
        }
    }
}
