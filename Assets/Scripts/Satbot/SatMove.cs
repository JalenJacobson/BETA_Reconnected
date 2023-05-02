using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SatMove : Player
{
    // public Animator anim;
    

    // public GameObject TimerBarSat;
    // TimeBarSat TimerBar_Script;
    
    public GameObject Rails;
    SatBotAnim Rails_Script;

    public string moveAxisHorizontal;
    public string moveAxisVertical;
    public string playerNumber;

    public float StartHealth = 100;

   // public GameObject MiniMap_Manager;
   // public MiniMap MiniMap_Script;
    public string special;
    public string specialController;
    // public Image P1Circle;
    // public Image P2Circle;

    public Vector2 moveInputValues;

    public GameObject MoveCamera;
    public MoveCamera MoveCamera_Script;
    public GameObject cameraLookatObject;
    public CameraLookAtObject cameraLookatObject_Script;
    public GameObject CameraLookAtSatControl;

    // public MoveCamera MoveCamera_Script;

    public bool controllingCamera = false;
    public bool gravaConnected = false;
    public float cameraMoveSpeed = 10;
    public GameObject CameraScreen;

    

    // public float currentHealth ;
    // public float maxHealth = 100f;

    void Awake()
     {
        playerNumber = PlayerPrefs.GetString("SatPlayerNumber");
        
     }

    void Start()
    {
        
        //MiniMap_Script = MiniMap_Manager.GetComponent<MiniMap>();
        anim = GetComponent<Animator>(); 
        name = "Sat";
        Rails_Script = Rails.GetComponent<SatBotAnim>();
        currentHealth = StartHealth;
        healthBar.setHealth(maxHealth);
        lose_condition = GameObject.Find("Lose_Conditions");
        lose_condition_script = lose_condition.GetComponent<Lose_Conditions>();
        MoveCamera = GameObject.Find("CinemachineCamera");
        cameraLookatObject = GameObject.Find("LookAtObject");
        cameraLookatObject_Script = cameraLookatObject.GetComponent<CameraLookAtObject>();
        CameraLookAtSatControl = GameObject.Find("CameraLookAtSatControl");
        MoveCamera_Script = MoveCamera.GetComponent<MoveCamera>();
        Timer.drowning(breathRemaining);
        startPos = transform.position;
        getIconSelectors();
        //nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
        
    }

    public override void setCurrentPlayer(int player)
    {
        controllingPlayer = player;
        playerNumber = "P" + player.ToString();
        //getControls();
    }

    // void getControls()
    // {
    //     if(playerNumber == "P0")
    //     {
    //         P1Circle.enabled = false;
    //         P2Circle.enabled = false;
    //     }
    //     else if(playerNumber == "P1")
    //     {
    //         moveAxisHorizontal = "Horizontal";
    //         moveAxisVertical = "Vertical";
    //         special = "space";
    //         specialController = "special1";
    //         P1Circle.enabled = true;
    //         P2Circle.enabled = false;
    //     }
    //     else if(playerNumber == "P2")
    //     {
    //         moveAxisHorizontal = "HorizontalPlayer2";
    //         moveAxisVertical = "VerticalPlayer2";
    //         special = "return";
    //         specialController = "special2";
    //         P1Circle.enabled = false;
    //         P2Circle.enabled = true;    
    //     }
    // }

    public override void Movement(float x, float y)
    {

        directionRotate = new Vector3(x, 0.0f, y);
        directionMove = new Vector3(x * moveSpeed, rb.velocity.y, y * moveSpeed);
        if(currentHealth <= 0) return;
        if(!controllingCamera)
        {
            if(!gravaConnected)
            {
                if(directionMove != Vector3.zero)
        {
            rb.velocity = directionMove;
            currentHealth = currentHealth - .03f;
        }
        else if(directionMove == Vector3.zero)
        {
            rb.velocity = Vector3.zero;
        }
                if (!fixRotation && directionRotate != Vector3.zero)
                {
                    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(directionRotate), rotateSpeed * Time.deltaTime);
                    currentHealth = currentHealth - .02f;
                    Rails_Script.rails();
                }
            }
            else if(gravaConnected)
            {
                moveInputValues = new Vector2(x,y);
            }
            
        }
        else if(controllingCamera)
        {
            MoveCamera_Script.rb.velocity = directionMove;
        }
        

        // rb.MovePosition(transform.position + moveSpeed * Time.deltaTime * direction);
        
    }

    public override void cameraMovement(float x, float y)
    {
        if(controllingCamera)
        {
            directionMove = new Vector3(x * cameraMoveSpeed, rb.velocity.y, y * cameraMoveSpeed);
            CameraLookAtSatControl.GetComponent<Rigidbody>().velocity = directionMove;
        }
        
    }

    public override void CameraLookAtChangeNext()
    {
        if(!controllingCamera) return;
        cameraLookatObject_Script.followBotNext();

    }
    public override void CameraLookAtChangePrevious()
    {
        if(!controllingCamera) return;
        cameraLookatObject_Script.followBotPrevious();
    }

    

        // public void ToggleCircle()
        // {
        //     P1Circle.enabled = true;  
        // }

        // public void ToggleCircleOff()
        // {
        //     P1Circle.enabled = false;  
        // }


    void Update()
    {
        //rb.AddForce(0, -100, 0);
        if(shouldFollowTeamBot && available)
        {
           // nav.SetDestination(botToFollowWhenUnoccupied.position);
            Follow.enabled = true;
            GetToFollow.enabled = false;
            coll.material = physicMaterial1;
            //rb.drag = 10;
            
        }
        else if(!shouldFollowTeamBot && available)
        {
            Follow.enabled = false;
            GetToFollow.enabled = true;
            coll.material = physicMaterial1;
           // rb.drag = 10;
           
        }
        else if(!available)
        {
            Follow.enabled = false;
            GetToFollow.enabled = false;
            if(currentHealth <= 0)
            {
                coll.material = physicMaterial1;
            }
            else if(currentHealth > 0)
            {
                coll.material = physicMaterial2;
            }
            //rb.drag = 0;
            
        }


        if(inWater == true)
        {
            if(touchingAirBubble == true)
            {
                // DangerState.text = "Danger State: Short Circuit - Delayed";
                // setConsoleDangerField("Circuit Field", blueCircuitField);
                // setConsoleDangerState("Short Circuit - Delayed", greenConsole);
               // TimerBar_Script.enterbluewall();
            }
            else
            {
                // DangerState.text = "Danger State: Short Circuit - Danger";
                // setConsoleDangerField("Circuit Field", blueCircuitField);
                // setConsoleDangerState("Short Circuit - Danger", redDanger);
                drowning();
            }
            
        }

        if(breathRemaining <= 0f)
        {
            StartCoroutine(returnToStart("DeadSat"));
            waterExit();
        }

        if(currentHealth <= 0)
        {
            batteryDead = true;
            anim.Play("SatDeadBattery");
            coll.material = physicMaterial1;
        }
        else if(currentHealth > 0)
        {
            batteryDead = false;
        }

        healthBar.setHealth(currentHealth);


        if(!controllingCamera)
        {
            CameraScreen.GetComponent<Animator>().Play("StopControllingCamera");
        }
        else if(controllingCamera)
        {
            CameraScreen.GetComponent<Animator>().Play("ControllingCamera");
        }
        //if (Input.GetKeyDown(special))
        //{
        //    MiniMap_Script.MiniMapToggle();
       // }
        //if (Input.GetButtonDown(specialController))
        //{
        //    MiniMap_Script.MiniMapToggle();
       // }
    }
    public void HealBattery()
    {
        print(currentHealth);
        if(currentHealth <= 0)
            {
                StartCoroutine(Heal());
            }    
    }

    IEnumerator Heal()
    {
        anim.Play("SatHealBattery");
        yield return new WaitForSeconds(2f);
        anim.Play("Idle");
    }

    public override void drowning()
    {
        // print("drowning");
        // TimerBar_Script.timerStart();
        if (breathRemaining > 0)
        {
            breathRemaining -= Time.deltaTime;
            Timer.drowning(breathRemaining);
        }
    }

    public override void waterExit()
    {
        // resetConsoleDangerField();
        // resetConsoleDangerState();
        // TimerBar_Script.timerStop();
        inWater = false;
        breathRemaining = 5f;
        Timer.drowning(breathRemaining);
    }

    public void death()
    {
        if(!isDying)
        {
            isDying = true;
            StartCoroutine(returnToStart("DeadSat"));
        }
        
    }

    public void connectGrava()
    {
        gravaConnected = !gravaConnected;
    }

    // public void restoreHealth()
    // {
    //     while(currentHealth < maxHealth)
    //     {
    //         currentHealth+= 0.05f;
    //         print(currentHealth);
    //     }
        
    // }
}
