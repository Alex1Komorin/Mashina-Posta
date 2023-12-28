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
        // Создаем объект UdpClient для прослушивания указанного порта
        UdpClient udpServer = new UdpClient(8888);

        // Бесконечный цикл для прослушивания подключений
        while (work)
        {
            //Console.WriteLine("Ожидание данных...");

            // Получаем данные от клиента и информацию об удаленном хосте
            IPEndPoint remoteIp = null;
            byte[] data = udpServer.Receive(ref remoteIp);

            //Console.WriteLine("Получено данные от клиента {0}:", remoteIp.ToString());
            string receivedData = Encoding.ASCII.GetString(data);

            // Отправляем ответ клиенту
            /*string responseData = "Сервер получил данные: " + receivedData;*/
            //string responseData = changeNumbers.GetComand(receivedData);
            //byte[] responseBytes = Encoding.ASCII.GetBytes(responseData);
            //udpServer.Send(responseBytes, responseBytes.Length, remoteIp);
        }
    }
}
