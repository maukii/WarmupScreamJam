using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "PauseStep", menuName = "Cutscene/Steps/Pause")]
public class PauseStep : CutsceneStep
{
    public float duration = 1f;


    public override IEnumerator Play(CutscenePlayer player)
    {
        player.ClearDialogue();
        yield return new WaitForSeconds(duration);
    }
}
