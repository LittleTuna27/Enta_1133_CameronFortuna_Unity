using UnityEngine;

public class HealRoom : BaseRoom
{
    public bool runesUsed = true;
    public override void OnRoomSearched()
    {
        
        if (runesUsed)
        {
            int step = Random.Range(0, 2); // Fifty-fifty choice to heal or damage
            switch (step)
            {
                case 0:
                    int healed = Random.Range(5, 10);
                    RoomMessage = $"You healed {healed}. Current HP: {gameManager.User.currentHP}";
                    gameManager.User.currentHP = Mathf.Min(gameManager.User.currentHP + healed, gameManager.User.maxHp); // Clamp to maxHp
                    Debug.Log($"You healed {healed}. Current HP: {gameManager.User.currentHP}");
                    runesUsed = false;
                    break;
                case 1:
                    int damaged = Random.Range(5, 10);
                    RoomMessage = $"You took {damaged} of damage. Current HP: {gameManager.User.currentHP}";
                    gameManager.User.currentHP = Mathf.Max(gameManager.User.currentHP - damaged, 0); // Clamp to zero
                    Debug.Log($"You took {damaged} damage. Current HP: {gameManager.User.currentHP}");
                    runesUsed = false;
                    break;
            }
        }
        else
        {
            RoomMessage = "You've already searched this room";
        }
    }
}