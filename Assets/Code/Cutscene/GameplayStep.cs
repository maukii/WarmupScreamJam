using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "GameplayStep", menuName = "Cutscene/Steps/Gameplay")]
public class GameplayStep : CutsceneStep
{
    public Minigame minigamePrefab;


    public override IEnumerator Play(CutscenePlayer player)
    {
        if (minigamePrefab != null)
        {
            Minigame instance = Instantiate(minigamePrefab, Container.Instance.transform);
            instance.StartMinigame();
            yield return instance.WaitForCompletion();
        }
    }
}
