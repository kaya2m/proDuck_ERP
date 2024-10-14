using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Domain.Entities.Address
{
    [Table("cities")]
    public class TBL_City
    {
        [Key]
        [Column("city_id")]
        public int CityId { get; set; }
        [Column("city_name")]
        public string CityName { get; set; }

        public ICollection<TBL_District> Districts { get; set; }
        [Column("country_id")]
        public int CountryId { get; set; }
        public TBL_Country Country { get; set; }
    }
}
