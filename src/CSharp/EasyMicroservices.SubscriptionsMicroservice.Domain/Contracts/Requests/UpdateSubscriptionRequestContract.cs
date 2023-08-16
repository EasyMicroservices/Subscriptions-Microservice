using EasyMicroservices.Cores.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMicroservices.SubscriptionsMicroservice.Contracts.Common
{
    public class UpdateSubscriptionRequestContract : AddSubscriptionRequestContract
    {
        public long Id { get; set; }
    }
}
