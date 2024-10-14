using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Domain.Entities.Address
{
    [Table("districts")]
    public class TBL_District
    {
        [Key]
        [Column("district_id")]
        public int DistrictId { get; set; }
        [Column("district_name")]
        public string DistrictName { get; set; }

        [Column("country_id")]
        public int CountryId { get; set; }
        public TBL_Country Country { get; set; }
        [Column("city_id")]
        public int CityId { get; set; }
        public TBL_City City { get; set; }
        public ICollection<TBL_Neighborhood> Neighborhoods { get; set; }
    }
}
