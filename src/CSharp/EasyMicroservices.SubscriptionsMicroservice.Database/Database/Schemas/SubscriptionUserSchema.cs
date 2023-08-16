using EasyMicroservices.Cores.Interfaces;
using System;

namespace EasyMicroservices.SubscriptionsMicroservice.Database.Schemas
{
    public class SubscriptionUserSchema : IUniqueIdentitySchema, IDateTimeSchema, ISoftDeleteSchema
    {
        public DateTime? StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }

        public string UniqueIdentity { get; set; }
        public DateTime CreationDateTime { get; set; }
        public DateTime? ModificationDateTime { get; set; }
        public DateTime? DeletedDateTime { get; set; }
        public bool IsDeleted { get; set; }
    }
}