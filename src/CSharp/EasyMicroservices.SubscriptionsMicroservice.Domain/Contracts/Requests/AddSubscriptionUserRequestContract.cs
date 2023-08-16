using EasyMicroservices.Cores.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMicroservices.SubscriptionsMicroservice.Contracts.Common
{ 
    public class AddSubscriptionUserRequestContract : IUniqueIdentitySchema
    {
        public string UniqueIdentity { get; set; }
        public long SubscriptionId { get; set; }

        public DateTime? StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
    }
}
