using AutoMapper;
using DataAccess.DataModels;
using DataAccess.Dto;
using DataAccess.UoW;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ikinci_hafta_odevi_bilalkocc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public VehicleController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var allVehicles = await unitOfWork.Vehicles.GetAll();
            if (allVehicles is null)
                return NoContent();
            var result = mapper.Map<IEnumerable<Vehicle>, List<VehicleGetDto>>(allVehicles);
            return Ok(result);
        }


        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] long id)
        {
            Vehicle vehicle = await unitOfWork.Vehicles.GetByExp(x => x.Id == id);
            if (vehicle is null)
                return BadRequest();
            return Ok(vehicle);
        }

        [HttpPost]
        public IActionResult Add([FromBody] VehicleCreateDto newVehicle)
        {
            var vehicle = mapper.Map<VehicleCreateDto, Vehicle>(newVehicle);
            unitOfWork.Vehicles.Add(vehicle);
            unitOfWork.Complete();

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] VehicleUpdateDto vehicle)
        {
            Vehicle temp = await unitOfWork.Vehicles.GetByExp(x => x.Id == vehicle.Id);
            mapper.Map(vehicle, temp);
            unitOfWork.Vehicles.Update(temp);
            unitOfWork.Complete();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] long id)
        {
            var deleted = await unitOfWork.Vehicles.GetByExp(x => x.Id == id);
            if (deleted is null)
                return BadRequest();
            unitOfWork.Containers.DeleteContainerWithVehicleId(id);
            unitOfWork.Vehicles.Delete(deleted);
            unitOfWork.Complete();
            return Ok();
        }

        [HttpGet]
        [Route("Containers")]//id'si verilen vehicle'ın baglantılı oldugu tüm containerları listeleme
        public async Task<IActionResult> GetContainersOfVehicle([FromQuery] long id)
        {
            var allContainers = await unitOfWork.Containers.GetAll();
            var temp = allContainers.Where(x => x.VehicleId == id);
            var result = mapper.Map<IEnumerable<Container>, List<ContainerWithOutVehicleData>>(temp);
            return Ok(result);
        }



    }
}
