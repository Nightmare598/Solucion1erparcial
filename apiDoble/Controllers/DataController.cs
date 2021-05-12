using apiDoble.Models;
using Azure.Messaging.ServiceBus;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiDoble.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        public async Task<bool> EnviarAsync([FromBody] Data data)
        {
            string connectionStringPar = "Endpoint=sb://queueparcial1.servicebus.windows.net/;SharedAccessKeyName=Enviar;SharedAccessKey=Lu2hys8Sj1awfdrq6SlZyIIfY21G08X2tklh2nrtYeY=;EntityPath=qpar";
            string queueNamePar = "qpar";
            string connectionStringImpar = "Endpoint=sb://queueparcial1.servicebus.windows.net/;SharedAccessKeyName=Enviar;SharedAccessKey=oXHize8Mqg5A2ZV8NwOo1N+FO8ulRH6n4zKAzRm6ZsE=;EntityPath=qimpar";
            string queueNameImpar = "qimpar";
            string mensaje = JsonConvert.SerializeObject(data);

            //JsonSerializer json = new JsonSerializer(); Instalamos un nugget Newton
            if (data.Random % 2 == 0)
                await using (ServiceBusClient client = new ServiceBusClient(connectionStringPar))
                {

                    // create a sender for the queue 
                    ServiceBusSender sender = client.CreateSender(queueNamePar);

                    // create a message that we can send
                    ServiceBusMessage message = new ServiceBusMessage(mensaje);

                    // send the message
                    await sender.SendMessageAsync(message);
                    Console.WriteLine($"Sent a single message to the queue: {queueNamePar}");

                }
            else
                await using (ServiceBusClient client = new ServiceBusClient(connectionStringImpar))
                {

                    // create a sender for the queue 
                    ServiceBusSender sender = client.CreateSender(queueNameImpar);

                    // create a message that we can send
                    ServiceBusMessage message = new ServiceBusMessage(mensaje);

                    // send the message
                    await sender.SendMessageAsync(message);
                    Console.WriteLine($"Sent a single message to the queue: {queueNameImpar}");

                }

            return true;

        }

    }
}
