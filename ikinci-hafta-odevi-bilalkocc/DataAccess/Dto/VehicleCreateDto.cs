using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Dto
{
    public class VehicleCreateDto
    {
        [MaxLength(50), MinLength(2)]
        public string VehicleName { get; set; }
        [MaxLength(50), MinLength(2)]
        public string VehiclePlate { get; set; }
    }
}
