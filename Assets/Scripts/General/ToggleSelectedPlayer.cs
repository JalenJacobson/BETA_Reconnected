using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleSelectedPlayer : MonoBehaviour
{
    public int selectedHeroIndex;
    public GameObject Gears;
    public GameObject Luz;
    public GameObject Brute;
    public GameObject Pump;
    public GameObject Sat;
    public GameObject Main_Camera;
    GearMove gearMove_script;
    LuzMove luzMove_script;
    BruteMove bruteMove_script;
    PumpMove pumpMove_script;
    SatMove satMove_script;

    public GameObject buttonGear;
    public GameObject buttonLuz;
    public GameObject buttonBrute;
    public GameObject buttonPump;
    public GameObject buttonSat;
    public GearChange gearButton_script;
    LuzChange luzButton_script;
    public BruteChange bruteButton_script;
    PumpChange pumpButton_script;
    SatChange satButton_script;
    
    GearbotLevelInteraction gearbotLevelInteraction_script;
    BruteBotLevelInteraction bruteBotLevelInteraction_script;
    
    CameraFollow cameraFollow_script;

    public int playerCount = 0;

    public GameObject[] gameObjects;
    public Player[] players;

    public int isLocalPlayerInt;

    public int frameCount;

    // Start is called before the first frame update
    void Start()
    {
        
        getMoveScripts();
        getButtonScripts();
        isLocalPlayerInt = PlayerPrefs.GetInt("selectedHero");
        cameraFollow_script = Main_Camera.GetComponent<CameraFollow>();
        gameObjects = new GameObject[] {Gears, Luz, Brute, Pump, Sat};
        players = new Player[] {gearMove_script, luzMove_script, bruteMove_script, pumpMove_script, satMove_script};
        setSelected(isLocalPlayerInt);
        selectCameraFollow();

    }

    public void getButtonScripts()
    {
        gearButton_script = buttonGear.GetComponent<GearChange>();  
        luzButton_script = buttonLuz.GetComponent<LuzChange>();
        bruteButton_script = buttonBrute.GetComponent<BruteChange>();
        pumpButton_script = buttonPump.GetComponent<PumpChange>();
        satButton_script = buttonSat.GetComponent<SatChange>();
    }

    public void getMoveScripts()
    {
        gearMove_script = Gears.GetComponent<GearMove>();  
        luzMove_script = Luz.GetComponent<LuzMove>();
        bruteMove_script = Brute.GetComponent<BruteMove>();
        pumpMove_script = Pump.GetComponent<PumpMove>();
        satMove_script = Sat.GetComponent<SatMove>();
    }

    void Update()
    {
        frameCount ++;
        if (Input.GetKeyDown("t"))
        {
            if(playerCount >= 5)
            {
                return;
            }
            Toggle();
        }

        if(frameCount%20 == 0 )
        {
            updatePlayerCount();
        }
    }

    public void selectCameraFollow()
    { 
        for (int i = 0; i < players.Length; i++) 
        {
            var p = players[i];
            if(p.isLocalPlayer)
            {
                cameraFollow_script.togglePlayerFollow(gameObjects[i]);
            }
        }
    }

    public void deselectMove()
    {
        gearMove_script.isLocalPlayer = false;
        luzMove_script.isLocalPlayer = false;
        bruteMove_script.isLocalPlayer = false;
        pumpMove_script.isLocalPlayer = false;
        satMove_script.isLocalPlayer = false;
        sendAllState();
    }

    public void sendAllState()
    {
        gearMove_script.sendState();
        luzMove_script.sendState();
        bruteMove_script.sendState();
        pumpMove_script.sendState();
        satMove_script.sendState();
    }

    public void updatePlayerCount()
    {
        playerCount = 0;
        //note for how to refactor. 
        for(int i = 0; i< players.Length - 1; i++)
        {
            if(players[i].toggleSelected)
            {
                playerCount ++;
            }
        }
    }

    public void Toggle()
    {
        players[isLocalPlayerInt].toggleSelected = false;
        checkAndSelect();   
    }
    
    public void setSelected(int newLocalPlayer)
    {
        deselectMove();
        print("loook heeere" + newLocalPlayer);
        players[newLocalPlayer].isLocalPlayer = true;
        players[newLocalPlayer].toggleSelected = true;
        print(players[newLocalPlayer].toggleSelected);
        cameraFollow_script.togglePlayerFollow(gameObjects[newLocalPlayer]);
        sendAllState();
    }

    public void checkAndSelect()
    {
        if(isLocalPlayerInt < players.Length - 1)
        {
            isLocalPlayerInt ++;  
        }
        else
        {
            isLocalPlayerInt = 0;
        }

        if(!players[isLocalPlayerInt].toggleSelected)
        {
            setSelected(isLocalPlayerInt);
        }
        else
        {
            checkAndSelect();
        }
    }
}

    // public void selectStartHero()
    // {
    //    if(selectedHeroIndex == 1)
    //    {
    //        selectGear();
    //    }
    //    if(selectedHeroIndex == 2)
    //    {
    //        selectLuz();
    //    }
    //    if(selectedHeroIndex == 3)
    //    {
    //        selectBrute();
    //    }
    //    if(selectedHeroIndex == 4)
    //    {
    //        selectPump();
    //    }
    //    if(selectedHeroIndex == 5)
    //    {
    //        selectSat();
    //    }
    // }

    // public void deselectAll()
    // {
    //     deselectMove();
    //     deselectButton();
    // }

    // public void deselectMove()
    // {
    //     gearMove_script.toggleSelected = false;
    //     luzMove_script.toggleSelected = false;
    //     bruteMove_script.toggleSelected = false;
    //     pumpMove_script.toggleSelected = false;
    //     satMove_script.toggleSelected = false;
    // }

    // public void deselectButton()
    // {
    //     gearButton_script.Stop();
    //     luzButton_script.Stop();
    //     bruteButton_script.Stop();
    //     pumpButton_script.Stop();
    //     satButton_script.Stop();
    // }

    // public void selectGear()
    // {
    //     deselectAll();
    //     gearMove_script.toggleSelected = true;
    //     gearButton_script.Play();
    //     cameraFollow_script.togglePlayerFollow(Gears);
    // }
    // public void selectLuz()
    // {
    //     deselectAll();
    //     luzMove_script.toggleSelected = true;
    //     luzButton_script.Play();
    //     cameraFollow_script.togglePlayerFollow(Luz);
    // }
    // public void selectBrute()
    // {
    //     deselectAll();
    //     bruteMove_script.toggleSelected = true;
    //     bruteButton_script.Play();
    //     cameraFollow_script.togglePlayerFollow(Brute);
    // }
    // public void selectPump()
    // {
    //     deselectAll();
    //     pumpMove_script.toggleSelected = true;
    //     pumpButton_script.Play();
    //     cameraFollow_script.togglePlayerFollow(Pump);
    // }
    // public void selectSat()
    // {
    //     deselectAll();
    //     satMove_script.toggleSelected = true;
    //     satButton_script.Play();
    //     cameraFollow_script.togglePlayerFollow(Sat);
    // }

    // public void Toggle()
    // {

    //     {
    //         //gear to luz
    //         if(gearMove_script.toggleSelected == true){
    //             selectLuz();
    //             // cameraFollow_script.togglePlayerFollow(Luz);
    //         }
            
    //         //luz to brute
    //         else if(luzMove_script.toggleSelected == true){
    //             selectBrute();
    //             // cameraFollow_script.togglePlayerFollow(Brute);
    //         }
            
    //         //brute to pump
    //         else if(bruteMove_script.toggleSelected == true){
    //             selectPump();
    //             // cameraFollow_script.togglePlayerFollow(Pump);
    //         }
            
    //         //pump to sat
    //         else if(pumpMove_script.toggleSelected == true){
    //             selectSat();
    //             // cameraFollow_script.togglePlayerFollow(Sat);
    //         }
    //         //sat to gears
    //         else if(satMove_script.toggleSelected == true){
    //             selectGear();
    //             // cameraFollow_script.togglePlayerFollow(Gears);
    //         }
    //     }
        
    // }
// }
