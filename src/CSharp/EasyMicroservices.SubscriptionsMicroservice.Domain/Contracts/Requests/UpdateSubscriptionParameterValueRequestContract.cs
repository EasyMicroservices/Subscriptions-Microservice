using EasyMicroservices.Cores.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMicroservices.SubscriptionsMicroservice.Contracts.Common
{ 
    public class UpdateSubscriptionParameterValueRequestContract : AddSubscriptionParameterValueRequestContract
    {
        public long Id { get; set; }
    }
}
