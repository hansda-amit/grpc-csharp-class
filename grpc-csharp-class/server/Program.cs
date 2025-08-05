// See https://aka.ms/new-console-template for more information
using Grpc.Core;
const int Port = 50051;

Server server = null;
try
{
	server = new Server
	{
		Ports = { new ServerPort("localhost", Port, ServerCredentials.Insecure) }
	};

	server.Start();
	Console.WriteLine($"Server listening on port {Port}");
	Console.ReadKey();
}
catch (IOException e)
{
    Console.WriteLine("The server failed to start.{0}", e.Message);
	throw;
}
finally
{
    if (server is not null)
    {
		await server.ShutdownAsync();
    }
}