using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Qoollo.SharpHttpServer.DemoConsoleApp
{
    public class Server : Qoollo.Net.Http.HttpServer
    {
        public Server(int port)
            :base(port)
        {
            Scheme = "https";       
            Get["/"] = _ => "Hello world!";

            Get["/api/v1/users"] = GetUsers;

            Get["/api/v1/certificate"] = Certificate;

            Get["/other"] = Server.Other;
            ServeStatic(new DirectoryInfo("html"), "static");
        }

        private string GetUsers(HttpListenerRequest arg)
        {
                           
            return JsonConvert.SerializeObject(new[]
            {
                new { Id = 1, Username = "peter" },
                new { Id = 1, Username = "jack" },
                new { Id = 1, Username = "john" }
            });
        }

        private string Certificate(HttpListenerRequest arg)
        {
            X509Certificate2 certificate = arg.GetClientCertificate();
            if (certificate != null)
                return JsonConvert.SerializeObject("Certificate Thumbprint :" + certificate.Thumbprint);
            else
            {
                return JsonConvert.SerializeObject("No Certificate Provided");
            }
        }

        public static string Other(HttpListenerRequest arg)
        {
            return "";
        }
    }
}
