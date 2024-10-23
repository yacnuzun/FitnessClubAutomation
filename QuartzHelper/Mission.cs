using Quartz;
using QuequeHelper.CustomerQueque;
using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuartzHelper
{
    public class Mission : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            ConnectionFactory factory = new ConnectionFactory() { HostName = CustomerQuequeConstant.Factory };

            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: CustomerQuequeConstant.Queque,
                                         durable: false,
                                         exclusive: false,
                                         autoDelete: false,
                                         arguments: null);

                    var consumer = new EventingBasicConsumer(channel);
                    channel.BasicConsume(queue: CustomerQuequeConstant.Queque,
                                         autoAck: true,
                                         consumer: consumer);
                    consumer.Received += (model, ea) =>
                    {
                        var body = ea.Body.ToArray();
                        var message = Encoding.UTF8.GetString(body);
                        Console.WriteLine("Customer is added for fitness club {0}", message);
                    };

                }
            }
            return Task.CompletedTask;

        }
    }
}
