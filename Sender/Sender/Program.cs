using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sender
{
    class Program
    {
        static void Main(string[] args)
        {
            string ip, ssilka, nameFile;
            int port = 1991;
            Console.Write("Введите ip :");
            ip = Console.ReadLine();
            Console.Write("Введите ссылку на репозиторий :");
            ssilka = Console.ReadLine();
            Console.Write("Введите имя файла :");
            nameFile = Console.ReadLine();
            UdpClient client = new UdpClient(ip, port);
            byte[] data = Encoding.UTF8.GetBytes(ssilka +" "+ nameFile);
            client.Send(data, data.Length);
            client.Close();
            Thread threadReciv = new Thread(new ThreadStart(ReceiveMessage));
            threadReciv.Start();
            Console.ReadKey();
        }
        private static void ReceiveMessage()
        {
            UdpClient receiver = new UdpClient(1992);
            IPEndPoint remoteIp = null;
            byte[] datareciver = receiver.Receive(ref remoteIp);
            string messagereciv = Encoding.Unicode.GetString(datareciver);
            Console.WriteLine(messagereciv);
            receiver.Close();
        }
    }
}
