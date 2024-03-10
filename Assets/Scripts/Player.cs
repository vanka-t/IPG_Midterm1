using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{


    private CharacterController charController;
    //basic settings
   // [SerializeField]
    private float speed = 15;
    private float mouseSensitivity = 3.5f;

    //position coordinates
    private float xPos = -45;
    private float yPos = 12;
    private float zPos = -4;

    Transform cameraTrans;
    //camera pitch angle
    float cameraPitch = 0;
    float gravityValue = Physics.gravity.y; //built in

    //y axis speed (jumping vel)
    float jumpHeight = -1f;
    float currentYVel;

    [SerializeField]
    Transform gunPoint;



    // Start is called before the first frame update
    void Start()
    {
        //setting player coordinates in order to control position when scenes change 
        PlayerPrefs.SetFloat("XPos", -45);// xPos);
        PlayerPrefs.SetFloat("YPos", 15);//yPos);
        PlayerPrefs.SetFloat("ZPos", -4);//zPos);

        charController = GetComponent<CharacterController>();
        cameraTrans = Camera.main.transform;

        //Lock the cursor in the center and hide it
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        //if (GameManager.instance.level2)
        //{
        //    float X = PlayerPrefs.GetFloat("XPos");
        //    float Y = PlayerPrefs.GetFloat("YPos");
        //    float Z = PlayerPrefs.GetFloat("ZPos");
        //    transform.position = new Vector3(X, Y, Z);
        //    print("mu ca kari");
           
        //}


    }

    // Update is called once per frame
    void Update()
    {
        //if games not over
        if (!GameManager.instance.isGameOver)
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
                    print(currentYVel);
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
                SpawnerManager.instance.SpawnBullet(gunPoint.position, cameraTrans.rotation);
            }
        }

       


        }
   
    private void OnTriggerEnter(Collider other)
    {
        //if colliding with enemy
        if (other.CompareTag("Enemy"))
        {
            //GameManager.instance.isGameOver = true;
            //  Health points -= 1


            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            GameManager.instance.GameOver();
            print("ouch!");
        }

        //if finding token
         if (other.CompareTag("Token"))
        {
            print("Token collected!");
           // GameManager.instance.levelComplete = true;
            //  Health points -= 1


            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            GameManager.instance.LevelComplete();
            
        }


    }


}

    



