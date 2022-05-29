using Grpc.Net.Client;
using GrpcGreeterModels;

var channel = GrpcChannel.ForAddress("https://localhost:5050");
var client = new Greeter.GreeterClient(channel);

do
{
    Console.Write("Write something? ");
    string name = Console.ReadLine()!;

    var response = await client.SayHelloAsync(new() { Name = name });

    Console.WriteLine(response.Message);
} while (true);