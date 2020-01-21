using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{

    public SwitchController switchController;
    public Sprite openDoorSprite;


    Vector3 moveJump = Vector2.zero;
    Vector3 playerMoveJump = Vector2.zero;
    float horMove, vertMove;

    // Use this for initialization
    void Start()
    {
        this.gameObject.tag = "ClosedDoor";
        this.gameObject.GetComponent<BoxCollider2D>().isTrigger = false;


        SheetAssigner SA = FindObjectOfType<SheetAssigner>();
        Vector2 tempJump = SA.roomDimensions + SA.gutterSize;
        moveJump = new Vector3(tempJump.x, tempJump.y, 0); //distance b/w rooms: to be used for movement

        playerMoveJump = new Vector3(tempJump.x - (14 * 16), tempJump.y - (6 * 16), 0);
    }

    private void OnBecameVisible()
    {
        Debug.Log("Doors are visible");
        this.gameObject.tag = "SeenDoor";
    }

    private void Update()
    {
        if (this.gameObject.tag == "SeenDoor" && switchController.doorsCanOpen)
        {
            this.gameObject.tag = "OpenedDoor";
            this.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = openDoorSprite;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Debug.Log("TriggerOccured");

            horMove = System.Math.Sign(Input.GetAxisRaw("Horizontal"));//capture input
            vertMove = System.Math.Sign(Input.GetAxisRaw("Vertical"));
            Vector3 tempPos = Camera.main.transform.position;
            tempPos += Vector3.right * horMove * moveJump.x; //jump between rooms based on input
            tempPos += Vector3.up * vertMove * moveJump.y;
            Camera.main.transform.position = tempPos;

            GameObject player = GameObject.Find("Player");
            Vector3 playerTempPos = player.transform.position;
            playerTempPos += Vector3.right * horMove * playerMoveJump.x; //jump between rooms based on input
            playerTempPos += Vector3.up * vertMove * playerMoveJump.y;
            player.transform.position = playerTempPos;

            switchController.switchesLeft = 0;
        }
    }
}
