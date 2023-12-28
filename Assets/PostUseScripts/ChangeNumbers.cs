using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ChangeNumbers : MonoBehaviour
{
    private GameObject messageBox;
    private GameObject messageBoxSucc;
    public GameObject buttonRetry;
    GameObject objOfPanels;
    private List<GameObject> listOfPanels;

    string postCommand;
    string numbsStr;
    bool stop;

    List<int> indxOfStr;


    //\\\\\\\\\\\\\\\ARDUINO\\\\\\\

    Arduino arduino;

    public string answerArduino;
    public string getArduino;
    public static string comandForArduino = "";


    public Dictionary<int, string> commands;

    void Start()
    {
        stop = false;
        //buttonRetry = new GameObject();
        //buttonRetry = GameObject.FindGameObjectWithTag("retry");

        arduino = gameObject.AddComponent<Arduino>();

        commands = new Dictionary<int, string>()
        {
            [0] = "%",
            [1] = ">",
            [2] = "<",
            [3] = "1",
            [4] = "0",
            [5] = "?",
            [6] = "."
        };

        postCommand = "P ";
        numbsStr = "&";
        indxOfStr = new List<int>();
        objOfPanels = GameObject.FindGameObjectWithTag("panels");

        answerArduino = "";
        getArduino = "";
        //buttonRetry.GetComponent<Button>().enabled = false;
        messageBox = new GameObject();
        messageBox = GameObject.FindGameObjectWithTag("messageBox");
        messageBoxSucc = new GameObject();
        messageBoxSucc = GameObject.FindGameObjectWithTag("messageBoxS");
        CloseMessagBoxError();
        CloseMessagBoxSucc();

        listOfPanels = new List<GameObject>();

        ChangeNumOfDropdown();
    }

    ///////////////==������� ��� ���. ������===\\\

    void Update()
    {
    }


    private void ChangeNumOfDropdown()
    {
        GameObject objOfPanels = GameObject.FindGameObjectWithTag("panels");
        int num = 0;
        foreach (Text panels in objOfPanels.GetComponentsInChildren<Text>())
        {
            Text txt = panels.GetComponent<Text>();
            if (txt.tag == "numTextInPanel")
                txt.text = $"{++num}";
        }
    }

    /// <summary>
    /// ������ �������� � � ����������
    /// </summary>
    public void GoingOfPanel()
    {
        postCommand = "P ";
        numbsStr = "&";
        listOfPanels.Clear();
        for (int i = 0; i < objOfPanels.transform.childCount; i++)
            listOfPanels.Add(objOfPanels.transform.GetChild(i).gameObject);
        indxOfStr.Clear();
        for (int i = 0; i < listOfPanels.Count(); i++)
        {
            int valueDrop = listOfPanels[i].transform.GetChild(0).gameObject.GetComponent<Dropdown>().value;
            GameObject inFldText1 = listOfPanels[i].transform.GetChild(1).gameObject;
            string inFldStr1 = inFldText1.GetComponentInChildren<Text>().text;

            GameObject inFldText2 = listOfPanels[i].transform.GetChild(2).gameObject;
            string inFldStr2 = inFldText2.GetComponentInChildren<Text>().text;
            postCommand += commands[valueDrop] + ";";
            if (valueDrop == 0)
                numbsStr += "-1";
            else
            {
                if (valueDrop != 6)
                {
                    int numInpt;
                    if (inFldStr1 == "")
                        numInpt = i + 2;
                    else
                        numInpt = int.Parse(inFldStr1);
                    numbsStr += "" + (numInpt - 1);
                    if (valueDrop == 5)
                    {
                        if (inFldStr1 == "" || inFldStr2 == "")
                        {
                            OpenMessageBoxError("��� �������� \"����\" ������ ��������� ����� ������ ���� ���� �������!");
                            //buttonRetry.GetComponent<Button>().enabled = false;
                            stop = true;
                            break;
                        }
                        int numInpt2 = int.Parse(inFldStr2);
                        numbsStr += "/" + (numInpt2 - 1);
                    }
                }
                else
                    numbsStr += "-2";
            }
            numbsStr += ";";
        }
        if (!stop)
        {
            if (postCommand[postCommand.Length - 1].ToString() == ";")
                postCommand = postCommand.Substring(0, postCommand.Length - 1);

            if (numbsStr[numbsStr.Length - 1].ToString() == ";")
                numbsStr = numbsStr.Substring(0, numbsStr.Length - 1);

            string strFoArd = postCommand + numbsStr;
            string txt = arduino.UdpClient(strFoArd);

            if (txt == "#P")
            {
                OpenMessageBoxSucc("���������� ��������� ��������!����� ���������, ������ �� ���������� ������.");
            }
            else if(txt == "!A")
            {
                OpenMessageBoxError("������ ������ ����������� ���������!");
            }
            else
            {
                OpenMessageBoxError("������� �������� � �����������!");
                //buttonRetry.GetComponent<Button>().enabled = true;
            }
        }
        stop = false;
    }

    public void RetryConnect()
    {
        try
        {
            string checkConnect = arduino.TryConnect();
            if (checkConnect != null)
            {
                if (checkConnect == "!")
                {
                    OpenMessageBoxError($"�������� ��� �����������. ���������� ��� ���...");
                    //buttonRetry.GetComponent<Button>().enabled = false;
                }
                else if (checkConnect == "!!")
                {
                    OpenMessageBoxError("������ �����������!");
                }
                else
                    OpenMessageBoxSucc("������� � ����������� �� ����������!");
            }
        }
        catch (Exception e) { OpenMessageBoxError(e.Message.ToString()); }
    }
    // //////////////////////////////////////////////////////////////////////////////////////

    /// <summary>
    /// �������� Message Box'�
    /// </summary>
    /// <param name="s"></param>
    public void OpenMessageBoxError(string s)
    {
        GameObject messagebox = messageBox.transform.GetChild(0).gameObject;
        Image[] images = messagebox.GetComponentsInChildren<Image>();
        foreach (Image image in images)
            image.enabled = true;
        Text[] texts = messagebox.GetComponentsInChildren<Text>();
        messagebox.transform.GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text = s;

        foreach (Text text in texts)
            text.enabled = true;
        messagebox.GetComponentInChildren<Button>().enabled = true;
        messageBox.GetComponent<Image>().enabled = true;
    }


    /// <summary>
    /// �������� Message Box'�
    /// </summary>
    public void CloseMessagBoxError()
    {
        GameObject messagebox = messageBox.transform.GetChild(0).gameObject;
        Image[] images = messagebox.GetComponentsInChildren<Image>();
        foreach (Image image in images)
            image.enabled = false;
        Text[] texts = messagebox.GetComponentsInChildren<Text>();
        foreach (Text text in texts)
            text.enabled = false;
        messagebox.GetComponentInChildren<Button>().enabled = false;
        messageBox.GetComponent<Image>().enabled = false;

    }

    /// <summary>
    /// �������� Message BoxSuccess'�
    /// </summary>
    /// <param name="s"></param>
    public void OpenMessageBoxSucc(string s)
    {
        GameObject messageboxSucc = messageBoxSucc.transform.GetChild(0).gameObject;
        Image[] images = messageboxSucc.GetComponentsInChildren<Image>();
        foreach (Image image in images)
            image.enabled = true;
        Text[] texts = messageboxSucc.GetComponentsInChildren<Text>();
        foreach (Text text in texts)
            text.enabled = true;
        messageboxSucc.GetComponentInChildren<Button>().enabled = true;
        messageboxSucc.transform.GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text = s;
        messageBoxSucc.GetComponent<Image>().enabled = true;
    }


    /// <summary>
    /// �������� Message BoxSuccess'�
    /// </summary>
    public void CloseMessagBoxSucc()
    {
        GameObject messageboxSucc = messageBoxSucc.transform.GetChild(0).gameObject;
        Image[] images = messageboxSucc.GetComponentsInChildren<Image>();
        foreach (Image image in images)
            image.enabled = false;
        Text[] texts = messageboxSucc.GetComponentsInChildren<Text>();
        foreach (Text text in texts)
            text.enabled = false;
        messageboxSucc.GetComponentInChildren<Button>().enabled = false;
        messageBoxSucc.GetComponent<Image>().enabled = false;

    }
}
