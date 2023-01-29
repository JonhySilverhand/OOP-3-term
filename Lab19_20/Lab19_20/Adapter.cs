using System;
using System.Collections.Generic;
using System.Text;

namespace Lab19_20
{
    public class Adapter : ICreateSub
    {
        SubscriptionOffline suboff { get; set; }
        public Adapter(SubscriptionOffline subscriptionOffline)
        {
            suboff = subscriptionOffline;
        }
        public void CreateSubOnline()
        {
            suboff.CreateSubOffline();
        }
    }
}
