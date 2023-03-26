using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using System.Net.Http;
using System;
using System.Text;

public class Player : MonoBehaviour
{
    public float moveSpeed = 10;
    public float rotateSpeed = 20;
    public Rigidbody rb;
    public bool toggleSelected;
    public healthBar healthBar;
    public bool blueWall;
    public bool isBeingCarried;
    public string name;
    public GameObject Brute;
    public Vector3 liftPos;
    public Vector3 directionRotate;
    public Vector3 directionMove;
    public bool fixPosition = false;
    public bool fixRotation = false;
    public int controllingPlayer = 0;
    public Vector3 startPos;
    public float breathRemaining = 5f;
    public bool touchingAirBubble = false;
    public bool inWater = false;
    public Animator anim;

    public float currentHealth;
    public float maxHealth = 100f;

    public GameObject lose_condition;
    public Lose_Conditions lose_condition_script;

    public bool batteryDead;
    public bool isDying = false;

    public Vector2 moveInputValue;
    public string[] Controllers;

    public bool available = true;
    public bool ActivateCircle = false;

    public List<Image> circles;

    public TimeBarSat Timer;

    void Start()
    {
        startPos = new Vector3(47f, 1.29f, -246f);
        startPos = transform.position;
        Controllers = Input.GetJoystickNames();
    }


    public virtual void setCurrentPlayer(int player)
    {
        return;
    }

    public void makeUnavailable(int playerIndex)
    {
        circles[playerIndex].enabled = true;
        available = false; 
    }

     public void makeAvailable()
    {
        foreach(Image circle in circles)
        {
            circle.enabled = false;
        }
        available = true;
    }

    void Update()
    {
        if(inWater)
        {
            if(!touchingAirBubble)
            {
                drowning();
            }
        }

        if(currentHealth <= 0)
        {
            print(name +" dead");
        }
    }

    public virtual void Movement(float x, float y)
    {

    }
    public virtual void cameraMovement(float x, float y)
    {

    }
    public virtual void CameraLookAtChangeNext()
    {   

    }
    public virtual void CameraLookAtChangePrevious()
    {

    }
    public void inAir()
    {
    }

    public void toggleFixPosition()
    {
        fixPosition = !fixPosition;
    }
    public void toggleFixRotation()
    {
        fixRotation = !fixRotation;
    }

    public void toggleIsBeingCarried()
    {
        if(!isBeingCarried)
        {
            
            GetComponent<Rigidbody>().useGravity = false;
            isBeingCarried = !isBeingCarried; 
            transform.position = Brute.transform.TransformPoint(liftPos);
            gameObject.AddComponent<FixedJoint>();
            gameObject.GetComponent<FixedJoint>().connectedBody=Brute.GetComponent<Rigidbody>();
            
        }
        else if(isBeingCarried)
        {
                isBeingCarried = !isBeingCarried; 
                Destroy(gameObject.GetComponent<FixedJoint>());
                GetComponent<Rigidbody>().useGravity = true;  
        }
    }

    public virtual void highGravityEnter ()
    {
        moveSpeed = 2;
    }
    public virtual void highGravityExit ()
    {
        moveSpeed = 10;
    }
    public virtual void drowning()
    {
        if (breathRemaining > 0)
        {
            breathRemaining -= Time.deltaTime;
        }
    }
    public void waterEnter()
    {
        inWater = true;
    }
    public virtual void pumpAirBubbleEnter()
    {
        breathRemaining = 5f;
        touchingAirBubble = true;
    }
    void pumpAirBubbleExit()
    {
        touchingAirBubble = false;
    }

    public void changeStartPos(Vector3 newStartPos)
    {
        startPos = newStartPos;
    }

    public IEnumerator returnToStart(string deathAnimation)
    {
        print(deathAnimation);
        anim.Play(deathAnimation);
        currentHealth = currentHealth - 20f;
        fixPosition = !fixPosition;
        yield return new WaitForSeconds(1);
        transform.position = startPos;
        rb.velocity = new Vector3(0,0,0);
        inWater = false;
        breathRemaining = 5f;
        yield return new WaitForSeconds(2);
        fixPosition = !fixPosition;
        isDying = false;
    }
    public virtual void waterExit()
    {
        inWater = false;
        breathRemaining = 5f;
    }

    public void restoreHealth()
    {
        while(currentHealth < maxHealth)
        {
            currentHealth+= 0.05f;
        }
    }
        public IEnumerator BotSprint()
    {
        moveSpeed = 15;
        yield return new WaitForSeconds(.3f);
        moveSpeed = 7;
        yield return new WaitForSeconds(4);
    }
}