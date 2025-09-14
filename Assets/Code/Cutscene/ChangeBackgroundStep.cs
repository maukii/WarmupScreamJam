using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "ChangeBackgroundStep", menuName = "Cutscene/Steps/Change Background")]
public class ChangeBackgroundStep : CutsceneStep
{
    public Sprite sprite;


    public override IEnumerator Play(CutscenePlayer player)
    {
        yield return player.ChangeBackground(sprite);
    }
}
