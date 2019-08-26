using System;
using Grpc.Core;
using Server.Services;

namespace Server
{
    class Program
    {
        const int Porta = 50051;
        public static void Main(string[] args)
        {
            try
            {    
                Grpc.Core.Server server = new Grpc.Core.Server
                {
                    Services = { PingService.BindService(new PingServiceImpl()) },
                    Ports = { new ServerPort("localhost", Porta, ServerCredentials.Insecure) }
                };
                server.Start();
                Console.WriteLine("Server ouvindo na porta " + Porta);
                Console.WriteLine("Pressione qualquer tecla para parar o server...");
                Console.ReadKey();
                server.ShutdownAsync().Wait();
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Erro: {ex}");
            }
        }
    }
}
