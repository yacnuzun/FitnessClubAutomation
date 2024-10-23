using QuequeHelper.CustomerQueque;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using StaticEntity.Implemantations;
using StaticEntity.Interfaces;
using System.Text;

namespace EmployeeConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ICustomerInterface customerProcess = new CustomerImplemantation();
            var factory = new ConnectionFactory() { HostName = CustomerQuequeConstant.Factory };
            IQuequeHelper quequeHelper = new QueQueHelper();
            customerProcess.FirstAddCustomers();
            Console.WriteLine("Hello, Welcome Employee");
        startApplicaiton:
            ConsoleHelper.GetMenu();
            string choise = Console.ReadLine();
            switch(choise)
            {
                case "1":
                    foreach (var item in CustomerImplemantation.list)
                    {
                        Console.WriteLine(item.Name + " " + item.Surname);
                    }
                    while (!CustomerQuequeConstant.ApplicationIsFinish)
                    {
                        goto startApplicaiton;
                    }
                    Console.ReadKey();
                    return ;
                case "2":
                    Console.WriteLine("Enter Name: ");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter SurName: ");
                    string surName = Console.ReadLine();
                    bool response = customerProcess.AddCustomer(name, surName);
                    if (response != true)
                    {
                        Console.WriteLine("Failed for added process.");
                    }
                    else
                    {
                        using (var connection = factory.CreateConnection())
                        {
                            using (var channel = connection.CreateModel())
                            {
                                quequeHelper.SendMessage(
                                        channel,
                                        CustomerQuequeConstant.ContactIDforEmployee,
                                        name + " " + surName,
                                        "employee",
                                        CustomerQuequeConstant.Queque);

                            }
                            Console.WriteLine("Successed for added process.");


                        }
                    }

                    while (!CustomerQuequeConstant.ApplicationIsFinish)
                    {
                        goto startApplicaiton;
                    }

                    Console.ReadKey();

                    return;
                default :
                    Console.WriteLine("Press any button...");
                    CustomerQuequeConstant.ApplicationIsFinish = true;
                    while (!CustomerQuequeConstant.ApplicationIsFinish)
                    {
                        goto startApplicaiton;
                    }
                    Console.ReadKey();
                    return;
            }

            Console.ReadKey();
        }
        public class ConsoleHelper
        {
            public static void GetMenu()
            {
                Console.WriteLine("Choise your process");
                Console.WriteLine("Get Customers  press 1");
                Console.WriteLine("Add Customer press 2");
                Console.WriteLine("Exit press 0");
            }
        }
    }
}