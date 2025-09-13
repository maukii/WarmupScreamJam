using UnityEngine;

[CreateAssetMenu(fileName = "CutsceneSequence", menuName = "Cutscene/Sequence")]
public class CutsceneSequence : ScriptableObject
{
    public CutsceneStep[] steps;
}