using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuequeHelper.CustomerQueque
{
    public interface IQuequeHelper
    {
        public bool SendMessage(IModel model, int contactID, string consoleMessage, string contactName, string queque);

    }
}
