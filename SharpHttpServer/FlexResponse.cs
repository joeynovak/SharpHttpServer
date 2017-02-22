namespace Qoollo.Net.Http
{
    public class FlexResponse
    {
        public string ContentType { get; set; } = "text/plain";
        public byte[] Data { get; set; } = new byte[0];
    }
}