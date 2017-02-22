using System;

namespace Qoollo.Net.Http.Attributes
{
    public class RouteAttribute : Attribute
    {
        public HttpMethod HttpMethod { get; set; } = HttpMethod.Get;
        public string Path { get; set; }
    }
}