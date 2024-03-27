using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Reactor
{
    public class Event
    {
        public string Message { get; }

        public Event(string message)
        {
            Message = message;
        }
    }
}
