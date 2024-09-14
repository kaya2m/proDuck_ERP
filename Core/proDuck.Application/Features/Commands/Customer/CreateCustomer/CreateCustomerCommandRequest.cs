using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Application.Features.Commands.Customer.CreateCustomer
{
    public class CreateCustomerCommandRequest:IRequest<CreateCustomerCommandResponse>
    {
        public Guid FinancialTransactionId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int PaymentMethod { get; set; }
        public string CountryCode { get; set; }
        public Guid CountryId { get; set; }
        public Guid CityId { get; set; }
        public Guid TownId { get; set; }
        public string ContactNumber { get; set; }
        public string ContactNumber2 { get; set; }
        public string Email { get; set; }
        public string Email2 { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string PostCode { get; set; }
        public string CompanyName { get; set; }
        public string TaxNumber { get; set; }
        public string TaxOffice { get; set; }
        public Guid idNumber { get; set; }
        public string Notes { get; set; }
    }
}
