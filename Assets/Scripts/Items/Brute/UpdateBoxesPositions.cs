using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Http;
using System;
using System.Text;

public class UpdateBoxesPositions : MonoBehaviour
 {
//     public GameObject[] boxes;
//     public List<Box_Base> boxes_scripts;

//      public GameObject Brute;
//     public Player BruteMove_Script;
//     private static readonly HttpClient client = new HttpClient();

//     public int frameCount = 0;

//     // public GameObject Box;
//     // public Box_Base Box1_Script;
//     // Start is called before the first frame update
//     void Start()
//     {
//         BruteMove_Script = Brute.GetComponent<Player>();

//         boxes = GameObject.FindGameObjectsWithTag("Box");
        
//         for(int i = 0; i<boxes.Length; i++)
//         {
//             boxes_scripts.Add(boxes[i].GetComponent<Box_Base>());
//         }
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         frameCount++;
//         if(frameCount%100 == 0 && BruteMove_Script.isLocalPlayer != true)
//         {
//             // updateBoxStates();
//         }
        
//     }

    // BoxState getBoxState(BoxState[] states, string name)
    // {
    //     foreach(BoxState state in states)
    //     {
    //         if(state.name == name)
    //         {
    //             return state;
    //         }
    //     }
    //     var emptyBox = new BoxState();
    //     emptyBox.name = "empty";
    //     return emptyBox;
    //     // return false;
    // }

//     async void updateBoxStates()
//     {
//         // var positionResponse = await client.PostAsync("http://74.207.254.19:7000/boxstates", new StringContent("{\"name\": \"gears\"}", Encoding.UTF8, "application/json"));
//         var positionResponse = await client.PostAsync("http://localhost:7000/boxstates", new StringContent("{}", Encoding.UTF8, "application/json"));

//         var positionResponseString = await positionResponse.Content.ReadAsStringAsync();
//         var response = JsonUtility.FromJson<BoxStateResponse>(positionResponseString);
//         foreach(Box_Base script in boxes_scripts)
//         {
//             var boxStateResponse = getBoxState(response.boxStates, script.name);
//             script.rb.MovePosition(boxStateResponse.position.position);
//             // Box.transform.rotation = Quaternion.Slerp(Sat.transform.rotation, robots.Sat.position.rotation,  Time.deltaTime * rotationSpeed);
//         }
//     }
// }


// [Serializable]
// public class BoxStateResponse
// {
//     public BoxState[] boxStates;
 }
