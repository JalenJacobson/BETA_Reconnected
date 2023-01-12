using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCircleManager : MonoBehaviour
{
    public GameObject playerCircle1;
    public GameObject playerCircle2;
    public GameObject playerCircle3;
    public GameObject playerCircle4;

    public List<GameObject> playerCircles;
    public GameObject[] playersRaw;
    public List<GameObject> players;

    public void Awake()
    {
        addPlayerCircles();
        playersRaw = GameObject.FindGameObjectsWithTag("PlayerController");
        foreach (GameObject player in playersRaw)
        {
            players.Add(player);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addPlayerCircles()
    {
        playerCircles.Add(playerCircle4);
        playerCircles.Add(playerCircle3);
        playerCircles.Add(playerCircle2);
        playerCircles.Add(playerCircle1);
    }
}
