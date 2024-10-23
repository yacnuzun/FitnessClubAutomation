using QuartzHelper;
using QuequeHelper.CustomerQueque;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace AdminConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Hello, Welcome Admin Console!");

            Trigger tetikleyici = new Trigger();

            tetikleyici.ActivedMission();

            Console.ReadKey();
        
        }
    }
}