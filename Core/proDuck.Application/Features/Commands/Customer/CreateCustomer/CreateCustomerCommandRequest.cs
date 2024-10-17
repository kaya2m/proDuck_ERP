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
        //public Guid FinancialTransactionId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string PaymentMethod { get; set; }
        public string CurrencyTypes { get; set; }
        public string CountryCode { get; set; }
        public int CountryId { get; set; }
        public int CityId { get; set; }
        public int DistrictId { get; set; }
        public int NeighborhoodId { get; set; }
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
        public string idNumber { get; set; }
        public string Notes { get; set; }
    }
}
