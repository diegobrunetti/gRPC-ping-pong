using System;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

namespace Server.Services
{
    public class PingServiceImpl : PingService.PingServiceBase
    {
        public override Task<PingResponse> Ping(PingRequest request, ServerCallContext context)
        {
            Console.WriteLine($"Mensagem recebida: {request.Message}");
            
            return Task.FromResult(new PingResponse
            {
                Response = $"O servidor recebeu a mensagem \"{request.Message}\"",
                Timestamp = DateTime.UtcNow.ToTimestamp()
            });
        }
    }
}