using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Reactor
{
    public class Reactor
    {
        private readonly List<Action<Event>> eventHandlers = new List<Action<Event>>();

        public void RegisterHandler(Action<Event> handler)
        {
            eventHandlers.Add(handler);
        }

        public async Task HandleEvent(Event e)
        {
            foreach (var handler in eventHandlers)
            {
                await Task.Run(() => handler(e));
            }
        }
    }
}
