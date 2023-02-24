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
    public bool dead = false;

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
        if(slider.value <= 5)
        {
            StartCoroutine(FlickerOff());
        }
        
    }
    

    public void restoreHealth()
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

    IEnumerator FlickerOff()
    {
        if(!dead)
        {
            yield return new WaitForSeconds(.3f);
            myLight.intensity = 12;
            yield return new WaitForSeconds(.3f);
            myLight.intensity = 0;
            yield return new WaitForSeconds(.3f);
            myLight.intensity = 10;
            yield return new WaitForSeconds(.3f);
            myLight.intensity = 0;
            yield return new WaitForSeconds(.3f);
            myLight.intensity = 6;
            yield return new WaitForSeconds(.3f);
            myLight.intensity = 0;
            yield return new WaitForSeconds(.3f);
            myLight.intensity = 4;
            yield return new WaitForSeconds(.3f);
            myLight.intensity = 0;
            dead = true;
        }

        
    }
    IEnumerator FlickerOn()
    {
        yield return new WaitForSeconds(.3f);
        myLight.intensity = 3;
        yield return new WaitForSeconds(.3f);
        myLight.intensity = 1;
        yield return new WaitForSeconds(.3f);
        myLight.intensity = 8;
        yield return new WaitForSeconds(.3f);
        myLight.intensity = 1;
        yield return new WaitForSeconds(.3f);
        myLight.intensity = 10;
        yield return new WaitForSeconds(.3f);
        myLight.intensity = 2;
        yield return new WaitForSeconds(.3f);
        myLight.intensity = 12;
        
    }

    public void HealBattery()
    {
        dead = false;
        StartCoroutine(FlickerOn());
    }
}
