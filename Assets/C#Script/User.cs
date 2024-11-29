using System.Collections.Generic;
using UnityEngine;


public class User : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float lookSpeed = 3f;
    public float verticalRotation = 0f;
    public float gravityStrength = 0f;

    public float currentHP = 25;//a int for the players current hp
    public float maxHp = 50; //players max health

    public GameObject playerCapsule;
    private Camera playerCamera;
    public BaseRoom _currentRoom = null;
    private Rigidbody GameBody;
    public CharacterController Controller;

    public float MoveSmoothTime;
    private Vector3 CurrentMoveVelocity;
    private Vector3 MoveDampVelocity;
    private Vector3 CurrentForceVelocity;

    public static User Instance { get; private set; } // Singleton instance
    public Transform InventoryUIParent; // Parent for inventory buttons
    public List<Item> UserInventory = new List<Item>();
    public List<ItemButtonScript> itembuttons = new List<ItemButtonScript>();
    public Item Item;
    public int playerDamage;

    void Start()
    {
        Controller = GetComponent<CharacterController>();
        // Check if playerCapsule is assigned, if not, create it
        if (playerCapsule == null)
        {
            playerCapsule.name = "Player";
            playerCapsule.transform.parent = transform;

            // Optional: Adjust capsule size or position if needed
            playerCapsule.transform.position = new Vector3(0, 1, 0);
        }

        // Set up Rigidbody if not already set
        if (GameBody == null)
        {
            GameBody = gameObject.AddComponent<Rigidbody>();
            GameBody.constraints = RigidbodyConstraints.FreezeRotation;
        }

        //setting player camera to make to the new game camera
        playerCamera = Camera.main;

        // Make the player capsule the parent of the camera
        
        playerCamera.transform.localPosition = new Vector3(0, 1f, 0); // Adjust camera position
        playerCamera.transform.localRotation = Quaternion.identity;
    }
    void Update()
    {
        PlayerMovement();
        PlayerCamera();
        PlayerAlive();
        if (Input.GetKeyDown(KeyCode.E))
        {
            PlayerSearchRoom();
        }
        Gravity();
    }
    void PlayerSearchRoom()
    {
        if (_currentRoom != null)
        {
            _currentRoom.OnRoomSearched();
        }
    }
    void PlayerMovement()
    {
        // Get player input for movement
        Vector3 PlayerInput = new Vector3
        {
            x = Input.GetAxisRaw("Horizontal"),
            y = 0f,
            z = Input.GetAxisRaw("Vertical"),
        };

        // Normalize movement input to prevent faster diagonal movement
        if (PlayerInput.magnitude > 1f)
        {
            PlayerInput.Normalize();
        }

        // Convert input to world space direction
        Vector3 MoveVector3 = transform.TransformDirection(PlayerInput);

        // Smooth movement along the ground
        CurrentMoveVelocity = Vector3.SmoothDamp(
            CurrentMoveVelocity,
            MoveVector3 * moveSpeed,
            ref MoveDampVelocity,
            MoveSmoothTime
        );

        // Apply movement (horizontal + gravity)
        Controller.Move(CurrentMoveVelocity * Time.deltaTime);
        Controller.Move(CurrentForceVelocity * Time.deltaTime);
    }
    public void Gravity()
    { 
        CurrentForceVelocity.y -= gravityStrength * Time.deltaTime;
    }
    void PlayerCamera()
    {
        if (Input.GetMouseButton(1)) // Right-click for camera control
        {
            // Rotate the player on the Y-axis (horizontal mouse movement)
            float mouseX = Input.GetAxis("Mouse X") * lookSpeed;
            transform.Rotate(0, mouseX, 0);

            // Rotate the camera on the X-axis (vertical mouse movement)
            float mouseY = Input.GetAxis("Mouse Y") * lookSpeed;

            verticalRotation -= mouseY;
            verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);

            playerCamera.transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
        }
    }
    public void PlayerAlive()
    {
        if (currentHP <= 0)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver Screen");
        };
    }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this; // Assign the singleton instance
        }
        else
        {
            Destroy(gameObject); // Ensure only one instance exists
        }
        UserInventory.Add(new Dagger());
        UserInventory.Add(new StraightSword());
        UserInventory.Add(new Bow());
        UserInventory.Add(new AXE());
        UserInventory.Add(new HealthPotion());

        for (int i = 0; i < UserInventory.Count; i++)
        {
            itembuttons[i].thisItem = UserInventory[i];
        }
        setPlayerInventory();
    }
    public void setPlayerInventory()
    {
        Item.PutPlayerInvetory(this);
    }
    public void AddItem(Item newItem)
    {
        Debug.LogWarning("WE ADDED ITEM?");
        UserInventory.Add(newItem);
    }
    public void RemoveItem(Item ItemData)
    {
        UserInventory.Remove(ItemData);
    }


}