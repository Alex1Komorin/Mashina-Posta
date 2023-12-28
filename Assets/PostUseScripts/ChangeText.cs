using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using System;

public class ChangeText : MonoBehaviour
{
    ChangeNumbers numbs;
    void Start()
    {
        numbs = gameObject.AddComponent<ChangeNumbers>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckChangeText(InputField inputFiled)
    {
        string str = inputFiled.text;
        if(str != "")
        {
            if (str.Length > 2 || Int32.Parse(str) > 30 || Int32.Parse(str) < 1)
            {
                inputFiled.text = "";
                numbs.OpenMessageBoxError("Строка может содержать только положительные числа до 30");
            }
        }
    }
}
