using EasyMicroservices.Cores.Interfaces;
using EasyMicroservices.SubscriptionMicroservice.Database.Schemas;
using EasyMicroservices.SubscriptionsMicroservice.Database.Schemas;
using System.Collections;
using System.Collections.Generic;

namespace EasyMicroservices.SubscriptionsMicroservice.Database.Entities
{
    public class SubscriptionParameterEntity : SubscriptionParameterSchema, IIdSchema<long>
    {
        public long Id { get; set; }

        public long? SubscriptionId { get; set; }
        public SubscriptionEntity Subscriptions { get; set; }

        public long? SubscriptionUserId { get; set; }
        public SubscriptionUserEntity SubscriptionUsers { get; set; }

        public ICollection<SubscriptionParameterValueEntity> Values { get; set; }

    }
}