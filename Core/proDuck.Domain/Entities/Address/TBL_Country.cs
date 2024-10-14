using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Domain.Entities.Address
{
    [Table("countries")]
    public class TBL_Country
    {
        [Key]
        [Column("country_id")]
        public int CountryId { get; set; }
        [Column("country_code")]
        public string CountryCode { get; set; }
        [Column("country_name")]
        public string CountryName { get; set; }
        [Column("country_dial_code")]
        public string CountryDialCode { get; set; }

        public ICollection<TBL_City> Cities { get; set; }
        public ICollection<TBL_District> Districts { get; set; }
        public ICollection<TBL_Neighborhood> Neighborhoods { get; set; }
    }
}
