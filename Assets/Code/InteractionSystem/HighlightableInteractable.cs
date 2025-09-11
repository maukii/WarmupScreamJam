using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class HighlightableInteractable : Interactable
{
    [SerializeField] Material highlightMaterial;
    [SerializeField] Color highlightColor = Color.red;
    [SerializeField] Vector2 highlightScale = new Vector2(1.1f, 1.1f);

    GameObject highlightObject;
    SpriteRenderer highlightRenderer;
    SpriteRenderer mainRenderer;


    void Awake()
    {
        mainRenderer = GetComponent<SpriteRenderer>();
        if (highlightMaterial != null)
        {
            highlightObject = new GameObject("Highlight");
            highlightObject.transform.SetParent(transform, false);
            highlightObject.transform.localScale = highlightScale;

            highlightRenderer = highlightObject.AddComponent<SpriteRenderer>();
            highlightRenderer.sprite = mainRenderer.sprite;
            highlightRenderer.material = highlightMaterial;
            highlightRenderer.color = highlightColor;

            highlightRenderer.sortingLayerID = mainRenderer.sortingLayerID;
            highlightRenderer.sortingOrder = mainRenderer.sortingOrder - 1;

            highlightObject.SetActive(false);
        }
    }

    public override void HoverEnter(Interactor interactor)
    {
        base.HoverEnter(interactor);

        if (highlightObject != null)
            highlightObject.SetActive(true);
    }

    public override void HoverExit(Interactor interactor)
    {
        base.HoverExit(interactor);

        if (highlightObject != null)
            highlightObject.SetActive(false);
    }

    public override void Interact(Interactor interactor)
    {
        base.Interact(interactor);
        Debug.Log($"{name} interacted with!");
    }
}
