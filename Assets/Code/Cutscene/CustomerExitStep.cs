using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "CustomerExitStep", menuName = "Cutscene/Steps/CustomerExit")]
public class CustomerExitStep : CutsceneStep
{
    public float duration;


    public override IEnumerator Play(CutscenePlayer player)
    {
        yield return player.CustomerExit(duration);
    }
}
