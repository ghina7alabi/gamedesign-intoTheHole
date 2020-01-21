using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibilityTagSpawnPoint : MonoBehaviour
{

    private void OnBecameInvisible()
    {
        this.gameObject.tag = "InvisibleSpawnPoint";
    }

    private void OnBecameVisible()
    {
        this.gameObject.tag = "VisibleSpawnPoint";
    }

}
