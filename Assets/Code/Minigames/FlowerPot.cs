using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FlowerPot : MonoBehaviour, IPointerEnterHandler
{
    WateringMinigame minigame;
    Image graphic;
    bool isWatered = false;


    void Awake() => graphic = GetComponent<Image>();

    public void Init(WateringMinigame minigame) => this.minigame = minigame;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (isWatered) return;

        isWatered = true;
        graphic.color = Color.blue;
        minigame.NotifyPotWatered(this);
    }
}
