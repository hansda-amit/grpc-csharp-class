using Grpc.Core;
using Greet;
using static Greet.GreetingService;

namespace server;

public class GreetingServiceImpl : GreetingServiceBase
{
    public override async Task<GreetingResponse> Greet(Greet.GreetingRequest request, ServerCallContext context)
    {
        var response = new GreetingResponse
        {
            Message = $"Hello {request.Greeting.FirstName}!"
        };
        return response;
    }


    public override async Task GreetManyTimes(GreetManyTimesRequest request, IServerStreamWriter<GreetManyTimesResponse> responseStream, ServerCallContext context)
    {
        Console.WriteLine("the service received streaming request");
        
        foreach (var i in Enumerable.Range(1,10))
        {
            string result = $"hello {request.Greeting.FirstName} {request.Greeting.LastName} {i}";

            await responseStream.WriteAsync(new GreetManyTimesResponse
            {
                Message = result
            });
        }
    }

}
