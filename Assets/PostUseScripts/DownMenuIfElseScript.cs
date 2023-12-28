using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class DownMenuIfElseScript : MonoBehaviour
{
    [SerializeField] public Dropdown selectMenu;
    [SerializeField] public InputField inptField1;
    [SerializeField] public InputField inptField2;


    [SerializeField] private Vector3 posInput1Def;
    [SerializeField] private Vector3 sizeInput2Def;

    void Start()
    {
        posInput1Def = inptField1.transform.localPosition;
        sizeInput2Def = inptField2.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        InputMenu();
    }

    void InputMenu()
    {
        if (selectMenu.value == 5)
        {
            inptField1.transform.localPosition = posInput1Def - sizeInput2Def - sizeInput2Def / 100;
            inptField2.transform.localScale = inptField1.transform.localScale;
        }
        else
        {
            inptField1.transform.localPosition = posInput1Def;
            inptField2.transform.localScale = sizeInput2Def;
        }
    }
}
