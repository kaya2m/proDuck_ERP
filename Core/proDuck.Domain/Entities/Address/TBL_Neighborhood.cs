using proDuck.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Domain.Entities.Address
{
    [Table("neighborhoods")]
    public class TBL_Neighborhood 
    {
        [Key]
        [Column("neighborhood_id")]
        public int NeighborhoodId { get; set; }
        [Column("neighborhood_name")]
        public string NeighborhoodName { get; set; }

        [Column("district_id")]
        public int DistrictId { get; set; }
        public TBL_District District { get; set; }

        [Column("city_id")]
        public int CityId { get; set; }
        public TBL_City City { get; set; }
        [Column("country_id")]
        public int CountryId { get; set; }
        public TBL_Country Country { get; set; }
    }
}
