using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveNode : Player
{
    // public float moveSpeed = 10;
    // public float rotateSpeed = 10;
    // public Rigidbody rb;
    // public bool toggleSelected;
    // public Vector3 direction;
    // public bool fixPosition = false;
    // public Vector3 startPos;
    // public float breathRemaining = 5f;
    // public bool touchingAirBubble = false;
    // public bool inWater = false;
    // public Text DangerField;
    // public Text DangerState;
    // public Color orangeGravityField;
    // public Color greenConsole;
    // public Color blueCircuitField;
    // public Color redDanger;


    // public Joystick joystick;

    virtual public void Start()
    {
        name = "Node";
        startPos = new Vector3(-1482.761f, 81f, -1024.285f);
        transform.position = startPos;
    }

    
}
