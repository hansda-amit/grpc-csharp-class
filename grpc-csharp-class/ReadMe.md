# gRPC C# Sample Project

This repository demonstrates a simple gRPC client-server application using C# and .NET 8.0.

## Structure

- `client/` - gRPC client implementation
- `server/` - gRPC server implementation
- `dummy.proto` - Protocol Buffers definition file
- `models/` - Generated and shared model files for gRPC

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

### Run the Client

In a new terminal:

```powershell
cd client
 dotnet run
```

## Notes
- **Ensure** the server is running before starting the client.
- The `models/` directory in both client and server contains code generated from `dummy.proto`.

## License
MIT
