using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1_Controller : Player
{
    public string moveAxisHorizontal;
    public string moveAxisVertical;
    //public string playerNumber;
    // Start is called before the first frame update
    
        void Awake()
     {
        //playerNumber = PlayerPrefs.GetString("PlayerPlayerNumber");
     }
    
    void Start()
    {
        anim = GetComponent<Animator>();
        name = "Player1";
        moveSpeed = 10f;
        currentHealth = maxHealth;
        healthBar.setHealth(maxHealth);
        lose_condition = GameObject.Find("Lose_Conditions");
        lose_condition_script = lose_condition.GetComponent<Lose_Conditions>();
        transform.position = startPos;
        getControls(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void setCurrentPlayer(int player)
    {
        controllingPlayer = player;
        //playerNumber = "P" + player.ToString();
        getControls();
    }

    void getControls()
    {
        moveAxisHorizontal = "Horizontal";
        moveAxisVertical = "Vertical";
    }


    public override void Movement()
    {
        //float horizontalMove = Input.GetAxis(moveAxisHorizontal);
        //float verticalMove = Input.GetAxis(moveAxisVertical);

        directionRotate = new Vector3(moveInputValue.x, 0.0f, moveInputValue.y);
        directionMove = new Vector3(moveInputValue.x * moveSpeed, rb.velocity.y, moveInputValue.y * moveSpeed);
        if(directionMove != Vector3.zero)
        {
            rb.velocity = directionMove;
            currentHealth = currentHealth - .03f;
        }

        if (!fixRotation && directionRotate != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(directionRotate), rotateSpeed * Time.deltaTime);
        }

        // rb.MovePosition(transform.position + moveSpeed * Time.deltaTime * direction);
        
    }
}
