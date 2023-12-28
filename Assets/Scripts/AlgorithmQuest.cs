using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class AlgorithmQuest : MonoBehaviour
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



    //==================================================================
    private void ChangeNumOfDropdown()
    {
        int num = 0;
        foreach (Text panels in objOfPanels.GetComponentsInChildren<Text>())
        {
            Text txt = panels.GetComponent<Text>();
            if (txt.tag == "numTextInPanel")
                txt.text = $"{++num}";
        }
    }

    public void AddPanel()  // |||||||||||||||||||||||||||||||||||||||||||--\��������/--||||||||||||||||||||||||||||||||||||||||||||||||||||
                            // �������� ������� ���� � �������
                            // Timer
    {
        int indx = objOfPanels.transform.childCount;
        GameObject lastPanel = objOfPanels.transform.GetChild(indx - 1).gameObject;
        GameObject newPanel = Instantiate(lastPanel);
        newPanel.transform.position = new Vector3(lastPanel.transform.position.x, lastPanel.transform.position.y + lastPanel.transform.localScale.y + 10);
        //newPanel.tag = panel.tag;

        ChangeNumOfDropdown();
    }
    private void Update()
    {
    }

    /// <summary>
    /// ������ �������� � �� ��������
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
            else if (txt == "!A")
            {
                OpenMessageBoxError("�������� ��� �����������!");
            }
            else if (txt == "!")
            {
                OpenMessageBoxError("�������� � �����������!");
            }
            else
            {
                OpenMessageBoxError("�������� ��� ����������� ��� ������� �������� � �����������.");
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
                    OpenMessageBoxError($"�������� ��� ����������� ��� ������� �������� � �����������. ���������� ��� ���...");
                    //buttonRetry.GetComponent<Button>().enabled = false;
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
    public void Input()
    {
        backto.SetActive(false);
        b_clue.SetActive(false);
        b_start.SetActive(false);
        b_desc.SetActive(false);
        b_check.SetActive(false);
        scroll.SetActive(false);
        button.SetActive(true);
        background.SetActive(true);
        text.SetActive(true);
        text.GetComponent<Text>().text = "���� ��������...";

        if (arduino.UdpClient(SendMassiv) == "#^")
        {
            CheckingAlgoritm();
        }
        else
        {
            OpenMessageBoxError("�������� ��� ����������� ��� ������� �������� � �����������.");
            Output();
            //buttonRetry.GetComponent<Button>().enabled = true;
        }
        //ReceiveMassiv = "#$ 111111111";
        //CheckMassiv();
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
    }
    public void CheckMassiv()
    {
        string[] massiv = ReceiveMassiv.Split(new char[] { ' ' });
        ReceiveMassiv = massiv[1];
        if (ReceiveMassiv == RightMassiv)
        {
            text.GetComponent<Text>().text = "�����";
        }
        else
        {
            text.GetComponent<Text>().text = "�������";
        }
        button.SetActive(true);
    }
    public void CheckingAlgoritm()
    {
        postCommand = "J ";
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

            if (txt == "#JJ")
            {
                OpenMessageBoxError("��� ���������� ��������� ��������� ������! ������������ � ��� ����� �� ������ ����������.");
                Output();
            }
            else if(txt == "!A")
            {
                OpenMessageBoxError("�������� ��� �����������!");
                Output();
            }
            else if(txt == "!")
            {
                OpenMessageBoxError("������� �������������� ����� ����������!");
                Output();
            }
            else if(txt == "!!")
            {
                OpenMessageBoxError("������ �����������!");
                Output();
            }
            else
            {
                ReceiveMassiv = txt;
                CheckMassiv();
            }
        }
        stop = false;
    }
}

