using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    
    public void setHealth(float health)
    {

        
        slider.value = health;
        print(slider.value);

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
