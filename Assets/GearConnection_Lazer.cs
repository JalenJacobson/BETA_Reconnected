using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearConnection_Lazer : MonoBehaviour
{
    public GameObject gizmo;
    public LazerFollow gizmoMove_Script;

    // Start is called before the first frame update
    void Start()
    {
        gizmoMove_Script = gizmo.GetComponent<LazerFollow>();
    }

    public void setGizmoInTriggerCube(GearTriggerCube triggerScript)
    {
      triggerScript.gizmoLazer_Script = gizmoMove_Script;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
