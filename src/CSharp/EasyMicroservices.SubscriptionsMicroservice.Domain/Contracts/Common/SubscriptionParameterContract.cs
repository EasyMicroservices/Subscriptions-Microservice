using EasyMicroservices.Cores.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMicroservices.SubscriptionsMicroservice.Contracts.Common
{
    public class SubscriptionParameterContract : IUniqueIdentitySchema, ISoftDeleteSchema, IDateTimeSchema
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long? SubscriptionId { get; set; }
        public long? SubscriptionUserId { get; set; }

        public DateTime CreationDateTime { get; set; }
        public DateTime? ModificationDateTime { get; set; }
        public DateTime? DeletedDateTime { get; set; }
        public string UniqueIdentity { get; set; }
        public bool IsDeleted { get; set; }
    }
}
