using System.Collections;
using UnityEngine;

public abstract class Minigame : MonoBehaviour
{
    protected bool isComplete = false;

    public abstract void StartMinigame();

    protected void CompleteMinigame() => isComplete = true;

    public IEnumerator WaitForCompletion()
    {
        yield return new WaitUntil(() => isComplete);
        Destroy(gameObject);
    }
}