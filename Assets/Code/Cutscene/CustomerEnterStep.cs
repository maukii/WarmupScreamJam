using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "CustomerEnterStep", menuName = "Cutscene/Steps/CustomerEnter")]
public class CustomerEnterStep : CutsceneStep
{
    public Sprite sprite;
    public float duration;


    public override IEnumerator Play(CutscenePlayer player)
    {
        yield return player.CustomerEnter(sprite, duration);
    }
}
