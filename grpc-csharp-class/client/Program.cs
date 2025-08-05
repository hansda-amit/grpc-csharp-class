using Greet;
using Grpc.Core;
const string Target = "127.0.0.1:50051";

var channel = new Channel(Target, ChannelCredentials.Insecure);
await channel.ConnectAsync().ContinueWith( async task => {
    if(task.Status == TaskStatus.RanToCompletion)
    {
        Console.WriteLine("the client connected succesfully");
    }else if(task.Status == TaskStatus.Faulted)
    {
        Console.WriteLine("the client faulted");
    }
    //var client = new DummyService.DummyServiceClient(channel);
    var client = new GreetingService.GreetingServiceClient(channel);
    var response  = await client.GreetAsync(new GreetingRequest
    {
        Greeting = new Greeting
        {
            FirstName = "John",
            LastName = "Doe"
        }
    });
    if(response is not null)
    {
        Console.WriteLine("Message: {0}", response.Message);
    }
    await channel.ShutdownAsync();
});
Console.ReadKey();