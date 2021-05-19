using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class ShowValue : MonoBehaviour
{
 
 
    Text percentageText;
    TextSpeedSlider newSpeed;
    public float value;
 
 
    void Start()
    {
        percentageText = GetComponent<Text>();
    }
 
    // Update is called once per frame
    public void textUpdate()
    {
        percentageText.text = Mathf.RoundToInt(value * 10) + "%";
     
    }
 
    public void adjustSpeed()
    {
        newSpeed.speed = (int)value;
    }
 
 
}