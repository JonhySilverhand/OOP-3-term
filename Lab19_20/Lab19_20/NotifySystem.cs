using System;
using System.Collections.Generic;
using System.Text;

namespace Lab19_20
{
    public abstract class User
    {
        protected Mediator mediator;

        public User(Mediator mediator)
        {
            this.mediator = mediator;
        }

        public virtual void Send(string message)
        {
            mediator.Send(message, this);
        }
        public abstract void Notify(string message);
    }
    public class NotifiedReader : User
    {
        public NotifiedReader(Mediator mediator) : base(mediator)
        { }

        public override void Notify(string message)
        {
            Console.WriteLine("Сообщение читателю: " + message);
        }
    }
}
