using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Checking : MonoBehaviour
{
    GameObject background;
    GameObject button;
    GameObject text;
    GameObject backto;
    GameObject b_clue;
    GameObject b_start;
    GameObject b_desc;
    GameObject b_check;
    GameObject scroll;
    static string sendMassiv;
    static string receiveMassiv;
    static string rightMassiv;
    public static string SendMassiv
    {
        get { return sendMassiv; }
        set { sendMassiv = value; }
    }
    public static string ReceiveMassiv
    {
        get { return receiveMassiv; }
        set { receiveMassiv = value; }
    }
    public static string RightMassiv
    {
        get { return rightMassiv; }
        set { rightMassiv = value; }
    }

    private void Start()
    {
        background = GameObject.Find("MessageCheck");
        button = GameObject.Find("CheckButton");
        text = GameObject.Find("TextForCheck");
        backto = GameObject.Find("BackTo");
        b_clue = GameObject.Find("ButtonClue");
        b_start = GameObject.Find("ButtonStart");
        b_desc = GameObject.Find("ButtonDesc");
        b_check = GameObject.Find("ButtonCheck");
        scroll = GameObject.Find("Scroll View");
        button.SetActive(false);
        background.SetActive(false);
        text.SetActive(false);
    }
    public void Input()
    {
        backto.SetActive(false);
        b_clue.SetActive(false);
        b_start.SetActive(false);
        b_desc.SetActive(false);
        b_check.SetActive(false);
        scroll.SetActive(false);
        button.SetActive(false);
        background.SetActive(true);
        text.SetActive(true);
        Arduino arduino = new Arduino();
        //arduino.UdpClient(SendMassiv);
        //background.transform.position = new Vector3(0.17f, -0.03f, -3);
        //button.transform.position = new Vector3(2.7f, 1.3f);
        //text.transform.position = new Vector3(-0.5f, -0.15f);

        ReceiveMassiv = "ff 111111111";
        CheckMassiv();
    }
    public void Output()
    {
        backto.SetActive(true);
        b_clue.SetActive(true);
        b_start.SetActive(true);
        b_desc.SetActive(true);
        b_check.SetActive(true);
        scroll.SetActive(true);
        button.SetActive(false);
        background.SetActive(false);
        text.SetActive(false);
        //background.transform.position = new Vector3(-20.01f, -0.03f, -3);
        //button.transform.position = new Vector3(-764, 49);
        //text.transform.position = new Vector3(-864, -11);
    }
    public void CheckMassiv()
    {
        string[] massiv = ReceiveMassiv.Split(new char[] { ' ' });
        ReceiveMassiv = massiv[1];
        if (ReceiveMassiv == RightMassiv)
        {
            text.GetComponent<Text>().text = "Верно";
        }
        else
        {
            text.GetComponent<Text>().text = "Неверно";
        }
        button.SetActive(true);
    }
}
