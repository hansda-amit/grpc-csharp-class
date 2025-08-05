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

        foreach (var i in Enumerable.Range(1, 10))
        {
            string result = $"hello {request.Greeting.FirstName} {request.Greeting.LastName} {i}";

            await responseStream.WriteAsync(new GreetManyTimesResponse
            {
                Message = result
            });
        }
    }

    public override async Task DecomposeToPrime(DecomposeRequest request, IServerStreamWriter<DecomposeResponse> responseStream, ServerCallContext context)
    {
        Console.WriteLine("the service received decompose request for {0}", request.Number);

        //Decompose the number into its prime factors
        int N = request.Number;
        int k = 2;
        while (N > 1)
        {
            if (N % k == 0)
            {
                await responseStream.WriteAsync(new DecomposeResponse
                {
                    Number = k
                });
                N = N / k;
            }
            else
            {
                k++;
            }
        }
    }

}
