using System;

namespace SharpHttpServerTests
{
    public class ControllerAttribute : Attribute
    {
        public string ControllerRoute { get; set; }

        public ControllerAttribute()
        {
            
        }
    }
}