﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Dto
{
    public class ContainerCreateDto
    {
        [MaxLength(50),MinLength(2)]
        public string ContainerName { get; set; }
        [Range(-90, 90)]
        public decimal Latitude { get; set; }
        [Range(-180, 180)]
        public decimal Longitude { get; set; }
        [Range(1, long.MaxValue)]
        public long VehicleId { get; set; }
    }
}
