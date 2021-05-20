using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static bool[] keys = new bool[4];
    public static int power = 0;

    void Start()
    {
        //Initialize the value of the inventory
        for (int i = 0; i < 4; i++){
            keys[i] = false;
        }   
    }
}
