using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndMessageManager : MonoBehaviour {

    public TextMeshProUGUI scoreText;
	
	// Update is called once per frame
	void Update () {
		if (SwitchController.levelStatus <= 2)
        {
            scoreText.text = "Living the good life.";
        }

        if (SwitchController.levelStatus >= 4)
        {
            scoreText.text = "Ehh, thick skin";
        }

        if (SwitchController.levelStatus >= 7)
        {
            scoreText.text = "Woah, tough life";
        }

        if (SwitchController.levelStatus >= 12)
        {
            scoreText.text = "Giving life black eyes there!";
        }

        if (SwitchController.levelStatus == 100)
        {
            scoreText.text = "You chose to give up..";
        }
	}
}
