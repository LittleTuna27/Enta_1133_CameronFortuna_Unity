using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Dictionary<Direction, int> _rotationByDirection = new()
    {
        { Direction.North, 0 },  // also 360
        { Direction.East, 90 },
        { Direction.South, 180 },
        { Direction.West, 270 }
    };

    public Direction _facingDirection;
    private bool isRoatating = false;
    [SerializeField] private float RotationTime = 0.5f;
    private float _rotationTimer = 0.0f;
    private Quaternion _previousRotation;

    public void Setup()
    {
        // Simple array of all directions
        Direction[] directions = new Direction[] { Direction.North, Direction.East, Direction.South, Direction.West };

        // Roll a random direction
        _facingDirection = directions[UnityEngine.Random.Range(0, directions.Length)];

        // Update the transform
        SetFacingDirection();
    }

    public void SetFacingDirection()
    {
        // Note: transform.rotation is type "Quaternion", we hate working with these
        // Get the transform's rotation, use eulerAngles for easier math (Vector3)
        Vector3 facing = transform.rotation.eulerAngles;

        facing.y = _rotationByDirection[_facingDirection];
        // Save the rotation back, converting it to a Quaternion first
        transform.rotation = Quaternion.Euler(facing);
    }

    public void Update()
    {
        bool rotateLeft = Input.GetKeyDown(KeyCode.A);
        bool rotateRight = Input.GetKeyDown(KeyCode.D);
        if (rotateLeft && !rotateRight)
        {
            TurnLeft();
        }
        else if (!rotateLeft && rotateRight)
        {
            TurnRight();
        }

    }
    public void TurnLeft()
    { 
        switch (_facingDirection)
        {
            case Direction.South:
                _facingDirection = Direction.East;
                break;
            case Direction.North:
                _facingDirection = Direction.West;
                break;
            case Direction.East:
                _facingDirection = Direction.North;
                break;
            case Direction.West:
                _facingDirection = Direction.South;
                break;
        }
        SetFacingDirection();
    }
    public void TurnRight()
    {
        switch (_facingDirection)
        {
            case Direction.South:
                _facingDirection = Direction.West;
                break;
            case Direction.North:
                _facingDirection = Direction.East;
                break;
            case Direction.East:
                _facingDirection = Direction.South;
                break;
            case Direction.West:
                _facingDirection = Direction.North;
                break;
        }
        SetFacingDirection();
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

