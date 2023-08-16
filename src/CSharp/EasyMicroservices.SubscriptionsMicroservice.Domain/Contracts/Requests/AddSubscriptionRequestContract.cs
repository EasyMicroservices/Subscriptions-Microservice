using EasyMicroservices.Cores.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMicroservices.SubscriptionsMicroservice.Contracts.Common
{
    public class AddSubscriptionRequestContract : IUniqueIdentitySchema
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
        public bool IsEnabled { get; set; }
        public string? UniqueIdentity { get; set; }
    }
}
