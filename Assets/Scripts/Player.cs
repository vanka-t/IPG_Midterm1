using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{


    private CharacterController charController;
    //BASIC SETTINGS
    private float speed = 15;
    private float mouseSensitivity = 3.5f;

    ////position coordinates
    //private float xPos = -45;
    //private float yPos = 12;
    //private float zPos = -4;

    Transform cameraTrans;
    //camera pitch angle
    float cameraPitch = 0;
    float gravityValue = Physics.gravity.y; //built in

    //y axis speed (jumping vel)
    float jumpHeight = -1f;
    float currentYVel;

    [SerializeField]
    Transform gunPoint;

    //HEALTH SETTINGS
    private float maxHealth = 5;
    private float currentHealth;

    [SerializeField]
    private HealthBar healthBar;

    //AUDIO SETTINGS
    public AudioSource Source;
    public AudioClip ouchSound;
    public AudioClip collectSound;
    public AudioClip shootSound;

    public GameObject deathZone;

    private int levelNum = 0;

    // Start is called before the first frame update
    void Start()
    {

        Source = GetComponent<AudioSource>();
        charController = GetComponent<CharacterController>();
        cameraTrans = Camera.main.transform;

        //Lock the cursor in the center and hide it
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;


        //restarting health
        currentHealth = maxHealth;
        healthBar.UpdateHealthBar(maxHealth, currentHealth);


        if (levelNum == 1)
        {
            transform.position = new Vector3(0, 0, 0);
            Debug.Log(transform.position.x + ", " + transform.position.y + "," + transform.position.z);
            // print("");

        }
    }

    // Update is called once per frame
    void Update()
    {
        //if games not over
        if (!GameManager.instance.isGameOver && !GameManager.instance.isLevelComplete)
        {
            
            //print("Game's not over");

            //tracks mouse data
            //the tags mouse x and mouse y are built in by default (find in project settings > input manager)
            Vector2 mouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

            transform.Rotate(Vector3.up * mouseDelta.x * mouseSensitivity); //rotate horizontally

            //moving camera accordingly to mouse movement
            cameraPitch -= mouseDelta.y * mouseSensitivity;
            cameraPitch = Mathf.Clamp(cameraPitch, -90, 90);
            cameraTrans.localEulerAngles = Vector3.right * cameraPitch;


            //move around
            Vector3 move = transform.rotation * new Vector3(
                Input.GetAxis("Horizontal"),
                0,
                 Input.GetAxis("Vertical")

                );

           
          



            //Debug.Log(transform.position.x + ", " + transform.position.y + "," + transform.position.z);
            
            if (Input.GetKeyDown(KeyCode.Space) && charController.isGrounded)
                {
                   // print(currentYVel);
                    //jump
                    currentYVel += Mathf.Sqrt(2 * jumpHeight * gravityValue); //jump formula physics
                }
                else if (charController.isGrounded)
                {
                    currentYVel = -0.5f; //no jump (negative number so as to make sure that character has touched the ground, otherwise doesnt recognize it)
                }

            move.y = currentYVel;
            currentYVel += gravityValue * Time.deltaTime;
            charController.Move(move * Time.deltaTime * speed);

            //generate bullet

            if (Input.GetKeyDown(KeyCode.X))
            {
                Source.clip = shootSound;
                Source.Play();
                SpawnerManager.instance.SpawnBullet(gunPoint.position, cameraTrans.rotation);
            }
        }

       


        }

    private void OnTriggerEnter(Collider other)
    {
        //if colliding with enemy
        if (other.CompareTag("Enemy") || other.CompareTag("DeathZone"))
        {
            
            //different damage depending on whether player fell in lava (fatal) or hit by enemy
            if (other.CompareTag("DeathZone"))
            {
                print("death zone");
                currentHealth -= 100;
            } else
            {
                print("normal enemy");
                currentHealth -= Random.Range(0.1f, 1.5f); //deduct health points

            }
           
            
            print(currentHealth);

            if ( currentHealth <= 0) //game over
            {

                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                GameManager.instance.GameOver();
                print("ouch!");

            } else //take damage
            {
                Source.clip = ouchSound;
                Source.Play();
                healthBar.UpdateHealthBar(maxHealth, currentHealth);
            }
            
        }

        //if finding token
         if (other.CompareTag("Token"))
        {

            Source.clip = collectSound;
            Source.Play();
            print("Token collected!");
            levelNum += 1;
            print(levelNum);


            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            GameManager.instance.LevelComplete();
            
        }


    }

    public void NewLevel()
    {
        if (levelNum >= 1)
        {
            transform.position = new Vector3(0, 0, 0);
            Debug.Log(transform.position.x + ", " + transform.position.y + "," + transform.position.z);
            // print("");

        }
    }




}

    



