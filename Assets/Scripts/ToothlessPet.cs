using UnityEngine;
using UnityEngine.UI;

// Your very own baby Night Fury - Toothless!
// His Hunger, Fun and Energy go down over time.
// Feed him fish (his favorite!), play with him, and let him nap.
// Keep the bars full and Toothless stays happy!
public class ToothlessPet : MonoBehaviour
{
    [Header("Stats (0 - 100)")]
    public float hunger = 80f;
    public float fun = 80f;
    public float energy = 80f;

    [Header("How fast stats drop (per second)")]
    public float hungerDecay = 1.5f;
    public float funDecay = 1.0f;
    public float energyDecay = 0.8f;

    [Header("Hook up your UI here")]
    public Image hungerBar;
    public Image funBar;
    public Image energyBar;
    public Text moodText;

    void Update()
    {
        // Stats slowly go down
        hunger = Mathf.Max(0, hunger - hungerDecay * Time.deltaTime);
        fun = Mathf.Max(0, fun - funDecay * Time.deltaTime);
        energy = Mathf.Max(0, energy - energyDecay * Time.deltaTime);

        UpdateUI();
    }

    // Toothless LOVES fish! Give him some yummy fish.
    public void FeedFish()
    {
        hunger = Mathf.Min(100, hunger + 25);
        Debug.Log("Toothless gobbles up the fish! Hunger is now " + hunger);
    }

    // Play together! Fun goes up, but he gets a little tired.
    public void Play()
    {
        fun = Mathf.Min(100, fun + 25);
        energy = Mathf.Max(0, energy - 5);
        Debug.Log("Wheee! Toothless zooms around! Fun is now " + fun);
    }

    // Let Toothless take a cozy nap. Fully rested!
    public void Sleep()
    {
        energy = 100;
        Debug.Log("Zzz... Toothless curls up and naps. Energy is now " + energy);
    }

    // Scratch behind his ears - his favorite spot!
    public void ScratchEars()
    {
        fun = Mathf.Min(100, fun + 10);
        Debug.Log("Toothless purrs and wiggles happily!");
    }

    void UpdateUI()
    {
        if (hungerBar) hungerBar.fillAmount = hunger / 100f;
        if (funBar) funBar.fillAmount = fun / 100f;
        if (energyBar) energyBar.fillAmount = energy / 100f;

        if (moodText)
        {
            float avg = (hunger + fun + energy) / 3f;
            if (avg > 75) moodText.text = "Toothless is so happy!";
            else if (avg > 50) moodText.text = "Toothless is doing okay!";
            else if (avg > 25) moodText.text = "Toothless needs some love...";
            else moodText.text = "Toothless looks sad :(";
        }
    }
}
