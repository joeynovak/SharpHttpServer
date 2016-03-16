using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace Qoollo.SharpHttpServer.DemoConsoleApp
{
    public class Server : Qoollo.Net.Http.HttpServer
    {
        public Server(int port)
            :base(port)
        {
            Get["/"] = _ => "Hello world!";

            Get["/api/v1/users"] = GetUsers;

            ServeStatic(new DirectoryInfo("html"), "static");
        }

        private string GetUsers(HttpListenerRequest arg)
        {
            return JsonConvert.SerializeObject(new[]
            {
                new { Id = 1, Username = "peter" },
                new { Id = 1, Username = "jack" },
                new { Id = 1, Username = "john" },
            });
        }
    }
}
