using EasyMicroservices.Cores.AspCoreApi;
using EasyMicroservices.Cores.Contracts.Requests;
using EasyMicroservices.Cores.Database.Interfaces;
using EasyMicroservices.ServiceContracts;
using EasyMicroservices.SubscriptionsMicroservice.Contracts.Common;
using EasyMicroservices.SubscriptionsMicroservice.Database.Entities;

namespace EasyMicroservices.SubscriptionsMicroservice.WebApi.Controllers
{
    public class SubscriptionParameterValue : SimpleQueryServiceController<SubscriptionParameterValueEntity, AddSubscriptionParameterValueRequestContract, UpdateSubscriptionParameterValueRequestContract, SubscriptionParameterValueContract, long>
    {
        public IContractLogic<SubscriptionParameterEntity, AddSubscriptionParameterRequestContract, UpdateSubscriptionParameterRequestContract, SubscriptionParameterContract, long> _subscriptionParameterLogic;
        public SubscriptionParameterValue(IContractLogic<SubscriptionParameterValueEntity, AddSubscriptionParameterValueRequestContract, UpdateSubscriptionParameterValueRequestContract, SubscriptionParameterValueContract, long> contractReadable, IContractLogic<SubscriptionParameterEntity, AddSubscriptionParameterRequestContract, UpdateSubscriptionParameterRequestContract, SubscriptionParameterContract, long> subscriptionParameter) : base(contractReadable)
        {
            _subscriptionParameterLogic = subscriptionParameter;           
        }

        public override async Task<MessageContract<long>> Add(AddSubscriptionParameterValueRequestContract request, CancellationToken cancellationToken = default)
        {
            var req = new GetIdRequestContract<long>
            {
                Id = request.SubscriptionParameterId
            };
            var subParameter = await _subscriptionParameterLogic.GetById(req);

            if (subParameter)
                return await base.Add(request, cancellationToken);

            return (FailedReasonType.NotFound, "SubParameter not found.");
        }


        public override async Task<MessageContract<SubscriptionParameterValueContract>> Update(UpdateSubscriptionParameterValueRequestContract request, CancellationToken cancellationToken = default)
        {
            var subParameterValue = await base.GetById(new Cores.Contracts.Requests.GetIdRequestContract<long>
            {
                Id = request.Id
            });

            if (!subParameterValue)
                return subParameterValue.Result;

            var subParameter = await _subscriptionParameterLogic.GetById(new Cores.Contracts.Requests.GetIdRequestContract<long> { Id = request.SubscriptionParameterId });

            return await base.Update(new UpdateSubscriptionParameterValueRequestContract
            {
                Id = request.Id,
                SubscriptionParameterId = subParameter ? subParameter.Result.Id : subParameterValue.Result.SubscriptionParameterId,
                UniqueIdentity = subParameterValue.Result.UniqueIdentity,
                Value = request.Value ?? subParameterValue.Result.Value,
            }, cancellationToken);
        }


    }
}
