using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UtilityBehaviors : MonoBehaviour {

    public SwitchController switchController;

    private void Start()
    {
        switchController.switchesLeft = 0;
    }

    void Update () {
		if (Input.GetKeyDown("r")){//reload scene, for testing purposes
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
	}
}
