using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UIElements;


public class BaseRoom : MonoBehaviour
{
    [SerializeField] public GameObject NorthDoorway;
    [SerializeField] public GameObject EastDoorway;
    [SerializeField] public GameObject SouthDoorway;
    [SerializeField] public GameObject WestDoorway;
    
    public void SetRoomLocation(Vector2 coords, int scale)
    {
        //move rooms cordinatrs x and z to the new position based on where it is spawning
        transform.position = new Vector3(coords.x, 0, coords.y);
        
    }
    private void OnTriggerEnter(Collider otherObject)
    {
        Debug.Log("wark");
    }
    private void OnTriggerStay(Collider otherObject)
    {
        Debug.Log("Bork");
    }
    private void OnTriggerExit(Collider otherObject)
    {
        Debug.Log("GRRRRRR");
    }
}


