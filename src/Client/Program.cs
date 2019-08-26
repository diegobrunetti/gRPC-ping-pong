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
                var mensagem = string.Empty;

                do
                {
                    Console.Write("Nova mensagem (Digite 0 encerrar): ");
                    var response = client.Ping(new PingRequest{ Message = $"{ mensagem = Console.ReadLine() }" });
                    ImprimeResponse(response);
                } while(mensagem != "0");

                channel.ShutdownAsync().Wait();
                Console.WriteLine("\nPressione qualquer tecla para encerrar...");
                Console.ReadKey();
            }
            catch(Exception e)
            {
                Console.WriteLine($"Exception: {e.StackTrace}");
            }
        }

        private static void ImprimeResponse(PingResponse reply)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write($"{reply.Timestamp.ToDateTime().ToString()} Server:");
            Console.ResetColor();
            
            Console.WriteLine($" {reply.Response}\n");
        }
    }
}
