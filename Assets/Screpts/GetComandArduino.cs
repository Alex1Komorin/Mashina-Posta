using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System.Text;

public class GetComandArduino : MonoBehaviour
{
    public ChangeNumbers changeNumbers;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void GetComandFromArduino(bool work = true)
    {
        changeNumbers = new ChangeNumbers();
        // ������� ������ UdpClient ��� ������������� ���������� �����
        UdpClient udpServer = new UdpClient(8888);

        // ����������� ���� ��� ������������� �����������
        while (work)
        {
            //Console.WriteLine("�������� ������...");

            // �������� ������ �� ������� � ���������� �� ��������� �����
            IPEndPoint remoteIp = null;
            byte[] data = udpServer.Receive(ref remoteIp);

            //Console.WriteLine("�������� ������ �� ������� {0}:", remoteIp.ToString());
            string receivedData = Encoding.ASCII.GetString(data);

            // ���������� ����� �������
            /*string responseData = "������ ������� ������: " + receivedData;*/
            //string responseData = changeNumbers.GetComand(receivedData);
            //byte[] responseBytes = Encoding.ASCII.GetBytes(responseData);
            //udpServer.Send(responseBytes, responseBytes.Length, remoteIp);
        }
    }
}
