using System.Collections;
using UnityEngine;

    [CreateAssetMenu(fileName = "CustomAudioStep", menuName = "Cutscene/Steps/CustomAudio")]
    public class CustomAudioStep : CutsceneStep
    {
        public string audioName;

        public override IEnumerator Play(CutscenePlayer player)
        {
            AudioManager.PlayAudio(audioName);
            yield break;
        }
    }