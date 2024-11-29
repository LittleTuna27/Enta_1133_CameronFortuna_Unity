using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;


public class MapManager : MonoBehaviour 
{
    [SerializeField] private int RoomSize = 3;
    public int MapWidth = 3; // Width of the map (grid width)
    public int MapHeight = 3; // Height of the map (grid height)
    [SerializeField] private BaseRoom[,] Rooms; // 2D array to keep track of room instances in the grid
    [SerializeField] private List<BaseRoom> AvailableRooms = new List<BaseRoom>(); // List of available rooms to instantiate
    [SerializeField] private List<BaseRoom> RefrecnedRooms = new List<BaseRoom>(); // List of available rooms to instantiate

    private GameManager gameManager;
    private User User;
    public void SetGameManager(GameManager NONmanager, User user/*, PlayerInventory PlayerI /*/)
    {
        gameManager = NONmanager;
        User = user;
    }
    public void CreateMap()
    {
        
        Rooms = new BaseRoom[MapWidth, MapHeight];
        for (int x = 0; x < MapWidth; x++)
        {
            for (int z = 0; z < MapHeight; z++)
            {
                //times the cordinates of the room by where it is being created so if its the secound one it wound be 1x2 so 2 then 2x2 so 4
                //example of x value same goes for z
                Vector2 coords = new Vector2(x * RoomSize, z * RoomSize);
                Debug.Log($"Creating room at coordinates: {coords}");
                // get a random int from the list of rooms available
                int roomRandomIndex = Random.Range(0, AvailableRooms.Count);

                // Instantiate a random room prefab based on the randomRoomIndex
                var roomInstance = Instantiate(AvailableRooms[roomRandomIndex], transform);

                roomInstance.SetGameManager(gameManager, User/*, PlayerInventory/*/);


                RefrecnedRooms.Add(roomInstance);
                //Remove the room Froom the list
                AvailableRooms.RemoveAt(roomRandomIndex);
                //set room index to its cordinates
                roomInstance.SetRoomLocation(coords);
                

                if (x > 0) roomInstance.WestDoorway.SetActive(false); // Open door to the west
                if (x < MapWidth - 1) roomInstance.EastDoorway.SetActive(false); // Open door to the east
                if (z > 0) roomInstance.SouthDoorway.SetActive(false); // Open door to the south
                if (z < MapHeight - 1) roomInstance.NorthDoorway.SetActive(false); // Open door to the north

            }
        }
    }
}

