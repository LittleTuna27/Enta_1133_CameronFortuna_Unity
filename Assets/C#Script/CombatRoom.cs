using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class CombatRoom : BaseRoom
{
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

