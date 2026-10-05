using UnityEngine;
using UnityEngine.UI;

// Toothless grows as you take good care of him!
// Stage 0: tiny hatchling, Stage 1: playful baby, Stage 2: big Night Fury.
// He grows when his average stats stay high. Keep those bars full!
public class ToothlessGrowth : MonoBehaviour
{
    [Header("Drag your ToothlessPet here")]
    public ToothlessPet pet;

    [Header("How often to check for growing (seconds)")]
    public float growCheckEvery = 10f;

    [Header("Show this text when he grows")]
    public Text growMessage;

    private int stage = 0;
    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= growCheckEvery)
        {
            timer = 0f;
            CheckGrowth();
        }
    }

    void CheckGrowth()
    {
        if (pet == null || stage >= 2) return;

        float avg = (pet.hunger + pet.fun + pet.energy) / 3f;

        if (avg > 70f)
        {
            stage++;
            // Toothless gets bigger!
            transform.localScale = transform.localScale * 1.5f;

            if (growMessage)
            {
                if (stage == 1) growMessage.text = "Toothless is growing!";
                else if (stage == 2) growMessage.text = "Toothless is a big Night Fury now!";
            }
            Debug.Log("Toothless grew to stage " + stage);
        }
    }
}
