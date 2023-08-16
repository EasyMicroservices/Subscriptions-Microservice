using EasyMicroservices.Cores.Interfaces;
using EasyMicroservices.SubscriptionsMicroservice.Database.Schemas;
using System.Collections.Generic;

namespace EasyMicroservices.SubscriptionsMicroservice.Database.Entities
{
    public class SubscriptionParameterValueEntity : SubscriptionParameterValueSchema, IIdSchema<long>
    {
        public long Id { get; set; }
        public long? SubscriptionParameterId { get; set; }
        public SubscriptionParameterEntity SubscriptionParameters { get; set; }

        public ICollection<SubscriptionParameterValueEntity> Values { get; set; }

    }
}