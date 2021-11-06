using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Http;
using System;
using System.Text;

public class UpdateSelected : MonoBehaviour
{
    private static readonly HttpClient client = new HttpClient();
    public GameObject Gears;
    public GameObject Luz;
    public GameObject Brute;
    public GameObject Pump;
    public GameObject Sat;

    private GearsSelect GearsSelect_Script;
    private LuzSelect LuzSelect_Script;
    private BruteSelect BruteSelect_Script;
    private PumpSelect PumpSelect_Script;
    private SatSelect SatSelect_Script;

    private int frameCount = 0;

    void Start()
    {
        GearsSelect_Script = Gears.GetComponent<GearsSelect>();  
        LuzSelect_Script = Luz.GetComponent<LuzSelect>();  
        BruteSelect_Script = Brute.GetComponent<BruteSelect>();  
        PumpSelect_Script = Pump.GetComponent<PumpSelect>();  
        SatSelect_Script = Sat.GetComponent<SatSelect>();  
    }

    // Update is called once per frame
    void Update()
    {
        frameCount++;
        if(frameCount%10 == 0)
        {
            updateSelected();
        }
    }

    async void updateSelected()
    {
        // var positionResponse = await client.PostAsync("http://74.207.254.19:7000/selectedstates", new StringContent("{\"name\": \"gears\"}", Encoding.UTF8, "application/json"));
        var positionResponse = await client.PostAsync("http://localhost:7000/selectedstates", new StringContent("{\"name\": \"gears\"}", Encoding.UTF8, "application/json"));
        var positionResponseString = await positionResponse.Content.ReadAsStringAsync();
        var robots = JsonUtility.FromJson<RobotsSelectedStates>(positionResponseString);
        // Gears
        GearsSelect_Script.isSelected = robots.Gears.isSelected;
        // Luz
        LuzSelect_Script.isSelected = robots.Luz.isSelected;
        
        // Brute
        BruteSelect_Script.isSelected = robots.Brute.isSelected;
        
        // Pump
        PumpSelect_Script.isSelected = robots.Pump.isSelected;
        
        // Sat
        SatSelect_Script.isSelected = robots.Sat.isSelected;
        
    }
}

[Serializable]
public class RobotsSelectedStates
{
    public SelectedState Gears;
    public SelectedState Luz;
    public SelectedState Brute;
    public SelectedState Pump;
    public SelectedState Sat;
}