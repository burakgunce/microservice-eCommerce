﻿using Ecommerce.Order.Application.Features.Mediator.Results.OrderingResults;
using MediatR;

namespace Ecommerce.Order.Application.Features.Mediator.Queries.OrderingQueries
{
    public class GetOrderingByUserIdQuery : IRequest<List<GetOrderingByUserIdQueryResult>>
    {
        public string Id { get; set; }
        public GetOrderingByUserIdQuery(string id)
        {
            Id = id;
        }
    }
}
