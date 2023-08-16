using EasyMicroservices.SubscriptionMicroservice.Database.Schemas;
using EasyMicroservices.Cores.Database.Interfaces;
using EasyMicroservices.Cores.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMicroservices.SubscriptionsMicroservice.Database.Entities
{
    public class SubscriptionEntity : SubscriptionSchema, IIdSchema<long>
    {
        public long Id { get; set; }

        public ICollection<SubscriptionUserEntity> SubscriptionUsers { get;}
        public ICollection<SubscriptionParameterEntity> SubscriptionParameters { get;}
    }
}
