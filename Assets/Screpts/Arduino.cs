using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.CodeDom.Compiler;
using UnityEditor;
using System.Threading.Tasks;
using System;
using Unity.VisualScripting;

public class Arduino : MonoBehaviour
{
    static string serverIP = "192.168.0.109"; // �������� �� IP ����� ������ �������
    static int serverPort = 8888; // �������� �� ���� ������ �������
    ChangeNumbers changeNumbers;

    public static string answerArduino = "";

    static string answer = "";


    void Start()
    {
    }


    public string UdpClient(string txt)
    {
        changeNumbers = new ChangeNumbers();

        // �������� UDP �������
        using (UdpClient client = new UdpClient())
        {
            // ����������� � �������
            IPAddress serverAddress = IPAddress.Parse(serverIP);
            IPEndPoint serverEndPoint = new IPEndPoint(serverAddress, serverPort);

            // ���� ���������
            string message = txt;
            
            // �������������� ��������� � �������� ������ ��� ��������
            byte[] data = Encoding.ASCII.GetBytes(message);

            try
            {
                string ret = TryConnect();

                if (ret == "!")
                {
                    return "!!";
                }
                
                // �������� ��������� �� ������
                client.Send(data, data.Length, serverEndPoint);


                if(txt.Substring(0,1) == "J")
                    client.Client.ReceiveTimeout = 16000;
                else
                    client.Client.ReceiveTimeout = 3000;


                IPEndPoint remoteEndPoint = remoteEndPoint = new IPEndPoint(IPAddress.Any, 0);
                byte[] receivedData = client.Receive(ref remoteEndPoint);

                if (receivedData == null)
                {
                    return "!";
                }

                // �������������� ����������� ������ � ������
                answerArduino = Encoding.ASCII.GetString(receivedData);
            }
            catch (SocketException ex)
            {
                return "!";
                //changeNumbers.OpenMessageBoxError("|network|" + ex.Message.ToString());
            }
        }
        return answerArduino;
    }


    public string TryConnect()
    {
        // �������� UDP �������
        using (UdpClient client = new UdpClient())
        {
            // ����������� � �������
            IPAddress serverAddress = IPAddress.Parse(serverIP);
            IPEndPoint serverEndPoint = new IPEndPoint(serverAddress, serverPort);

            // �������������� ��������� � �������� ������ ��� ��������
            byte[] data = Encoding.ASCII.GetBytes("C");

            try
            {
                IPEndPoint remoteEndPoint;
               
                // �������� ��������� �� ������
                client.Send(data, data.Length, serverEndPoint);

                // ��������� ������ �� �������
                remoteEndPoint = new IPEndPoint(IPAddress.Any, 0);
                
                client.Client.ReceiveTimeout = 3000;


                byte[] receivedData = client.Receive(ref remoteEndPoint);

                if (receivedData == null)
                {
                    return "!";
                }



                // �������������� ����������� ������ � ������
                answer = Encoding.ASCII.GetString(receivedData);
            }
            catch(SocketException ex)
            {
                return "!";
                //changeNumbers.OpenMessageBoxError("|network|" + ex.Message.ToString());
            }
        }
        return answer;
    }
}
