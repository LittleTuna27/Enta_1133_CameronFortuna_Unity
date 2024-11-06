using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class GameManager : MonoBehaviour 
 {
    [SerializeField] public MapManager GameRoomPrefabs;
    [SerializeField] private PlayerController PlayerPrefab;
    public User User;
    public MapManager _gameMap;
    private PlayerController _playerController;

    public void Start()
    {
        Debug.Log("GameManager Start Begins");
        // Zero our manager's position
        transform.position = Vector3.zero;
        _gameMap.CreateMap();
        SpawnPlayer();
        StartGame();
        Debug.Log("GameManager Start Complete");

    }
    private void SpawnPlayer()
    {
        Debug.Log("GameManager SpawnPlayer Begins");

        // Pick a random starting room - this must be done only after the map is created

        // Create the player
        _playerController = Instantiate(PlayerPrefab, transform);

        // Set the initial position
        _playerController.transform.position = new Vector3(0, 1, 0);

        // Call the Player Setup function
        _playerController.Setup();
        Debug.Log("GameManager SpawnPlayer Complete");
    }

    public void StartGame()
    {
        //intro
        Debug.Log("Game Started");
       //var randomStartingRoom = _gameMap.Rooms.Elementat(Random.Range(0, _gameMap.Rooms.Keys.Count));
    }
}

