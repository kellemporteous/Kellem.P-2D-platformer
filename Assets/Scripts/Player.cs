using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    private Transform myTransform;
    public Rigidbody rb;
    public Transform startPoint;
    public Transform checkPoint1;
    public Transform checkPoint2;

    Game_Manager gameManager;
    Sound_Manager soundManager;

    public AudioClip jump;
    public AudioClip hit;
    public AudioClip death;
    public AudioClip coin;
    public AudioClip heal;
    public AudioClip rareItem;
    public AudioClip doorLocked;
    public AudioClip doorUnlocked;
    public AudioClip keyPickUp;

    public int maxHealth;
    public int health;
    public int damage;
    public int currentHealth;
    public float walkSpeed;
    public float jumpForce;
    private float distToGround;
    private float distToWall;

    public GameObject playerModel;
    private int facingDirection = 1;
    private Quaternion facingRotation;
    public GameObject enemy;

    public bool key = false;
    public bool slime = false;
    public bool area1 = true;
    public bool area2 = false;
    public bool area3 = false;

    // Use this for initialization
    void Start()
    {
        myTransform = this.transform;
        rb = GetComponent<Rigidbody>();


        enemy = GameObject.FindGameObjectWithTag("Enemy");
        gameManager = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<Game_Manager>();
        soundManager = GameObject.FindGameObjectWithTag("Sound Manager").GetComponent<Sound_Manager>();

        distToGround = myTransform.GetComponent<Collider>().bounds.extents.y;

       
    }

    void FixedUpdate()
    {
        Controls();
    }

    // Update is called once per frame
    void Update()
    {
        DirectionFacing();
    }

    void Controls()
    {
        //Move Right
        if (Input.GetKey("d"))
        {
            rb.MovePosition(transform.position + transform.forward * walkSpeed * Time.fixedDeltaTime);
            facingDirection = 1;
        }
        //Move Left
        else if (Input.GetKey("a"))
        {
            rb.MovePosition(transform.position + transform.forward * walkSpeed * Time.fixedDeltaTime);
            facingDirection = -1;
        }

        //Jumping
        if (Input.GetKeyDown("space") && CheckGrounded() == true)
        {
            soundManager.PlaySound(jump);
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }



    void DirectionFacing()
    {
        facingRotation = playerModel.transform.rotation;

        facingRotation.eulerAngles = new Vector3(facingRotation.eulerAngles.x,
            90 * facingDirection,
                facingRotation.eulerAngles.z);

        playerModel.transform.rotation = facingRotation;
    }

    void TakeDamage()
    {
        health = health - damage;
        currentHealth = health;
    }

    void Respawn()
    {
        if (area1 == true)
        {
            myTransform.position = startPoint.position;
        }

        if (area2 == true)
        {
            myTransform.position = checkPoint1.position;
        }

        if (area3 == true)
        {
            myTransform.position = checkPoint2.position;
        }
    }

    void Death()
    {
  
        if (currentHealth <= 0)
        {
            SceneManager.LoadScene("Lose Screen");
            gameManager.HighScoreUpdate();
        }

        if (currentHealth >= 0)
        {
            Debug.Log("Working");
            Respawn();
        }
    }

    void OnTriggerEnter(Collider otherObject)
    {
        if (otherObject.tag == "Health PickUp")
        {
            soundManager.PlaySound(heal);

            if (currentHealth >= maxHealth)
            {
                health = maxHealth;
            }

            else if (currentHealth <= maxHealth)
            {
                currentHealth = health +1;
                health = currentHealth;
            }
            Destroy(otherObject.gameObject);
        }

        if (otherObject.tag == "Spike")
        {
            soundManager.PlaySound(death);
            TakeDamage();
            Death();
        }

        if (otherObject.tag == "Enemy")
        {
            if (myTransform.position.y <= otherObject.transform.position.y + 0.5f)
            {
                soundManager.PlaySound(death);
                TakeDamage(); 
                Death();
            }

            else if (myTransform.position.y >= otherObject.transform.position.y)
            {
                soundManager.PlaySound(hit);
                gameManager.score += 100;
                Destroy(otherObject.gameObject);
            }
        }

        if (otherObject.tag == "Out")
        {
            soundManager.PlaySound(death);
            TakeDamage();
            Death();
        }

        if (otherObject.tag == "False Platform")
        {
            Destroy(otherObject.gameObject);
        }

        if (otherObject.tag == "Key")
        {
            soundManager.PlaySound(keyPickUp);
            key = true;
            Destroy(otherObject.gameObject);
        }

        if (otherObject.tag == "Door")
        {
            if (key == false)
            {
                soundManager.PlaySound(doorLocked);
                Debug.Log("Door is locked, Find the key to continue");
                otherObject.isTrigger = false;
            }

            else if (key == true)
            {
                soundManager.PlaySound(doorUnlocked);
                otherObject.isTrigger = true;
            }
        }

        if (otherObject.tag == "Door 2")
        {
            if (key == false)
            {
                soundManager.PlaySound(doorLocked);
                Debug.Log("Door is locked, Find the key to continue");
                otherObject.isTrigger = false;
            }

            else if (key == true)
            {
                soundManager.PlaySound(doorUnlocked);
                otherObject.isTrigger = true;
            }
        }

        if (otherObject.tag == "Coin")
        {
            soundManager.PlaySound(coin);
            gameManager.score += 50;
            Destroy(otherObject.gameObject);
        }

        if(otherObject.tag == "Magician Cube")
        {
            soundManager.PlaySound(rareItem);
            gameManager.score += 300;
            Destroy(otherObject.gameObject);
        }

        if (otherObject.tag == "Exit")
        {
            soundManager.PlaySound(doorUnlocked);
            gameManager.SaveScore();
            Scene scene = SceneManager.GetActiveScene();

            if (scene.name == "Level 1")
            {
                SceneManager.LoadScene("Level 2");
            }

            if (scene.name == "Level 2")
            {
                SceneManager.LoadScene("Level 3");
            }

            if (scene.name == "Level 3")
            {
                SceneManager.LoadScene("Win Screen");
            }
        }
    }

    void OnCollisionStay(Collision otherObject)
    {
        if (otherObject.transform.tag == "Moving Platform")
        {
            Debug.Log("IM ON");
            transform.parent = otherObject.transform;
        }
    }

    void OnCollisionExit(Collision otherObject)
    {
        if (otherObject.transform.tag == "Moving Platform")
        {
            Debug.Log("IM OFF");
            transform.parent = null;
        }
    }
    void OnTriggerExit(Collider otherObject)
    {
        if (otherObject.tag == "Door")
        {
            key = false;
            area1 = false;
            area2 = true;
        }

        if (otherObject.tag == "Door 2")
        {
            key = false;
            area3 = true;
            area2 = false;
        }
    }

    public bool CheckGrounded()
    {
        return Physics.Raycast(myTransform.position, -Vector3.up, distToGround + 0.1f);
    }
}
