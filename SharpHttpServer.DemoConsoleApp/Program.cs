using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Qoollo.SharpHttpServer.DemoConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting HttpServer...");

            var server = new Server(8080);
            server.Run();

            Console.WriteLine("HttpServer started.");
            Console.WriteLine("Listening at {0}", server.BaseUrl);
            Console.WriteLine();
            Console.WriteLine("Press <Enter> to exit");
            Console.ReadLine();

            server.Stop();
        }
    }
}
