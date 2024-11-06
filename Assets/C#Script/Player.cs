using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class User : MonoBehaviour
{
    public int CordsX = 0;
    public int CordsY = 0; 
    public int CordsZ = 0;
    public float moveSpeed = 5f;
    public float lookSpeed = 3f;
    private GameObject playerCapsule;
    private Camera playerCamera;

    void Start()
    {
        // Check if playerCapsule is assigned, if not, create it
        if (playerCapsule == null)
        {
            playerCapsule = GameObject.CreatePrimitive(PrimitiveType.Capsule);
            playerCapsule.name = "Player";

            // Optional: Adjust capsule size or position if needed
            playerCapsule.transform.position = new Vector3(0, 1, 0);

            // Add a Rigidbody for physics, if desired
            playerCapsule.AddComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;

            //setting player camera to make to the new game camera
            playerCamera = Camera.main;
            // Make the player capsule the parent of the camera
            playerCamera.transform.SetParent(playerCapsule.transform);
            playerCamera.transform.localPosition = new Vector3(0, 1f, 0); // Adjust camera position
            //rotate camera bassed off of player
            playerCamera.transform.localRotation = Quaternion.identity;
        }
    }
    void Update()
    {
        PlayerMovement();
        PlayerCamera();
    }

    void PlayerMovement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            //move player forward via transforming position
            Vector3 walk = playerCapsule.transform.forward;
            //transform position of player forward at the speed set
            playerCapsule.transform.position += walk * moveSpeed * Time.deltaTime;

        }
        if (Input.GetKey(KeyCode.D))
        {
            //move player forward via transforming position
            Vector3 walk = playerCapsule.transform.right;
            //transform position of player forward at the speed set
            playerCapsule.transform.position += walk * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
             //move player forward via transforming position
                Vector3 walk = playerCapsule.transform.forward;
                //transform position of player forward at the speed set
                playerCapsule.transform.position -= walk * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            //move player forward via transforming position
            Vector3 walk = playerCapsule.transform.right;
            //transform position of player forward at the speed set
            playerCapsule.transform.position -= walk * moveSpeed * Time.deltaTime;
        }
    }
    void PlayerCamera()
    {
        if (Input.GetMouseButton(1)) // Right click
        {
            // a float to hold the value roateted on the x axis by the mouse
            float mouseX = Input.GetAxis("Mouse X") * lookSpeed;
            //
            float mouseY = Input.GetAxis("Mouse Y") * lookSpeed;
            // rotates camera based on players mouse x movements
            playerCapsule.transform.Rotate(0, mouseX, 0);

            if (playerCamera != null)
            {
                playerCamera.transform.Rotate(-mouseY, 0, 0);
            }
        }
    }
}

