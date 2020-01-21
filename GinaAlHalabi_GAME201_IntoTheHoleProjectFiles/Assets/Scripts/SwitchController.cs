using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour {

    public int switchesLeft = 0;

    public bool doorsCanOpen = false;

    public static int levelStatus = 0;

    private void Awake()
    {
        switchesLeft = 0;
    }

    private void Start()
    {
        switchesLeft = 0;
    }

    public void switchHasTurned()
    {
        switchesLeft--;
        print(switchesLeft);

        if (switchesLeft <= 0)
        {
            Debug.Log("Doors can open");
            doorsCanOpen = true;
            switchesLeft = 0;

            levelStatus++;
        }
    }

    public void switchHasAppeared()
    {
        doorsCanOpen = false;
        switchesLeft = 0;
        switchesLeft++;
        Debug.Log(switchesLeft);
    }

}
