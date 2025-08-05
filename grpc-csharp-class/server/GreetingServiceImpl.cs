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
}
