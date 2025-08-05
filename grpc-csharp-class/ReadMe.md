# gRPC C# Sample Project by hansda-amit

This repository demonstrates a gRPC client-server application using C# and .NET 8.0, featuring multiple services for greeting and calculation operations.

## Structure

- `client/` - gRPC client implementation
- `server/` - gRPC server implementation with service implementations
  - `GreetingServiceImpl.cs` - Implementation of the greeting service
  - `CalculateServiceImpl.cs` - Implementation of the calculation service
- `greeting.proto` - Protocol Buffers definition for greeting service
- `calculate.proto` - Protocol Buffers definition for calculation service
- `dummy.proto` - Basic Protocol Buffers definition (unused in current implementation)
- `models/` - Generated code from Protocol Buffers definitions

## Getting Started

### Prerequisites
- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)

### Build

From the root directory:

```powershell
# Build the solution
 dotnet build grpc-csharp-class.sln
```

### Run the Server

```powershell
cd server
dotnet run
```

The server will start listening on `localhost:50051` and display a confirmation message.

### Run the Client

In a new terminal:

```powershell
cd client
dotnet run
```

The client will connect to the server and demonstrate both services:
1. Send a greeting request with "John Doe" and receive a personalized response
2. Send an addition request (11.00 + 12.45) and receive the calculated result

## Notes
- **Ensure** the server is running before starting the client.
- The server runs on `localhost:50051` by default.
- The client demonstrates two services:
  - **GreetingService**: Takes a first and last name, returns a greeting message
  - **CalculateService**: Performs addition of two numbers
- The `models/` directory in both client and server contains code generated from `.proto` files.

## Services

### GreetingService
- **Method**: `Greet`
- **Input**: `GreetingRequest` containing first name and last name
- **Output**: `GreetingResponse` with a personalized greeting message

### CalculateService  
- **Method**: `Add`
- **Input**: `AddRequest` with two numbers to add
- **Output**: `AddResponse` with the sum total

## License
MIT
