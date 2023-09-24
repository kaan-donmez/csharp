using System.Text;
using RabbitMQ.Client;
using System.Timers;

var factory = new ConnectionFactory { HostName = "localhost" };
using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();

channel.QueueDeclare(queue: "LoremIpsum",
                     durable: false,
                     exclusive: false,
                     autoDelete: false,
                     arguments: null);

const string message = "Hello World!";
var body = Encoding.UTF8.GetBytes(message);

var periodicTimer = new PeriodicTimer(TimeSpan.FromSeconds(1));
while (await periodicTimer.WaitForNextTickAsync())
{
    channel.BasicPublish(exchange: string.Empty,
                         routingKey: "LoremIpsum",
                         basicProperties: null,
                         body: body);
    Console.WriteLine($"Sent {message}");
}