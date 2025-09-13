using UnityEngine;
using UnityEngine.UI;

public class WateringMinigame : Minigame
{
    [SerializeField] Image wateringCan;
    [SerializeField] FlowerPot[] pots;

    int wateredCount = 0;
    bool isActive = false;


    public override void StartMinigame()
    {
        wateredCount = 0;
        foreach (var pot in pots)
        {
            pot.Init(this);
        }
    }

    void Update()
    {
        if (!isActive) return;


    }

    public void NotifyPotWatered(FlowerPot pot)
    {
        wateredCount++;
        if (wateredCount >= pots.Length)
        {
            CompleteMinigame();
        }
    }
}
