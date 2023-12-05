using MediatR;
using RAMO.Core.Entities;
using System.Collections.Generic;

namespace RAMO.Application.Queries
{
    public record GetAllCustomerQuery : IRequest<List<Customer>>
    {

    }

    public class GetCustomerByEmailQuery : IRequest<Customer>
    {
        public string Email { get; private set; }

        public GetCustomerByEmailQuery(string email)
        {
            this.Email = email;
        }

    }

    public class GetCustomerByIdQuery : IRequest<Customer>
    {
        public Int64 Id { get; private set; }

        public GetCustomerByIdQuery(Int64 Id)
        {
            this.Id = Id;
        }

    }
}
