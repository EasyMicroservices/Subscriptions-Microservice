using EasyMicroservices.Cores.AspCoreApi;
using EasyMicroservices.Cores.Contracts.Requests;
using EasyMicroservices.Cores.Database.Interfaces;
using EasyMicroservices.ServiceContracts;
using EasyMicroservices.SubscriptionsMicroservice.Contracts.Common;
using EasyMicroservices.SubscriptionsMicroservice.Database.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EasyMicroservices.SubscriptionsMicroservice.WebApi.Controllers
{
    public class SubscriptionController : SimpleQueryServiceController<SubscriptionEntity, AddSubscriptionRequestContract, UpdateSubscriptionRequestContract, SubscriptionContract, long>
    {
        public IContractLogic<SubscriptionParameterEntity, AddSubscriptionParameterRequestContract, UpdateSubscriptionParameterRequestContract, SubscriptionParameterContract, long> _subscriptionParameterLogic;

        public SubscriptionController(IContractLogic<SubscriptionEntity, AddSubscriptionRequestContract, UpdateSubscriptionRequestContract, SubscriptionContract, long> contractReadable, IContractLogic<SubscriptionParameterEntity, AddSubscriptionParameterRequestContract, UpdateSubscriptionParameterRequestContract, SubscriptionParameterContract, long> subscriptionParameterLogic) : base(contractReadable)
        {
            _subscriptionParameterLogic = subscriptionParameterLogic;
        }


        [HttpGet]
        public async Task<MessageContract<List<SubscriptionParameterContract>>> GetParametersById([FromQuery] GetIdRequestContract<long> request, CancellationToken cancellationToken = default)
        {
            var sub = await base.GetById(request, cancellationToken);

            if (sub)
            {
                var allValues = await _subscriptionParameterLogic.GetAll();

                var values = allValues.Result.Where(o => o.SubscriptionId == sub.Result.Id);

                return values.ToList();
            }

            return sub.ToContract<List<SubscriptionParameterContract>>();
        }

    }
}
