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
    static string serverIP = "192.168.0.109"; // Замените на IP адрес вашего сервера
    static int serverPort = 8888; // Замените на порт вашего сервера
    ChangeNumbers changeNumbers;

    public static string answerArduino = "";

    static string answer = "";


    void Start()
    {
    }


    public string UdpClient(string txt)
    {
        changeNumbers = new ChangeNumbers();

        // Создание UDP клиента
        using (UdpClient client = new UdpClient())
        {
            // Подключение к серверу
            IPAddress serverAddress = IPAddress.Parse(serverIP);
            IPEndPoint serverEndPoint = new IPEndPoint(serverAddress, serverPort);

            // Ввод сообщения
            string message = txt;
            
            // Преобразование сообщения в байтовый массив для отправки
            byte[] data = Encoding.ASCII.GetBytes(message);

            try
            {
                string ret = TryConnect();

                if (ret == "!")
                {
                    return "!!";
                }
                
                // Отправка сообщения на сервер
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

                // Преобразование полученного ответа в строку
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
        // Создание UDP клиента
        using (UdpClient client = new UdpClient())
        {
            // Подключение к серверу
            IPAddress serverAddress = IPAddress.Parse(serverIP);
            IPEndPoint serverEndPoint = new IPEndPoint(serverAddress, serverPort);

            // Преобразование сообщения в байтовый массив для отправки
            byte[] data = Encoding.ASCII.GetBytes("C");

            try
            {
                IPEndPoint remoteEndPoint;
               
                // Отправка сообщения на сервер
                client.Send(data, data.Length, serverEndPoint);

                // Получение ответа от сервера
                remoteEndPoint = new IPEndPoint(IPAddress.Any, 0);
                
                client.Client.ReceiveTimeout = 3000;


                byte[] receivedData = client.Receive(ref remoteEndPoint);

                if (receivedData == null)
                {
                    return "!";
                }



                // Преобразование полученного ответа в строку
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
