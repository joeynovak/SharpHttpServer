using Microsoft.VisualStudio.TestTools.UnitTesting;
using Qoollo.Net.Http;

namespace SharpHttpServerTests
{
    [TestClass()]
    public class AutoRouterTests 
    {
        [TestMethod()]
        public void TestAddGetRoutesToServer()
        {
            HttpServer server = new HttpServer(9999);
            TestController controller = new TestController();
            AutoRouter.AddControllerActions(controller, server);

            Assert.IsTrue(server.Get["/Test/PingWithStringResponse"].Method.Name == "PingWithStringResponse");
        }

        [TestMethod()]
        public void TestAddPostRoutesToServer()
        {
            HttpServer server = new HttpServer(9999);
            TestController controller = new TestController();
            AutoRouter.AddControllerActions(controller, server);

            Assert.IsTrue(server.Post["/Test/PostPingWithStringResponse"].Method.Name == "PostPingWithStringResponse");
        }
    }
}