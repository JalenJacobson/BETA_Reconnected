using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PumpMove : Player
{
    public GameObject PumpBlueWall;
    public BlueWall pumpBlueWall_script;
    public string moveAxisHorizontal;
    public string moveAxisVertical;
    public string special;
    public string specialController;
    public bool bubbleOpen;
    public string playerNumber;
    public bool airBlow = false;
    public ParticleSystem air;
    public ParticleSystem air2;
    public bool drainWater = false;
    public ParticleSystem runningWater;
    public ParticleSystem WaterDrops;
    public bool fireBurn = false; 
    

    void Awake()
     {
        playerNumber = PlayerPrefs.GetString("PumpPlayerNumber");
        
     }

    void Start()
    {   
        name = "Pump";
        currentHealth = maxHealth;
        pumpBlueWall_script = PumpBlueWall.GetComponent<BlueWall>();
        startPos = transform.position;
        anim = GetComponent<Animator>();
        healthBar.setHealth(maxHealth);  
        lose_condition = GameObject.Find("Lose_Conditions");
        lose_condition_script = lose_condition.GetComponent<Lose_Conditions>(); 
        air = GameObject.Find("air").GetComponent<ParticleSystem>();  
        air2 = GameObject.Find("air2").GetComponent<ParticleSystem>();     
        runningWater = GameObject.Find("runningWater").GetComponent<ParticleSystem>();  
        WaterDrops = GameObject.Find("WaterDrops").GetComponent<ParticleSystem>();  
        getIconSelectors();
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
        
    }

    public override void setCurrentPlayer(int player)
    {
        controllingPlayer = player;
        playerNumber = "P" + player.ToString();
    }

    public override void Movement(float x, float y)
    {

        directionRotate = new Vector3(x, 0.0f, y);
        directionMove = new Vector3(x * moveSpeed, rb.velocity.y, y * moveSpeed);
        if(currentHealth <= 0) return;
        rb.velocity = directionMove;

        if (!fixRotation && directionRotate != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(directionRotate), rotateSpeed * Time.deltaTime);
            currentHealth = currentHealth - .05f;
            if(!airBlow && !drainWater && !fireBurn)
            {
                anim.Play("PumpWalk");
                moveSpeed = 10;
                air.Stop();
                air2.Stop();
                runningWater.Stop();
                WaterDrops.Stop();
            }
            else if(airBlow)
            {
                anim.Play("PumpBlowingHose");
                moveSpeed = 3;
                air.Play();
                air2.Play();
            }
            else if(drainWater)
            {
                anim.Play("PumpWaterHose");
                moveSpeed = 3;
                runningWater.Play();
                WaterDrops.Play();
            }
            else if(fireBurn)
            {
                anim.Play("fireBlow");
                moveSpeed = 3;
            }

        }

        
    }

    void Update()
    {
        if(shouldFollowTeamBot && available)
       {
            nav.SetDestination(botToFollowWhenUnoccupied.position);
       }

        healthBar.setHealth(currentHealth);

        if(currentHealth <= 0)
        {
            batteryDead = true;
            anim.Play("PumpDeadBattery");
            drainWater = false;
            airBlow = false;
            fireBurn = false;
            air.Stop();
            air2.Stop();
            runningWater.Stop();
            WaterDrops.Stop();
        }
        else if(currentHealth > 0)
        {
            batteryDead = false;
        }

        if(isBeingCarried == true)
        {
          anim.Play("PumpBeingCarried");  
        }
    }

        

    public void openBubble()
    {
        if(inWater == true)
        {
            if(bubbleOpen == false)
            {
                pumpBlueWall_script.Play();
                bubbleOpen = true;
            }
            else if(bubbleOpen == true)
            {
                pumpBlueWall_script.Stop();
                bubbleOpen = false;
            }
        }
        else return;
    }
    

    public void waterEnter()
    {
        inWater = true;
    }
    public void waterDrain()
    {
        drainWater = !drainWater;
        anim.Play("PumpWaterHose");
        moveSpeed = 3;
        runningWater.Play();
        WaterDrops.Play();
    }
    public void pumpBlow()
    {
        airBlow = !airBlow;
        anim.Play("PumpBlowingHose");
        moveSpeed = 3;
        air.Play();
        air2.Play();
    }
    public void pumpBurn()
    {
        fireBurn = !fireBurn;
        anim.Play("fireBlow");
        moveSpeed = 3;

    }
    public void waterExit()
    {
        inWater = false;
        bubbleOpen = false;
        pumpBlueWall_script.Stop();
    }
    public void armDown()
    {
        anim.Play("PumpWalk");
        drainWater = false;
        airBlow = false;
        fireBurn = false;
        air.Stop();
        air2.Stop();
        runningWater.Stop();
        WaterDrops.Stop();
    }

    public void death()
    {
        if(!isDying)
        {
            isDying = true;
            StartCoroutine(returnToStart("DeadPump"));
        }
        
    }

    public void HealBattery()
    {
        if(currentHealth <= 0)
            {
                StartCoroutine(Heal());
            }    
    }
    IEnumerator Heal()
    {
        anim.Play("PumpHealBattery");
        yield return new WaitForSeconds(2f);
        anim.Play("PumpIdle");
    }

}
