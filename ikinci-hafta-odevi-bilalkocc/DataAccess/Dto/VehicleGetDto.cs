using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Dto
{
    public class VehicleGetDto
    {
        public long Id { get; set; }
        public string VehicleName { get; set; }
        public string VehiclePlate { get; set; }
    }
}
