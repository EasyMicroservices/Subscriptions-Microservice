using EasyMicroservices.Cores.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMicroservices.SubscriptionsMicroservice.Contracts.Common
{ 
    public class AddSubscriptionParameterValueRequestContract : IUniqueIdentitySchema
    {
        public string Value { get; set; }
        public long SubscriptionParameterId { get; set; }
        public string? UniqueIdentity { get; set; }
    }
}
