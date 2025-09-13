using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "FlyerExitStep", menuName = "Cutscene/Steps/Flyer Exit")]
public class FlyerExitStep : CutsceneStep
{
    public override IEnumerator Play(CutscenePlayer player)
    {
        yield return player.HideOverlay(animate: true);
    }
}
