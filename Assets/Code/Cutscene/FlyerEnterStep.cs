using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "FlyerEnterStep", menuName = "Cutscene/Steps/Flyer Enter")]
public class FlyerEnterStep : CutsceneStep
{
    public Sprite flyerSprite;


    public override IEnumerator Play(CutscenePlayer player)
    {
        yield return player.ShowOverlay(flyerSprite, animate: true);
    }
}
