using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    
    private CharacterController charController;
    //basic settings
    [SerializeField]
    private float speed = 3;
    private float mouseSensitivity = 3.5f;

    public bool shoot;


    Transform cameraTrans;


    //camera pitch angle
    float cameraPitch = 0;
    float gravityValue = Physics.gravity.y; //built in

    //y axis speed
    float jumpHeight = -2f;
    float currentYVel;



    // Start is called before the first frame update
    void Start()
    {
        charController = GetComponent<CharacterController>();
        cameraTrans = Camera.main.transform;

        //Lock the cursor in the center and hide it
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;


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

      


            if (charController.isGrounded)//also built in
            {
                print("youre grounded");
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    print(currentYVel);
                    //jump
                    currentYVel += Mathf.Sqrt(2 * jumpHeight * gravityValue); //jump formula physics
                }
                else
                {
                    currentYVel = -0.5f; //no jump (negative number so as to make sure that character has touched the ground, otherwise doesnt recognize it)
                }


            }
            else
            {
                print("not grounded");
                //not on ground
                currentYVel += gravityValue * Time.deltaTime;

            }

            move.y = currentYVel;

            charController.Move(move * Time.deltaTime * speed);


        }

    }


    //if colliding with enemy
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            GameManager.instance.isGameOver = true;
            //  Health points -= 1
            print("ouch!");
        }
        
    }


}
