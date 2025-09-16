using System.Collections;
using UnityEngine;

    [CreateAssetMenu(fileName = "CustomMusicStep", menuName = "Cutscene/Steps/CustomMusic")]
    public class CustomMusicStep : CutsceneStep
    {
        public string musicName;
        public bool FadeIn;
        public bool FadeOut;

        public override IEnumerator Play(CutscenePlayer player)
        {
            AudioManager.PlayMusic(musicName);
            yield break;
        }
    }