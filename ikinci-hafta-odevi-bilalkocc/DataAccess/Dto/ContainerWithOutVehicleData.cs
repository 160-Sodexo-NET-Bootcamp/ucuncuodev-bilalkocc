using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Dto
{
    public class ContainerWithOutVehicleData
    {
        public long Id { get; set; }
        public string ContainerName { get; set; }      
        public decimal Latitude { get; set; }        
        public decimal Longitude { get; set; }
    }
}
