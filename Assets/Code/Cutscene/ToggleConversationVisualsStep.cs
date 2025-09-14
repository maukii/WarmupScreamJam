using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "ToggleConversationVisualsStep", menuName = "Cutscene/Steps/ToggleConversationUI")]
public class ToggleConversationVisualsStep : CutsceneStep
{
    public bool toggleToState;
    public float duration = 1f;
    public bool clearDialogue;


    public override IEnumerator Play(CutscenePlayer player)
    {
        yield return player.ToggleConversationUI(toggleToState, duration, clearDialogue);
    }
}
