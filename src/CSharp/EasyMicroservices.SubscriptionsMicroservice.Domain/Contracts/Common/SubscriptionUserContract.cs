using EasyMicroservices.Cores.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMicroservices.SubscriptionsMicroservice.Contracts.Common
{
    public class SubscriptionUserContract : IUniqueIdentitySchema, ISoftDeleteSchema, IDateTimeSchema
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
        public bool IsEnabled { get; set; }

        public DateTime CreationDateTime { get; set; }
        public DateTime? ModificationDateTime { get; set; }
        public DateTime? DeletedDateTime { get; set; }
        public string UniqueIdentity { get; set; }
        public bool IsDeleted { get; set; }
    }
}
