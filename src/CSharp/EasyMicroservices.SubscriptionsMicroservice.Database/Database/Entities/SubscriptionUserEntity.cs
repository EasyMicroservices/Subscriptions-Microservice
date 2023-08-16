using EasyMicroservices.SubscriptionMicroservice.Database.Schemas;
using EasyMicroservices.Cores.Database.Interfaces;
using EasyMicroservices.Cores.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyMicroservices.SubscriptionsMicroservice.Database.Schemas;

namespace EasyMicroservices.SubscriptionsMicroservice.Database.Entities
{
    public class SubscriptionUserEntity : SubscriptionUserSchema, IIdSchema<long>
    {
        public long Id { get; set; }

        public long SubscriptionId { get; set; }
        public SubscriptionEntity Subscriptions { get; set; }

        public ICollection<SubscriptionParameterEntity> Parameters { get; set; }
        public ICollection<SubscriptionParameterEntity> SubscriptionParameters { get; set; }
    }
}
