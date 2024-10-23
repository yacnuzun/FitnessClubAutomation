using RabbitMQ.Client;
using System.Text;

namespace QuequeHelper.CustomerQueque
{
    public class QueQueHelper:IQuequeHelper
    {
        public bool SendMessage(IModel model, int contactID, string consoleMessage, string contactName, string queque)
        {

            model.QueueDeclare(queue: queque,
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false);

            string message = consoleMessage;
            var body = Encoding.UTF8.GetBytes(message);

            model.BasicPublish(exchange: "",
                                 routingKey: queque,
                                 body: body);

            return true;

        }
    }
}