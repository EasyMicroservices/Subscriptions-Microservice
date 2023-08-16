using EasyMicroservices.Cores.AspCoreApi;
using EasyMicroservices.Cores.Contracts.Requests;
using EasyMicroservices.Cores.Database.Interfaces;
using EasyMicroservices.ServiceContracts;
using EasyMicroservices.SubscriptionsMicroservice.Contracts.Common;
using EasyMicroservices.SubscriptionsMicroservice.Database.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace EasyMicroservices.SubscriptionsMicroservice.WebApi.Controllers
{
    public class SubscriptionParameterController : SimpleQueryServiceController<SubscriptionParameterEntity, AddSubscriptionParameterRequestContract, UpdateSubscriptionParameterRequestContract, SubscriptionParameterContract, long>
    {
        public IContractLogic<SubscriptionEntity, AddSubscriptionRequestContract, UpdateSubscriptionRequestContract, SubscriptionContract, long> _subscriptionLogic;
        public IContractLogic<SubscriptionUserEntity, AddSubscriptionUserRequestContract, UpdateSubscriptionUserRequestContract, SubscriptionUserContract, long> _subscriptionUserLogic;
        public IContractLogic<SubscriptionParameterValueEntity, AddSubscriptionParameterValueRequestContract, UpdateSubscriptionParameterValueRequestContract, SubscriptionParameterValueContract, long> _subscriptionParameterValueLogic;
        public SubscriptionParameterController(IContractLogic<SubscriptionParameterEntity, AddSubscriptionParameterRequestContract, UpdateSubscriptionParameterRequestContract, SubscriptionParameterContract, long> contractReadable, IContractLogic<SubscriptionEntity, AddSubscriptionRequestContract, UpdateSubscriptionRequestContract, SubscriptionContract, long> subscriptionLogic, IContractLogic<SubscriptionUserEntity, AddSubscriptionUserRequestContract, UpdateSubscriptionUserRequestContract, SubscriptionUserContract, long> subscriptionUserLogic, IContractLogic<SubscriptionParameterValueEntity, AddSubscriptionParameterValueRequestContract, UpdateSubscriptionParameterValueRequestContract, SubscriptionParameterValueContract, long> subscriptionParameterValueLogic) : base(contractReadable)
        {
            _subscriptionLogic = subscriptionLogic; 
            _subscriptionUserLogic = subscriptionUserLogic; 
            _subscriptionParameterValueLogic = subscriptionParameterValueLogic;
        }

        public override async Task<MessageContract<long>> Add(AddSubscriptionParameterRequestContract request, CancellationToken cancellationToken = default)
        {
            var sub = await _subscriptionLogic.GetById(new Cores.Contracts.Requests.GetIdRequestContract<long>
            {
                Id = request.SubscriptionId ?? 0
            });

            var subUser = await _subscriptionUserLogic.GetById(new Cores.Contracts.Requests.GetIdRequestContract<long>
            {
                Id = request.SubscriptionUserId ?? 0
            });

            if (sub || subUser)
            {
                request.SubscriptionId = sub ? sub.Result.Id : null;
                request.SubscriptionUserId = subUser ? subUser.Result.Id : null;
                return await base.Add(request, cancellationToken);
            }

            return (FailedReasonType.NotFound, "The SubscriptionId or SubscriptionUserId cannot be found.");
        }

        public override async Task<MessageContract<SubscriptionParameterContract>> Update(UpdateSubscriptionParameterRequestContract request, CancellationToken cancellationToken = default)
        {
            var subParameter = await base.GetById(new Cores.Contracts.Requests.GetIdRequestContract<long>
            {
                Id = request.Id 
            });

            if (subParameter)
            {
                var sub = await _subscriptionLogic.GetById(new Cores.Contracts.Requests.GetIdRequestContract<long>
                {
                    Id = request.SubscriptionId ?? 0
                }, cancellationToken: cancellationToken);

                var subUser = await _subscriptionUserLogic.GetById(new Cores.Contracts.Requests.GetIdRequestContract<long>
                {
                    Id = request.SubscriptionUserId ?? 0
                });

                if (sub || subUser)
                    return await base.Update(new UpdateSubscriptionParameterRequestContract
                    {
                        Id = request.Id,
                        Name = request.Name ?? subParameter.Result.Name,
                        SubscriptionId = sub ? sub.Result.Id : subParameter.Result.SubscriptionId,
                        SubscriptionUserId = subUser ? subUser.Result.Id : subParameter.Result.SubscriptionUserId,
                        UniqueIdentity = subParameter.Result.UniqueIdentity
                    }, cancellationToken);
            }

            return subParameter.Result;
        }

        [HttpGet]
        public async Task<MessageContract<List<SubscriptionParameterValueContract>>> GetValuesById([FromQuery] GetIdRequestContract<long> request, CancellationToken cancellationToken = default)
        {
            var parameter = await base.GetById(request, cancellationToken);

            if (parameter)
            {
                var allValues = await _subscriptionParameterValueLogic.GetAll();

                var values = allValues.Result.Where(o => o.SubscriptionParameterId == parameter.Result.Id);

                return values.ToList();
            }

            return parameter.ToContract<List<SubscriptionParameterValueContract>>();
        }


        //public override async Task<MessageContract<SubscriptionParameterContract>> GetById(GetIdRequestContract<long> request, CancellationToken cancellationToken = default)
        //{
        //    var parameter = await base.GetById(request, cancellationToken);

        //    if(parameter)
        //    {
        //        var allValues = await _subscriptionParameterValueLogic.GetAll();

        //        var values = allValues.Result.Where(o => o.SubscriptionParameterId == parameter.Result.Id);

        //        parameter.Result.Values = values.ToList();

        //        return parameter;
        //    }

        //    return parameter;
        //}


        //public override async Task<MessageContract<SubscriptionParameterContract>> GetByUniqueIdentity(GetUniqueIdentityRequestContract request, CancellationToken cancellationToken = default)
        //{
        //    var parameter = await base.GetByUniqueIdentity(request, cancellationToken);

        //    if(parameter)
        //    {
        //        var allValues = await _subscriptionParameterValueLogic.GetAll();

        //        var values = allValues.Result.Where(o => o.SubscriptionParameterId == parameter.Result.Id);

        //        parameter.Result.Values = values.ToList();

        //        return parameter;
        //    }

        //    return parameter;
        //}

        //public override async Task<MessageContract<List<SubscriptionParameterContract>>> GetAll(CancellationToken cancellationToken = default)
        //{
        //    var parameters = await base.GetAll(cancellationToken);

        //    if(parameters)
        //    {
        //        var allValues = await _subscriptionParameterValueLogic.GetAll();

        //        var parameterWithValues = parameters.Result.Select(o => new SubscriptionParameterContract
        //        {
        //            Id = o.Id,
        //            Name = o.Name,
        //            Values = allValues.Result.Where(x => x.SubscriptionParameterId == o.Id).ToList(),
        //            CreationDateTime = o.CreationDateTime,
        //            DeletedDateTime = o.DeletedDateTime,
        //            ModificationDateTime = o.ModificationDateTime,
        //            IsDeleted = o.IsDeleted,
        //            SubscriptionId = o.SubscriptionId,
        //            SubscriptionUserId = o.SubscriptionUserId,
        //            UniqueIdentity = o.UniqueIdentity
        //        });

        //        return parameterWithValues.ToList();
        //    }

        //    return parameters;
        //}

        //public override async Task<MessageContract<List<SubscriptionParameterContract>>> GetAllByUniqueIdentity(GetUniqueIdentityRequestContract request, CancellationToken cancellationToken = default)
        //{
        //    var parameters = await base.GetAllByUniqueIdentity(request, cancellationToken);

        //    if(parameters)
        //    {
        //        var allValues = await _subscriptionParameterValueLogic.GetAll();

        //        var parameterWithValues = parameters.Result.Select(o => new SubscriptionParameterContract
        //        {
        //            Id = o.Id,
        //            Name = o.Name,
        //            Values = allValues.Result.Where(x => x.SubscriptionParameterId == o.Id).ToList(),
        //            CreationDateTime = o.CreationDateTime,
        //            DeletedDateTime = o.DeletedDateTime,
        //            ModificationDateTime = o.ModificationDateTime,
        //            IsDeleted = o.IsDeleted,
        //            SubscriptionId = o.SubscriptionId,
        //            SubscriptionUserId = o.SubscriptionUserId,
        //            UniqueIdentity = o.UniqueIdentity
        //        });

        //        return parameterWithValues.ToList();
        //    }

        //    return parameters;
        //}

        ////public override async Task<MessageContract<List<SubscriptionParameterContract>>> GetAll(CancellationToken cancellationToken = default)
        ////{
        ////    var parameters = await base.GetAll(cancellationToken);
        ////    if (parameters)
        ////        return parameters.Result.Select(o => o.)

        ////}

    }
}
