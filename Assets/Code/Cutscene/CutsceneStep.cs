using System.Collections;
using UnityEngine;

public abstract class CutsceneStep : ScriptableObject
{
    public abstract IEnumerator Play(CutscenePlayer player);
}
