using System;
using Grpc.Core;
using Server.Services;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Channel channel = new Channel("127.0.0.1:50051", ChannelCredentials.Insecure);

                var client = new PingService.PingServiceClient(channel);

                var reply = client.Ping(new PingRequest{ Message = $"Olá, server! Aqui são {DateTime.Now}" });
                Console.WriteLine($"{reply.Timestamp.ToDateTime().ToString()}: {reply.Response}");
                channel.ShutdownAsync().Wait();
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
            catch(Exception e)
            {
                Console.WriteLine($"Exception: {e.StackTrace}");
            }
        }
    }
}
