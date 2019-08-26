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
            return Task.FromResult(new PingResponse
            {
                Response = "Pong",
                Timestamp = Timestamp.FromDateTime(DateTime.Now)
            });
        }
    }
}