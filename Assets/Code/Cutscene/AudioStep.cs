using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "AudioStep", menuName = "Cutscene/Steps/Audio")]
public class AudioStep : CutsceneStep
{
    public AudioClip clip;
    public float durationToWait;


    public override IEnumerator Play(CutscenePlayer player)
    {
        AudioSource.PlayClipAtPoint(clip, Vector3.zero);
        yield return new WaitForSeconds(durationToWait);
    }
}
