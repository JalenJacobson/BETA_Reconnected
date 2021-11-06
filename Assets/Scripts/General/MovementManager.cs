using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager : MonoBehaviour
{
//Player Objects
     [SerializeField]
     public GameObject Player1;
     [SerializeField]
     public GameObject Player2;
 
 
     void Update () {
         //Check if players are assigned
         if(Player1 && Player2)
         {
             //Processing Player1 input for horizontal 
             //This does the trick: Input.GetAxis("HorizontalPlayer1")
             Player1.transform.position = new Vector3(Player1.transform.position.x + Input.GetAxis("HorizontalPlayer1"), Player1.transform.position.y, Player1.transform.position.z);
             //Processing Player1 input for vertical 
             Player1.transform.position = new Vector3(Player1.transform.position.x, Player1.transform.position.y + Input.GetAxis("VerticalPlayer1"), Player1.transform.position.z);
 
             //Processing Player2 input for horizontal 
             //This does the trick: Input.GetAxis("HorizontalPlayer2")
             Player2.transform.position = new Vector3(Player2.transform.position.x + Input.GetAxis("HorizontalPlayer2"), Player2.transform.position.y, Player2.transform.position.z);
             //Processing Player2 input for vertical 
             Player2.transform.position = new Vector3(Player2.transform.position.x, Player2.transform.position.y + Input.GetAxis("VerticalPlayer2"), Player2.transform.position.z);
         }
     }
}
