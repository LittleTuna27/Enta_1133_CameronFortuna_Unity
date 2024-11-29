using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Manages the in-game HUD and menu systems
public class InGameHUD : MonoBehaviour
{
    [SerializeField] private Image HealthBar;  // Health bar UI
    private GameManager manager;
    [SerializeField] private GameObject Settings;    // Pause menu
    [SerializeField] private GameObject StartMenu;   // Start menu
    [SerializeField] private TextBox textBox;       // TextBox reference for room descriptions
    [SerializeField] private TMP_Text CurrentRoom; // Reference to TMP_Text component
    [SerializeField] private TMP_Text HP; // Reference to TMP_Text component
    [SerializeField] private string playersHP; // Reference to TMP_Text component

    public bool _isPaused = false;   // Tracks whether the game is paused

    void Update()
    {
        OnHealthChange();
        // Toggle pause menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseMenu();
        }
        currentHP();
    }
    public void CurrentPlayerRoom()
    { 
        string roomName = manager.User._currentRoom.roomName;
        //CurrentRoom = "{roomName}";
     }
    public void currentHP()
    {

        playersHP = $"{ manager.User.currentHP } / {manager.User.maxHp} ";
            //CurrentRoom = "{roomName}";
            HP.text = playersHP;
    }
    public void SetGameManager(GameManager NONmanager)
    {
        manager = NONmanager;
    }
    public void ButtonStartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("LevelTesting");
    }

    public void PauseMenu()
    {
        _isPaused = !_isPaused;
        Time.timeScale = _isPaused ? 0 : 1;
        Settings.SetActive(_isPaused);
    }

    public void ExitGame()
    {
        Debug.Log("Exit Game");
        Application.Quit();
    }

    // Updates the health bar UI
    public void OnHealthChange( )
    {
        HealthBar.fillAmount = manager.User.currentHP / manager.User.maxHp;
    }

    // Displays or hides the text box for room descriptions
    public void TriggerTextBox()
    {
        textBox.OpenText();
    }
    public void UpdateTextBox(string s)
    {
        
        textBox.UpdateRoomText(s);
    }

    public void TriggerTextBoxClose()
    {
        textBox.CloseText();
    }
 }