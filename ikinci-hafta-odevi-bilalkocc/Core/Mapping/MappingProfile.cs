using AutoMapper;
using DataAccess.DataModels;
using DataAccess.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Container, ContainerWithOutVehicleData>();
            CreateMap<ContainerCreateDto, Container>();
            CreateMap<ContainerUpdateDto, Container>();
            CreateMap<Vehicle, VehicleGetDto>();
            CreateMap<VehicleUpdateDto, Vehicle>();
            CreateMap<VehicleCreateDto, Vehicle>();
        }
    }
}
