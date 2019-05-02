using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    class Publisher
    {
        //defining the event handler delegate with EventArg as argument
        public delegate void EventHandler(EventArgs args);

        public event EventHandler EventTicked;
        public void FireEvent()
        {
            EventTicked?.Invoke(new EventArgs());
        }
    }
    class Subscriber1
    {
        public Subscriber1(Publisher publisher)
        {
            //subsribed to the event
            publisher.EventTicked += Publisher_EventTicked;
        }
        //defining event handler delegate that will be called when the event will be fired
        private void Publisher_EventTicked(EventArgs args)
        {
            Console.WriteLine($"{this.GetType().Name} Recieved event from publisher");
        }
    }
    class Subscriber2
    {
        public Subscriber2(Publisher publisher)
        {
            publisher.EventTicked += Publisher_EventTicked;
        }

        private void Publisher_EventTicked(EventArgs args)
        {
            Console.WriteLine($"{this.GetType().Name} Recieved event from publisher");
        }
    }
}
