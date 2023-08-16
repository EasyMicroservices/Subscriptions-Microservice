using EasyMicroservices.Cores.AspCoreApi;
using EasyMicroservices.Cores.Contracts.Requests;
using EasyMicroservices.Cores.Database.Interfaces;
using EasyMicroservices.ServiceContracts;
using EasyMicroservices.SubscriptionsMicroservice.Contracts.Common;
using EasyMicroservices.SubscriptionsMicroservice.Database.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EasyMicroservices.SubscriptionsMicroservice.WebApi.Controllers
{
    public class SubscriptionUserController : SimpleQueryServiceController<SubscriptionUserEntity, AddSubscriptionUserRequestContract, UpdateSubscriptionUserRequestContract, SubscriptionUserContract, long>
    {
        public IContractLogic<SubscriptionEntity, AddSubscriptionRequestContract, UpdateSubscriptionRequestContract, SubscriptionContract, long> _subscriptionLogic;
        public IContractLogic<SubscriptionParameterEntity, AddSubscriptionParameterRequestContract, UpdateSubscriptionParameterRequestContract, SubscriptionParameterContract, long> _subscriptionParameterLogic;

        public SubscriptionUserController(IContractLogic<SubscriptionUserEntity, AddSubscriptionUserRequestContract, UpdateSubscriptionUserRequestContract, SubscriptionUserContract, long> contractReadable, IContractLogic<SubscriptionEntity, AddSubscriptionRequestContract, UpdateSubscriptionRequestContract, SubscriptionContract, long> subscriptionLogic, IContractLogic<SubscriptionParameterEntity, AddSubscriptionParameterRequestContract, UpdateSubscriptionParameterRequestContract, SubscriptionParameterContract, long> subscriptionParameterLogic) : base(contractReadable)
        {
            _subscriptionLogic = subscriptionLogic;
            _subscriptionParameterLogic = subscriptionParameterLogic;
        }

        public override async Task<MessageContract<long>> Add(AddSubscriptionUserRequestContract request, CancellationToken cancellationToken = default)
        {
            var sub = await _subscriptionLogic.GetById(new Cores.Contracts.Requests.GetIdRequestContract<long>
            {
                Id = request.SubscriptionId
            });

            if(sub) 
                return await base.Add(request, cancellationToken);


            return sub.ToContract<long>();
        }


        public override async Task<MessageContract<SubscriptionUserContract>> Update(UpdateSubscriptionUserRequestContract request, CancellationToken cancellationToken = default)
        {
            var sub = await _subscriptionLogic.GetById(new Cores.Contracts.Requests.GetIdRequestContract<long>
            {
                Id = request.SubscriptionId
            });

            if (sub)
                return await base.Update(request, cancellationToken);


            return sub.ToContract<SubscriptionUserContract>();
        }


        [HttpGet]
        public async Task<MessageContract<List<SubscriptionParameterContract>>> GetParametersById([FromQuery] GetIdRequestContract<long> request, CancellationToken cancellationToken = default)
        {
            var subUser = await base.GetById(request, cancellationToken);

            if (subUser)
            {
                var allValues = await _subscriptionParameterLogic.GetAll();

                var values = allValues.Result.Where(o => o.SubscriptionUserId == subUser.Result.Id);

                return values.ToList();
            }

            return subUser.ToContract<List<SubscriptionParameterContract>>();
        }
    }
}
