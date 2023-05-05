using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonNavigationManager : MonoBehaviour
{
    public GameObject Canvas, Brute, Pump, Luz, Gears, Sat, Beacon1, Beacon2, Beacon3, Beacon4, Beacon5, StartButton;
    public GameObject NewGame, NewGameWarning, NewGameCancel, NewGameReady, NewGameStart, NewGameNotReady;
    public GameObject Continue, ContinueCancel, ContinueReady, ContinueStart, ContinueNotReady;
    public GameObject BotSelect, BotSelectP1, BotSelectP2, BotSelectP3, BotSelectP4, BotSelectP5;
    //public GameObject Logo, TopLine, BottomLine;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void moveToGameTypeFromStart()
    {
        StartButton.SendMessage("newButtonsDown");
        NewGame.SendMessage("newButtons");
        Continue.SendMessage("newButtons");
        Canvas.SendMessage("SelectGameType");
    }
    
    public void moveToGameTypeFromContinue()
    {
        Brute.SendMessage("Down");
        Pump.SendMessage("Down");
        Luz.SendMessage("Down");
        Gears.SendMessage("Down");
        Sat.SendMessage("Down");
        Beacon1.SendMessage("Down");
        Beacon2.SendMessage("Down");
        Beacon3.SendMessage("Down");
        Beacon4.SendMessage("Down");
        Beacon5.SendMessage("Down");
        StartButton.SendMessage("newButtonsDown");
        NewGame.SendMessage("newButtons");
        Continue.SendMessage("newButtons");
        ContinueCancel.SendMessage("BackDown");
        ContinueReady.SendMessage("ReadyStop");
        Canvas.SendMessage("SelectGameType");
        BotSelect.SendMessage("Stop");
        BotSelectP1.SendMessage("Stop2");
        BotSelectP2.SendMessage("Stop2");
        BotSelectP3.SendMessage("Stop2");
        BotSelectP4.SendMessage("Stop2");
        BotSelectP5.SendMessage("Stop2");
    }

    public void moveToContinueFromGametype()
    {
        Brute.SendMessage("Up");
        Pump.SendMessage("Up");
        Luz.SendMessage("Up");
        Gears.SendMessage("Up");
        Sat.SendMessage("Up");
        Beacon1.SendMessage("Up");
        Beacon2.SendMessage("Up");
        Beacon3.SendMessage("Up");
        Beacon4.SendMessage("Up");
        Beacon5.SendMessage("Up");
        NewGame.SendMessage("newButtonsDown");
        Continue.SendMessage("newButtonsDown");
        ContinueCancel.SendMessage("Back");
        ContinueReady.SendMessage("ReadyStart");
        BotSelect.SendMessage("Initiate");
        BotSelectP1.SendMessage("Initiate2");
        BotSelectP2.SendMessage("Initiate2");
        BotSelectP3.SendMessage("Initiate2");
        BotSelectP4.SendMessage("Initiate2");
        BotSelectP5.SendMessage("Initiate2");
       // Logo.SendMessage("Initiate");
       // TopLine.SendMessage("Initiate");
       // BottomLine.SendMessage("Initiate");
        Canvas.SendMessage("callcontinueButton");
    }

    public void moveToWarningFromGametype()
    {
        NewGame.SendMessage("newButtonsDown");
        Continue.SendMessage("newButtonsDown");
        NewGameWarning.SendMessage("newButtons");
       // Logo.SendMessage("Initiate");
       // TopLine.SendMessage("Initiate");
       // BottomLine.SendMessage("Initiate");
        Canvas.SendMessage("Warning");
    }

    public void moveToNewGameFromWarning()
    {
        Brute.SendMessage("Up");
        Pump.SendMessage("Up");
        Luz.SendMessage("Up");
        Gears.SendMessage("Up");
        Sat.SendMessage("Up");
        Beacon1.SendMessage("Up");
        Beacon2.SendMessage("Up");
        Beacon3.SendMessage("Up");
        Beacon4.SendMessage("Up");
        Beacon5.SendMessage("Up");
        NewGameCancel.SendMessage("Back");
        NewGameReady.SendMessage("ReadyStart");
        NewGameWarning.SendMessage("newButtonsDown");
        BotSelect.SendMessage("Initiate");
        BotSelectP1.SendMessage("Initiate2");
        BotSelectP2.SendMessage("Initiate2");
        BotSelectP3.SendMessage("Initiate2");
        BotSelectP4.SendMessage("Initiate2");
        BotSelectP5.SendMessage("Initiate2");
        Canvas.SendMessage("BotSelect");
    }

    public void moveToGameTypeFromNewGame()
    {
        Brute.SendMessage("Down");
        Pump.SendMessage("Down");
        Luz.SendMessage("Down");
        Gears.SendMessage("Down");
        Sat.SendMessage("Down");
        Beacon1.SendMessage("Down");
        Beacon2.SendMessage("Down");
        Beacon3.SendMessage("Down");
        Beacon4.SendMessage("Down");
        Beacon5.SendMessage("Down");
        StartButton.SendMessage("newButtonsDown");
        NewGame.SendMessage("newButtons");
        Continue.SendMessage("newButtons");
        NewGameCancel.SendMessage("BackDown");
        NewGameReady.SendMessage("ReadyStop");
        Canvas.SendMessage("SelectGameType");
        BotSelect.SendMessage("Stop");
        BotSelectP1.SendMessage("Stop2");
        BotSelectP2.SendMessage("Stop2");
        BotSelectP3.SendMessage("Stop2");
        BotSelectP4.SendMessage("Stop2");
        BotSelectP5.SendMessage("Stop2");
    }
}
