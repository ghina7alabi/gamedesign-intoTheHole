using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public static float speed;
    private Animator animator;

    private bool playerMoving;
    private Vector2 lastMove;

    public int situation = 0;

    //spritesInWalk
    public Sprite fallSprite;
    public Sprite normalSprite;

    //RandomLocation
    float RandomLocationTimer;
    int xPosRandom, yPosRandom;
    Vector3 newPosition;

    //PanicDisorder
    bool panicDisorder = false;
    GameObject cameraShake;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();

        //RandomLocation
        xPosRandom = Random.Range(-2, 2);
        yPosRandom = Random.Range(-2, 2);
        newPosition = new Vector3(transform.position.x + (xPosRandom * 16), transform.position.y + (yPosRandom * 16), 0);

        //PanicDisorder
        cameraShake = GameObject.FindGameObjectWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        RandomLocationTimer += Time.deltaTime;

        playerMoving = false;

        switch (situation)
        {
            case 1:
                WalkCharacterNormally();
                cameraShake.GetComponent<CameraShake>().enabled = false;
                break;

            case 2:
                WalkBackwards();
                break;

            case 3:
                DepressedWalk();
                break;

            case 4:
                PanicDisorder();
                break;

            case 5:
                HorizontalAxis();
                break;

            case 6:
                Bipolar();
                break;

            case 7:
                RandomLocation();
                break;
        }
    }

    

    void WalkCharacterNormally()
    {
        speed = 40;

        if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        {
                transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime, 0f, 0f));
                playerMoving = true;
                lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
        }

        else if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
        {
                transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * speed * Time.deltaTime, 0f));
                playerMoving = true;
                lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
        }

        setAnimator();

    }

    void WalkBackwards()
    {
        speed = 40;

        if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * -speed * Time.deltaTime, 0f, 0f));
            playerMoving = true;
            lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
        }

        else if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
        {
            transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * -speed * Time.deltaTime, 0f));
            playerMoving = true;
            lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
        }

        setAnimator();
    }

    void OppositeControls()
    {
        speed = 40;

        if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * -speed * Time.deltaTime, 0f, 0f));
            playerMoving = true;
            lastMove = new Vector2(-Input.GetAxisRaw("Horizontal"), 0f);
        }

        else if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
        {
            transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * -speed * Time.deltaTime, 0f));
            playerMoving = true;
            lastMove = new Vector2(0f, -Input.GetAxisRaw("Vertical"));
        }

        animator.SetFloat("MoveX", -Input.GetAxisRaw("Horizontal"));
        animator.SetFloat("MoveY", -Input.GetAxisRaw("Vertical"));
        animator.SetBool("PlayerMoving", playerMoving);
        animator.SetFloat("LastMoveX", lastMove.x);
        animator.SetFloat("LastMoveY", lastMove.y);
    }


    void DepressedWalk()
    {
        speed = 20;

        if (RandomLocationTimer >= 7)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = fallSprite;
            this.gameObject.GetComponent<Animator>().enabled = false;
            speed = 0;
            Debug.Log("Time is 7");
        }

        if (RandomLocationTimer >= 9)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = normalSprite;
            this.gameObject.GetComponent<Animator>().enabled = true;
            speed = 20;
            RandomLocationTimer = 0.0f;
            Debug.Log("Time is less than 7");
        }

        if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime, 0f, 0f));
            playerMoving = true;
            lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
        }

        else if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
        {
            transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * speed * Time.deltaTime, 0f));
            playerMoving = true;
            lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
        }



        setAnimator();
    }

    void VerticalAxis()
    {
        speed = 40;

        if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * 0 * Time.deltaTime, 0f, 0f));
            playerMoving = true;
            lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
        }

        else if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
        {
            transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * speed * Time.deltaTime, 0f));
            playerMoving = true;
            lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
        }

        setAnimator();
    }

    void HorizontalAxis()
    {
        speed = 40;

        if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime, 0f, 0f));
            playerMoving = true;
            lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
        }

        else if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
        {
            transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * 0 * Time.deltaTime, 0f));
            playerMoving = true;
            lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
        }

        setAnimator();
    }

    void Bipolar()
    {
        if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            speed = 20;
            transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime, 0f, 0f));
            playerMoving = true;
            lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);

        }

        else if (Input.GetAxisRaw("Vertical") > 0.5f)
        {
            speed = 200;

            this.gameObject.GetComponent<Rigidbody2D>().MovePosition(transform.position + transform.up * Time.deltaTime * speed);
            playerMoving = true;
            lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
        }

        else if (Input.GetAxisRaw("Vertical") < -0.5f)
        {
            speed = 200;

            this.gameObject.GetComponent<Rigidbody2D>().MovePosition(transform.position + -transform.up * Time.deltaTime * speed);
            playerMoving = true;
            lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
        }

        setAnimator();
    }

    void RandomLocation()
    {
        WalkCharacterNormally();

            GameObject[] visibleSpawnPoints = GameObject.FindGameObjectsWithTag("VisibleSpawnPoint");
            if (RandomLocationTimer >= 7)
            {
                int random = Random.Range(visibleSpawnPoints.Length-visibleSpawnPoints.Length, visibleSpawnPoints.Length);

            transform.Translate(new Vector3(visibleSpawnPoints[random].transform.position.x - transform.position.x, visibleSpawnPoints[random].transform.position.y - transform.position.y, 0f)); 
                RandomLocationTimer = 0.0f;
            }
      
    }

    void PanicDisorder()
    {
        WalkCharacterNormally();

        if (RandomLocationTimer >= (int) Random.Range(2, 4))
        {
            cameraShake.GetComponent<CameraShake>().enabled = true;
            cameraShake.GetComponent<CameraShake>().shakeDuration = 0.7f;

            RandomLocationTimer = 0.0f;
        }

    }


    void setAnimator()
    {
        animator.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        animator.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
        animator.SetBool("PlayerMoving", playerMoving);
        animator.SetFloat("LastMoveX", lastMove.x);
        animator.SetFloat("LastMoveY", lastMove.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "DepressionThemeChanger(Clone)")
        {
            situation = 3;
        }

        if (collision.gameObject.name == "BipolarDisorderThemeChanger(Clone)")
        {
            situation = 6;
        }

        if (collision.gameObject.name == "SchizophreniaThemeChanger(Clone)")
        {
            situation = 7;
        }

        if (collision.gameObject.name == "PanicDisorderThemeChanger(Clone)")
        {
            situation = 4;

            GameObject[] visibleObstacles = GameObject.FindGameObjectsWithTag("VisibleObstacleChangingLocations");
            for (int i = 0; i < visibleObstacles.Length; i++)
            {
                visibleObstacles[i].GetComponent<ObstacleTileBehaviors>().behavior = 4;
            }
        }

        if (collision.gameObject.name == "SocialAnxietyThemeChanger(Clone)")
        {
            situation = 1;
            GameObject[] anxietyMask = GameObject.FindGameObjectsWithTag("SocialAnxiety");
            for (int i = 0; i < anxietyMask.Length; i++)
            {
                anxietyMask[i].GetComponent<SpriteRenderer>().enabled = true;
            }
        }

        if (collision.gameObject.name == "NormalWalkThemeChanger(Clone)")
        {
            situation = 1;
        }

        if (collision.gameObject.tag == "Spikes")
        {
            cameraShake.GetComponent<CameraShake>().enabled = true;
            cameraShake.GetComponent<CameraShake>().shakeDuration = 0.75f;
        }

        if (collision.gameObject.tag == "pithole")
        {
            SwitchController.levelStatus = 100;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = fallSprite;
            this.gameObject.GetComponent<Animator>().enabled = false;
            StartCoroutine("WaitForEndScene");
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.name == "PanicDisorderThemeChanger(Clone)")
        {
            situation = 1;
            GameObject[] visibleObstacles = GameObject.FindGameObjectsWithTag("VisibleObstacleChangingLocations");
            for (int i = 0; i < visibleObstacles.Length; i++)
            {
                visibleObstacles[i].GetComponent<ObstacleTileBehaviors>().behavior = 0;
            }
        }

        if (collision.gameObject.name == "SocialAnxietyThemeChanger(Clone)")
        {
            GameObject[] anxietyMask = GameObject.FindGameObjectsWithTag("SocialAnxiety");
            for (int i = 0; i < anxietyMask.Length; i++)
            {
                anxietyMask[i].GetComponent<SpriteRenderer>().enabled = false;
            }
        }

        if (collision.gameObject.tag == "Spikes")
        {
            cameraShake.GetComponent<CameraShake>().enabled = false;
        }
    }

    IEnumerator WaitForEndScene()
    {
        yield return new WaitForSeconds(0.85f);
        SceneManager.LoadScene("GameOver");
    }

}
