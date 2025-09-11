using UnityEngine;

public class Interactor : MonoBehaviour
{
    [SerializeField] Texture2D defaultCursorTexture;

    Camera mainCamera;
    IInteractable currentTarget;


    void Awake() => mainCamera = Camera.main;

    void Start() => CursorUtils.SetCursor(defaultCursorTexture);

    void Update()
    {
        HandleHover();
        HandleClick();
    }

    void HandleHover()
    {
        Vector2 worldPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Collider2D hit = Physics2D.OverlapPoint(worldPos);
        if (hit != null)
        {
            if (hit.TryGetComponent(out IInteractable interactable))
            {
                if (interactable != currentTarget)
                {
                    ClearCurrentTarget();
                    currentTarget = interactable;
                    currentTarget.HoverEnter(this);
                }

                return;
            }
        }

        ClearCurrentTarget();
    }

    void HandleClick()
    {
        if (Input.GetMouseButtonDown(0) && currentTarget != null) currentTarget.Interact(this);
    }

    void ClearCurrentTarget()
    {
        if (currentTarget != null)
        {
            currentTarget.HoverExit(this);
            currentTarget = null;

            CursorUtils.SetCursor(defaultCursorTexture);
        }
    }
}
