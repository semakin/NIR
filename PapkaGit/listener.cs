using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Diagnostics;

namespace Listener 
{
	class Program
	{
		private const int port = 1991;

		public static void Main(string[] args)
		{
			var udpClient = new UdpClient(port);
			
			Console.WriteLine("программа запустилась");
			
			IPEndPoint endPoint = null;
			var bytes = udpClient.Receive(ref endPoint);
			
			Console.WriteLine("данные получены");
			
			var parameters = Encoding.ASCII.GetString(bytes);
			Console.WriteLine($"Сконвертировано: {parameters}");

			Process.Start("/bin/bash", $"scrip.sh {parameters}");
			Console.WriteLine("Завершение");
		}
	}
}
