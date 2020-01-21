using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{

    public SwitchController switchController;

    private SpriteRenderer spriteRenderer;

    bool hasBeenSwitched = false;

    // Use this for initialization
    void Start()
    {
        this.gameObject.tag = "InvisibleSwitch";
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnBecameInvisible()
    {
        this.gameObject.tag = "InvisibleSwitch";
    }

    private void OnBecameVisible()
    {
        this.gameObject.tag = "VisibleSwitch";

        switchController.switchHasAppeared();
        Debug.Log("Switch is visible");
    }
    

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Player" && !hasBeenSwitched)
        {
            hasBeenSwitched = true;

            // Let the opponent Controller know an opponent has died
            switchController.switchHasTurned();
            // Any destroy in game functionality here - play death sound, death particles, etc
            // Destroy the gameObject after 1 second
            //Destroy(this.gameObject, 1.0f);
            spriteRenderer.flipX = true;
        }
    }

}
