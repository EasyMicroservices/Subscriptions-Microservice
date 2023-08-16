using EasyMicroservices.Cores.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMicroservices.SubscriptionsMicroservice.Contracts.Common
{
    public class SubscriptionParameterValueContract : IUniqueIdentitySchema, ISoftDeleteSchema, IDateTimeSchema
    {
        public string Value { get; set; }

        public long SubscriptionParameterId { get; set; }

        public DateTime CreationDateTime { get; set; }
        public DateTime? ModificationDateTime { get; set; }
        public DateTime? DeletedDateTime { get; set; }
        public string UniqueIdentity { get; set; }
        public bool IsDeleted { get; set; }
    }
}
