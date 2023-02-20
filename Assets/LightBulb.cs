using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightBulb : MonoBehaviour
{
    public Slider slider;
    public GameObject Light;
    public Light myLight;
    public float maxChargeTime = 10f;
    public float chargeTime;
    public bool isBeingCarried;
    public Vector3 liftPos;
    public GameObject Brute;
    // Start is called before the first frame update
    void Start()
    {
        myLight = Light.GetComponent<Light>();
        Brute = GameObject.Find("Brute");
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = chargeTime;
        chargeTime -= Time.deltaTime;
        if(slider.value <= 0)
        {
            myLight.intensity = 0;
        }
        else if(slider.value > 0)
        {
            myLight.intensity = 12f;
        }
    }

    public void HealBattery()
    {
        chargeTime = maxChargeTime;
    }

    public void toggleIsBeingCarried()
    {
        if(!isBeingCarried)
        {
            
            GetComponent<Rigidbody>().useGravity = false;
            isBeingCarried = !isBeingCarried; 
            transform.position = Brute.transform.TransformPoint(liftPos);
            gameObject.AddComponent<FixedJoint>();
            gameObject.GetComponent<FixedJoint>().connectedBody=Brute.GetComponent<Rigidbody>();
            
        }
        else if(isBeingCarried)
        {
                isBeingCarried = !isBeingCarried; 
                Destroy(gameObject.GetComponent<FixedJoint>());
                GetComponent<Rigidbody>().useGravity = true;  
        }
    }
}
