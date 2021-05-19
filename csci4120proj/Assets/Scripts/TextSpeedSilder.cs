using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
 
public class TextSpeedSlider : MonoBehaviour
{
 
 
 
    public int speed = 7;
    public int cps;
 
    ShowValue value;
 
 
 
    public void Start()
    {
       value.adjustSpeed();
        cps = speed;
    }
 
    // Start is called before the first frame update
 
}