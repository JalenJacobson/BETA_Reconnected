using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpMove : Player
{
    // public float moveSpeed = 7;
    // public float rotateSpeed = 10;
    // public Rigidbody rb;
    // public bool toggleSelected;
    // private Vector3 direction;
    // public Vector3 startPos;
    // public bool fixPosition = false;
    // public Joystick joystick;

    public GameObject PumpBlueWall;
    public BlueWall pumpBlueWall_script;
    public bool BlueWallOpened;
    public Animator anim;
    public string moveAxisHorizontal;
    public string moveAxisVertical;

    void Awake()
    {
        moveAxisHorizontal = PlayerPrefs.GetString("PumpAxisHorizontal");
        moveAxisVertical = PlayerPrefs.GetString("PumpAxisVertical");
    }

    void Start()
    {
        name = "Pump";
        startPos = new Vector3(-157f, 0.7f, -120f);
        transform.position = startPos;
        anim = GetComponent<Animator>();
        orangeGravityField = new Color(0.689f, 0.452f, 0.016f, 1.000f);
        greenConsole = new Color(0.0f, 1.0f, 0.1144f, 1.0f);
        blueCircuitField = new Color(0.06799023f, 0.5f, 0.8584906f, 1.0f);
        redDanger = new Color(1f, 0.1f, 0.0f, 1.0f);
        pumpBlueWall_script = PumpBlueWall.GetComponent<BlueWall>();
    }

    // void FixedUpdate()
    // {
    //     if (toggleSelected == true && fixPosition == false){
    //         Movement();
    //     }
        
    // }

    public override void Movement()
    {
        float horizontalMove = Input.GetAxis(moveAxisHorizontal);
        float verticalMove = Input.GetAxis(moveAxisVertical);

        direction = new Vector3(horizontalMove, 0.0f, verticalMove);

        if (direction != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotateSpeed * Time.deltaTime);
            anim.Play("PumpWalk");
        }
        rb.MovePosition(transform.position + moveSpeed * Time.deltaTime * direction);
        sendPos();
    }

    void Update()
    {
        if(blueWall == true && BlueWallOpened == false)
        {
            pumpBlueWall_script.Play();
            BlueWallOpened = true;
        }
        else if(blueWall == false)
        {
            pumpBlueWall_script.Stop();
            BlueWallOpened = false;
        }
    }

    // public void toggleSelectedState (){
    //     toggleSelected = !toggleSelected;
    // }
    // public void toggleFixPosition()
    // {
    //     print("togglefixpos");
    //     fixPosition = !fixPosition;
    // }

    // public void highGravityEnter ()
    // {
    //     moveSpeed = 1;
    // }
    // public void highGravityExit ()
    // {
    //     moveSpeed = 10;
    // }
    public void BlueWallOpen()
    {
        blueWall = true;
        print("NUMBER2 this should open wall "+blueWall);
        sendState();
        //  anim.Play("BlueWallOpen");
    }
    public void BlueWallClose()
    {
        blueWall = false;
        sendState();
    }
}
