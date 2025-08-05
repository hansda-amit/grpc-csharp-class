using Calculate;
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
    var greetResponse  = await client.GreetAsync(new GreetingRequest
    {
        Greeting = new Greeting
        {
            FirstName = "John",
            LastName = "Doe"
        }
    });
    if(greetResponse is not null)
    {
        Console.WriteLine("Message: {0}", greetResponse.Message);
    }
    var calculateClient = new CalculateService.CalculateServiceClient(channel);
    var addresponse = await calculateClient.AddAsync(new AddRequest
    {
        FirstNumber = 11.00,
        SecondNumber = 12.45
    });
    if(addresponse is not null)
    {
        Console.WriteLine("Total:{0}", addresponse.Total);
    }

    var request = new GreetManyTimesRequest() { Greeting = new Greeting { FirstName = "Amit" , LastName = "Hansda" } };
    var manyTimesResponse = client.GreetManyTimes(request);
    while (await manyTimesResponse.ResponseStream.MoveNext())
    {
        Console.WriteLine(manyTimesResponse.ResponseStream.Current.Message);
        await Task.Delay(150);
    }

    await channel.ShutdownAsync();
});
Console.ReadKey();