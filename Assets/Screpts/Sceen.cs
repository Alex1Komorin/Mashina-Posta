using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Sceen : MonoBehaviour
{
    Arduino arduino;
    GameObject messageBox;


    private void Start()
    {
        messageBox = GameObject.FindGameObjectWithTag("messageBox");
        CloseMessagBoxError();
    }

    /// <summary>
    /// ��������� ����� ������� ������������ ������� � �������� ���������
    /// </summary>
    /// <param name="sceneid">����� �����</param>
    public void LoadScene(int sceneid)
    { 
        // ���� ����� �� ��������� ������� ��� � ����� ��������
        if (sceneid == 4 || sceneid== 1)
        { 
            arduino = gameObject.AddComponent<Arduino>();

            string checkConnect = arduino.TryConnect();
            if (checkConnect != null)
            {
                if (checkConnect == "!" || checkConnect == "!!")
                {
                    OpenMessageBoxError("1) ���������� ������ � �������, ����� ���� ���������� ������ ��������� � ��������� I\r\n2) ������������ � Wi-Fi ����� PostM (���� ������ �� ������, ���������� � ����������� �����)");
                    //changeNumbers.buttonRetry.GetComponent<Button>().enabled = true;
                }
                else
                    SceneManager.LoadScene(sceneid);
            }
        }
        else
            SceneManager.LoadScene(sceneid);
        // ����� ��������� ����� �����
    }


    /// <summary>
    /// �������� Message Box'�
    /// </summary>
    /// <param name="s"></param>
    public void OpenMessageBoxError(string s)
    {
        if (messageBox != null)
        {
            messageBox = GameObject.FindGameObjectWithTag("messageBox");
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
    }


    /// <summary>
    /// �������� Message Box'�
    /// </summary>
    public void CloseMessagBoxError()
    {
        if (messageBox != null)
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
    }
}
