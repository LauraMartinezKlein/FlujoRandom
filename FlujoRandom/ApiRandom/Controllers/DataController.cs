
namespace ApiRandom.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Threading.Tasks;

    using Azure.Messaging.ServiceBus;
    using ApiRandom.Models;
    using Newtonsoft.Json;

    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        [HttpPost]
        public async Task<bool> EnviarAsync([FromBody] Data data)
        {
            string connectionStringPar = "Endpoint=sb://queuerandom.servicebus.windows.net/;SharedAccessKeyName=Enviar;SharedAccessKey=5ok7m1I26BOV8+93Qu+rSkpzWLj49todha5eexJwRhM=;EntityPath=colapar";
            string connectionStringImpar = "Endpoint=sb://queuerandom.servicebus.windows.net/;SharedAccessKeyName=Enviar;SharedAccessKey=LGy6ee5A+IAvinynTFBMHf7ZmbbRN7LzlQJc2bWvx7k=;EntityPath=colaimpar";
            string queueNamePar = "colapar";
            string queueNameImpar = "colaimpar";
            string mensaje = JsonConvert.SerializeObject(data);

            int num = data.RandNum;

            if (num % 2 == 0)
            {
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
                return true;
            }
            else
            {
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
}
