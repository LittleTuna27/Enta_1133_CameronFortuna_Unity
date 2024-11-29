using UnityEngine;

public class GameManager : MonoBehaviour
{
    public User User;
    [SerializeField] private MapManager _gameMap;
    [SerializeField] private InGameHUD InGameHUD;
    [SerializeField] private GameObject textBox;
    [SerializeField] private BaseRoom BaseRoom;
    [SerializeField] private HealthPotion HealthPotion;
    public void Start()
    {
        _gameMap.SetGameManager(this, User /*PlayerI*/);
        InGameHUD.SetGameManager(this);
        BaseRoom.SetGameManager(this, User /*PlayerI*/);
        HealthPotion.SetGameManager(this);
        Debug.Log("GameManager Start Begins");
        transform.position = Vector3.zero;
        _gameMap.CreateMap();
        SpawnPlayer();
        StartGame();
        Debug.Log("GameManager Start Complete");
    }

    public void SpawnPlayer()
    {
        Debug.Log("GameManager SpawnPlayer Begins");
        User = Instantiate(User, transform);
        User.transform.position = new Vector3(0, 1, 0);
        Debug.Log("GameManager SpawnPlayer Complete");
    }
    public void StartGame()
    {
        Debug.Log("Game Started");
        // Add any additional game-start logic here
    }
}
