using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class BaseRoom : MonoBehaviour
{
    [SerializeField] private GameObject NorthDoorway, EastDoorway, SouthDoorway, WestDoorway;
}
public class TreasureRoom : BaseRoom
{ 
    public override void SetRoomLocation(Vector2 coordinates) 
}
public class CombatRoom : RoomBase
{ 
    
}
