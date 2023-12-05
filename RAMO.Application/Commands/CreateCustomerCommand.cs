using MediatR;
using RAMO.Application.Response;
using System;

namespace RAMO.Application.Commands
{
    public class CreateCustomerCommand : IRequest<CustomerResponse>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public string Address { get; set; }
        public DateTime CreatedDate { get; set; }

        public CreateCustomerCommand()
        {
            this.CreatedDate = DateTime.Now;
        }
    }

    public class EditCustomerCommand : IRequest<CustomerResponse>
    {

        public Int64 Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public string Address { get; set; }
    }

    public class DeleteCustomerCommand : IRequest<String>
    {
        public Int64 Id { get; private set; }

        public DeleteCustomerCommand(Int64 Id)
        {
            this.Id = Id;
        }
    }
}
