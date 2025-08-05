using Grpc.Core;
using Calculate;

namespace server;

public class CalculateServiceImpl : CalculateService.CalculateServiceBase
{
    public override Task<AddResponse> Add(AddRequest request, ServerCallContext context)
    {
        return Task.FromResult(new AddResponse
        {
            Total = request.FirstNumber + request.SecondNumber
        });
    }
}

