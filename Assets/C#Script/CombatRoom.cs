using UnityEngine;

public class CombatRoom : BaseRoom
{
    public GameObject enemy;          // Reference to the enemy
    public GameObject player;         // Reference to the player
    public Vector3 roomCenter;        // The center of the room (you can set this manually or use the actual center)
    public float roomWidth = 10f;     // Room's width (used for layout purposes)
    public float roomHeight = 10f;    // Room's height (used for layout purposes)
    public float roomDepth = 10f;     // Room's depth (for 3D room layout)
    public bool inCombatRoom = false;

    public int computerHealth = 30; //enemy health
    public int computerDamadge = 0; //enemy damadge
    public int computerDicePicked = 0;

    public Item ItemV; // Ensure this is assigned in Inspector

    public override void OnRoomEntered()
    {
        Debug.Log("Combat Room entered");
        inCombatRoom = true;
        //gameManager.User.moveSpeed = 0;
        Object.FindFirstObjectByType<InGameHUD>().TriggerTextBox();
        Object.FindFirstObjectByType<InGameHUD>().UpdateTextBox(RoomEnter);
    }
    public void Update()
    {
        FacePlayer();
       /*if (!ItemV.ItemUsed)
        {
            computerTakeDamage();
            CPUDamadge();
            ItemV.ItemUsed = false;
        }*/
    }
    // This function makes the enemy always face the player
    public void FacePlayer()
    {
        // Ensure player and enemy are not null
        if (player == null || enemy == null)
        {
            Debug.LogError("Player or Enemy is not assigned in CombatRoom!");
            return;
        }

        // Calculate the direction from the enemy to the player
        Vector3 direction = player.transform.position - enemy.transform.position;

        if (direction.sqrMagnitude > 0) // Avoid dividing by zero if they are at the same position
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            enemy.transform.rotation = Quaternion.Slerp(enemy.transform.rotation, targetRotation, Time.deltaTime * 5f);
        }
    }
    public void CPUDamadge()
    {
        if (computerHealth > 0)
        {
            computerDamadge = Random.Range(0, 15);
            gameManager.User.currentHP -= computerDamadge;
        }
    }
    public void computerTakeDamage()
    {
        if (ItemV is WeaponBase weapon)
        {
            int damage = ItemV.ActionPoints;
            computerHealth -= damage;

        }
    }
}