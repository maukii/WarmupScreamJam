using UnityEngine;

public interface IInteractable
{
    void HoverEnter(Interactor interactor);
    void HoverExit(Interactor interactor);
    void Interact(Interactor interactor);
}
