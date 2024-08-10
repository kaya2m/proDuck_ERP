using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Domain.Entities.Common
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Status { get; set; }
        public string UserCreated { get; set; }
        virtual public DateTime UpdatedDate { get; set; }
        virtual public string UpdatedUser { get; set; }
    }
}
