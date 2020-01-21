using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibilityTagObstacleLoc : MonoBehaviour
{

    private void OnBecameInvisible()
    {
        this.gameObject.tag = "InvisibleObstacleChangingLocations";
    }

    private void OnBecameVisible()
    {
        this.gameObject.tag = "VisibleObstacleChangingLocations";
    }

}
