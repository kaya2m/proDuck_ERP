using proDuck.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Domain.Entities.Machine
{
    [Table("machines")]
    public class TBL_Machine : BaseEntity
    {
        public string MachineName { get; set; }
        public string OperationType { get; set; }
        public string Description { get; set; }
        public int ColorCount { get; set; }
        public int DailyCapacity { get; set; }
        public decimal DailyCapacityKg { get; set; }
        public decimal DailyCapacityLt { get; set; }
        public decimal AverageWorkingSpeed { get; set; }
        public int EmployeeCount { get; set; }
    }
}
