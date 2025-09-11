using UnityEngine;

public class Interactable : MonoBehaviour, IInteractable
{
    [SerializeField] Texture2D hoverCursor;


    public virtual void HoverEnter(Interactor interactor)
    {
        if (hoverCursor != null) CursorUtils.SetCursor(hoverCursor);
    }

    public virtual void HoverExit(Interactor interactor) { }

    public virtual void Interact(Interactor interactor)
    {
        Debug.Log($"{name} was interacted with!");
    }
}
