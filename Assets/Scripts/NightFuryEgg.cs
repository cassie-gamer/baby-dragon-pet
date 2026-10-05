using UnityEngine;

// A mysterious black egg! Tap it 3 times to hatch baby Toothless.
public class NightFuryEgg : MonoBehaviour
{
    [Header("Drag your baby Toothless here (starts hidden)")]
    public GameObject babyToothless;

    [Header("How many taps to hatch")]
    public int tapsToHatch = 3;

    private int taps = 0;

    // Tap the egg in the game
    void OnMouseDown()
    {
        Tap();
    }

    // Or hook this up to a UI button
    public void TapButton()
    {
        Tap();
    }

    void Tap()
    {
        taps++;
        // Wiggle the egg a little
        transform.localScale = transform.localScale * 1.05f;
        Debug.Log("The egg wiggles... (" + taps + "/" + tapsToHatch + ")");

        if (taps >= tapsToHatch)
        {
            Hatch();
        }
    }

    void Hatch()
    {
        Debug.Log("CRACK! Baby Toothless hatches!");
        gameObject.SetActive(false);
        if (babyToothless) babyToothless.SetActive(true);
    }
}
