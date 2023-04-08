using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BruteConnection_KillButton : MonoBehaviour
{
    public GameObject Boss;
    public BossActivate Boss_Script;

    // Start is called before the first frame update
    void Start()
    {
        Boss_Script = Boss.GetComponent<BossActivate>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Activate()
    {
        Boss_Script.takeDamage(25f);
    }
}
