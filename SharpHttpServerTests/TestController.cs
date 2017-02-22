using System.Net;
using Qoollo.Net.Http;
using Qoollo.Net.Http.Attributes;

namespace SharpHttpServerTests
{
    [Controller]
    public class TestController
    {
        [Route]
        public void Ping()
        {
            
        }

        [Route]
        public void PingWithRequest(HttpListenerRequest request)
        {
            
        }

        [Route]
        public string PingWithStringResponse(HttpListenerRequest request)
        {
            return "ping";
        }

        [Route(HttpMethod = HttpMethod.Post)]
        public string PostPingWithStringResponse(HttpListenerRequest request)
        {
            return "ping";
        }


        [Route]
        public FlexResponse PingWithFlexibleResponse(HttpListenerRequest request)
        {            
            return new FlexResponse(){ Data = new byte[] {0x41, 0x42, 0x43, 0x44}};
        }
    }
}