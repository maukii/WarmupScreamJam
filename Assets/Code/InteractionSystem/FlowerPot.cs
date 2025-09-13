using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class FlowerPot : Interactable
{
    [SerializeField] int hoveredSortingOrder = 2;
    [SerializeField] Color hoveredColor;

    SpriteRenderer spriteRenderer;
    int originalSortingOrder = 0;
    Color originalColor = Color.white;


    void Awake() => spriteRenderer = GetComponent<SpriteRenderer>();

    void Start()
    {
        originalSortingOrder = spriteRenderer.sortingOrder;
        originalColor = spriteRenderer.color;
    }

    public override void HoverEnter(Interactor interactor)
    {
        base.HoverEnter(interactor);
        spriteRenderer.sortingOrder = hoveredSortingOrder;
        spriteRenderer.color = hoveredColor;
    }

    public override void HoverExit(Interactor interactor)
    {
        base.HoverExit(interactor);
        spriteRenderer.sortingOrder = originalSortingOrder;
        spriteRenderer.color = originalColor;
    }
}
