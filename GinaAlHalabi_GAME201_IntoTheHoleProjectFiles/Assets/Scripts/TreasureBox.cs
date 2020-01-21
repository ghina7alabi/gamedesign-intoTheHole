using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TreasureBox : MonoBehaviour {

    public Sprite openedTreasureSprite;
    bool treasureOpened = false;

    // Use this for initialization
    void Start () {
        treasureOpened = false;
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            //GameWon
            this.gameObject.GetComponent<SpriteRenderer>().sprite = openedTreasureSprite;
            treasureOpened = true;

            if (treasureOpened)
            {
                StartCoroutine("WaitForEndScene");
            }
        }
    }

    IEnumerator WaitForEndScene()
    {
        yield return new WaitForSeconds(0.6f);
        SceneManager.LoadScene("GameOver");
    }


}
