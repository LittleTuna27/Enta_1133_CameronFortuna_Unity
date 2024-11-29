using UnityEngine;

public class BaseRoom : MonoBehaviour
{
     public GameObject NorthDoorway;
     public GameObject EastDoorway;
     public GameObject SouthDoorway;
     public GameObject WestDoorway;

    // public TMP_Text roomText; // Reference to the TextMeshPro RoomDescription

    [SerializeField] protected string RoomEnter;
    [SerializeField] protected string RoomMessage;
    [SerializeField] protected string RoomExit;
    [SerializeField] protected GameManager gameManager;
    private User User;
    //public PlayerInventory PlayerI;
    public string roomName;
    public virtual void SetGameManager(GameManager NONmanager, User user /*PlayerInventory PlayerInventory*/)
    {
        gameManager = NONmanager;
        User = user;
        //PlayerI = PlayerInventory;
    }
    public void SetRoomLocation(Vector2 coords)
    {
        //move rooms cordinatrs x and z to the new position based on where it is spawning
        transform.position = new Vector3(coords.x, 0, coords.y);
    }
    public virtual void OnRoomEntered()
    {
        //roomText.text = "Base Room Entered";
        Debug.Log("Base Room Entered");
        Object.FindFirstObjectByType<InGameHUD>().TriggerTextBox();
        Object.FindFirstObjectByType<InGameHUD>().UpdateTextBox(RoomEnter);

    }
    public virtual void OnRoomSearched()
    {
        Object.FindFirstObjectByType<InGameHUD>().UpdateTextBox(RoomMessage);
    }

    public virtual void OnRoomExited()
    {
        //roomText.RoomDescription = "Base Room Exited";
        Debug.Log("Base Room Exited");
        Object.FindFirstObjectByType<InGameHUD>().TriggerTextBoxClose(); // Capitalized "T" for consistency
        Object.FindFirstObjectByType<InGameHUD>().UpdateTextBox(RoomExit);
    }

    public virtual void OnTriggerEnter(Collider otherObject)
    {
        if(otherObject.tag == "Player")
        {
            otherObject.GetComponent<User>()._currentRoom = this;
        }
        OnRoomEntered();
    }
    //public void OnTriggerStay(Collider otherObject)
    //{
    //   // OnRoomSearched();
    //}
    public void OnTriggerExit(Collider otherObject)
    {
        OnRoomExited();
    }
}


