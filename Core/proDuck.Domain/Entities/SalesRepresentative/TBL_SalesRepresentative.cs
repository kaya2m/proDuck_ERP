using proDuck.Domain.Entities.Common;
using proDuck.Domain.Entities.Offer;
using proDuck.Domain.Entities.Order;
using System;
using System.Collections.Generic;

namespace proDuck.Domain.Entities.SalesRepresentative
{
    public class TBL_SalesRepresentative : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Territory { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Nationality { get; set; }
        public string EmployeeCode { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public int TotalSales { get; set; }
        public decimal TotalRevenue { get; set; }
        public decimal TotalCommission { get; set; }
        public int NumberOfClients { get; set; }
        public int MonthlyTarget { get; set; }
        public int QuarterlyTarget { get; set; }
        public int YearlyTarget { get; set; }
        public string Position { get; set; }
        public string Department { get; set; }
        public string Manager { get; set; }
        public string OfficeLocation { get; set; }
        public bool IsActive { get; set; }
        public bool IsAvailableForContact { get; set; }
        public string AvailabilityNotes { get; set; }
        public string LinkedInProfile { get; set; }
        public string TwitterHandle { get; set; }
        public string EmergencyContactName { get; set; }
        public string EmergencyContactPhone { get; set; }

        public virtual ICollection<TBL_Offer> Offers { get; set; }
        public virtual ICollection<TBL_Order> Orders { get; set; }
    }
}
