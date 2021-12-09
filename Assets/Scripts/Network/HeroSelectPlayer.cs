using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Http;
using System;
using System.Text;

public class HeroSelectPlayer : MonoBehaviour
{
    private static readonly HttpClient client = new HttpClient();
    public bool isSelected;
    public bool isLocalPlayer;
    public bool isUp;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public async void sendState()
    {
        //var robot = new SelectedState();
        //robot.name = name;
       // robot.isSelected = isSelected;
       // string json = JsonUtility.ToJson(robot);
        // var response = await client.PostAsync("http://74.207.254.19:7000/selectedstate/save", new StringContent(json, Encoding.UTF8, "application/json"));
        // var response = await client.PostAsync("http://localhost:7000/selectedstate/save", new StringContent(json, Encoding.UTF8, "application/json"));
        // var responseString = await response.Content.ReadAsStringAsync();
    }
}

// [Serializable]
// public class SelectedState
// {
//     public string name;
//     public bool isSelected;
// }

// [Serializable]
// public class ItemState
// {
//     public bool GearsIDI_Active;
// }

