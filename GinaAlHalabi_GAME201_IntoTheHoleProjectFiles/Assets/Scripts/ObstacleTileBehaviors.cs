using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleTileBehaviors : MonoBehaviour {
    public int behavior;

    bool platformMoving = false;

    float RandomLocationTimer;

    private void Update()
    {
        RandomLocationTimer += Time.deltaTime;
    }

    void FixedUpdate () {

		switch (behavior)
        {
            case 1:
                MimickingCharacterBehavior();
                break;

            case 2:
                MovingTileHorizontal();
                break;

            case 3:
                MovingTileVertical();
                break;

            case 4:
                RandomLocation();
                break;

        }
	}

    void MimickingCharacterBehavior()
    {
        if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * -PlayerController.speed * Time.deltaTime, 0f, 0f));
            platformMoving = true;
        }

        else if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
        {
            transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * -PlayerController.speed * Time.deltaTime, 0f));
            platformMoving = true;
        }

        platformMoving = false;
    }

    void MovingTileHorizontal()
    {
        Vector3 v = transform.position;
        v.x += 2 * Mathf.Sin(Time.time * -10);
        transform.position = v;
    }

    void MovingTileVertical()
    {
        Vector3 v = transform.position;
        v.y += 2 * Mathf.Sin(Time.time * -10);
        transform.position = v;
    }

    void RandomLocation()
    {
        GameObject[] visibleSpawnPoints = GameObject.FindGameObjectsWithTag("VisibleSpawnPoint");
        if (RandomLocationTimer >= 2)
        {
            int random = Random.Range(visibleSpawnPoints.Length - visibleSpawnPoints.Length, visibleSpawnPoints.Length);

            transform.Translate(new Vector3(visibleSpawnPoints[random].transform.position.x - transform.position.x, visibleSpawnPoints[random].transform.position.y - transform.position.y, 0f));
            RandomLocationTimer = 0.0f;
        }

    }
}
