using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bucles : MonoBehaviour
{
    public string[] names;
    public int i = 1;
    public int value = 9;
    void Start()
    {
       /* for (int i = 0; i < names.Length; i++)
        {
            Debug.Log(names[i]);
        }
       */

        while (i <= 10)
        {
            Debug.Log($"{value} x {i} = {value * i}");
            i++;
        }
    }


   
}
