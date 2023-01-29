using System;
using System.Collections.Generic;
using System.Text;

namespace Lab19_20
{
    public abstract class Mediator
    {
        public abstract void Send(string msg, User user);
    }
    class System : Mediator
    {
        public User Reader { get; set; }
        public override void Send(string msg, User user)
        {
            Reader.Notify(msg);
        }
    }
}
