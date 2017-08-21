using System;
using System.Collections.Generic;

namespace Fiver.Design.Builder
{
    public sealed class Greeting
    {
        private readonly string timeOfDay;
        private readonly string to;
        
        public Greeting(string timeOfDay, string to)
        {
            if (string.IsNullOrEmpty(timeOfDay))
                throw new ArgumentException("Time of Day must be set");

            if (string.IsNullOrEmpty(to))
                throw new ArgumentException("To must be set");

            this.timeOfDay = timeOfDay;
            this.to = to;
        }

        public string Message => $"Good {timeOfDay} {to}";
    }
}