﻿using EasyMicroservices.Cores.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMicroservices.SubscriptionsMicroservice.Contracts.Common
{ 
    public class AddSubscriptionParameterRequestContract : IUniqueIdentitySchema
    {
        public string Name { get; set; }
        public string UniqueIdentity { get; set; }
        
        public long? SubscriptionId { get; set; }
        public long? SubscriptionUserId { get; set; }

    }
}
