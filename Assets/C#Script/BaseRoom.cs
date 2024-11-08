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
    
    public void SetRoomLocation(Vector2 coords)
    {
        //move rooms cordinatrs x and z to the new position based on where it is spawning
        transform.position = new Vector3(coords.x, 0, coords.y);
        
    }
    public void OnRoomEntered()
    {
        Debug.Log("Base Room Entered");
    }
    public void OnRoomSearched()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Base Room Searched");
        }
    }
    public void OnRoomExited()
    {
        Debug.Log("Base Room Exited");
    }
    private void OnTriggerEnter(Collider otherObject)
    {
        OnRoomEntered();
    }
    private void OnTriggerStay(Collider otherObject)
    {
        OnRoomSearched();
    }
    private void OnTriggerExit(Collider otherObject)
    {
        OnRoomExited();
    }
}


