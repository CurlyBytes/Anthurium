using Anthurium.API.Dtos;
using Anthurium.API.Repositories;
using Anthurium.Shared.Models;
using AutoMapper;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Anthurium.API.Controllers
{
    [ODataRoutePrefix("warehouse")]
    [Route("api/warehouse")]
    [ApiController]
    [Authorize]

    public class WarehouseController : ODataController
    {
        private readonly ISqlServerWarehouseRepository _repository;
        private readonly IMapper _mapper;

        public WarehouseController(ISqlServerWarehouseRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        [EnableQuery(PageSize = 50)]
        [HttpGet]
        [ODataRoute]
        public ActionResult<IEnumerable<WarehouseReadDto>> GetAllCommands()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var commandItems = _repository.GetWarehouse();
            if (commandItems?.Any() == false)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<IEnumerable<WarehouseReadDto>>(commandItems));
        }

        [HttpGet("{id}", Name = "WarehouseById")]
        [EnableQuery]
        [ODataRoute("({id})")]
        public ActionResult<WarehouseReadDto> WarehouseById([FromODataUri] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var commandItem = _repository.WarehouseById(id);
            if (commandItem == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<WarehouseReadDto>(commandItem));
        }




        [HttpPost]
        [ODataRoute]
        public ActionResult<WarehouseReadDto> CreateCommand([FromBody] WarehouseCreateDto commandCreate)
        {
            Warehouse commandItem = _mapper.Map<Warehouse>(commandCreate);

            _repository.NewWarehouse(commandItem);
            _repository.SaveChanges();

            WarehouseReadDto WarehouseReadDto = _mapper.Map<WarehouseReadDto>(commandItem);

            return CreatedAtRoute(nameof(WarehouseById), new { Id = WarehouseReadDto.WarehouseId }, WarehouseReadDto);
        }

        [HttpPut("{id}")]
        [ODataRoute("({id})")]
        public ActionResult UpdateWarehouse([FromODataUri] int id, [FromBody] WarehouseUpdateDto WarehouseUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var commandItem = _repository.WarehouseById(id);
            if (commandItem == null)
            {
                return NotFound();
            }

            _mapper.Map(WarehouseUpdateDto, commandItem);
            _repository.UpdateWarehouse(commandItem);
            _repository.SaveChanges();
            return NoContent();
        }


        [ODataRoute("({id})")]
        [HttpPatch("{id}")]
        public ActionResult PartialUpdate([FromODataUri] int id, Delta<WarehouseUpdateDto> patchDocument)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var commandItem = _repository.WarehouseById(id);
            if (commandItem == null)
            {
                return NotFound();
            }

            WarehouseUpdateDto commandToPatch = _mapper.Map<WarehouseUpdateDto>(commandItem);
            patchDocument.Patch(commandToPatch);

            if (!TryValidateModel(commandToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(commandToPatch, commandItem);
            _repository.UpdateWarehouse(commandItem);
            _repository.SaveChanges();

            return NoContent();
        }




        [HttpDelete("{id}")]
        [ODataRoute("({id})")]
        public ActionResult RemoveWarehouse([FromODataUri] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var commandItem = _repository.WarehouseById(id);
            if (commandItem == null)
            {
                return NotFound();
            }
            _repository.RemoveWarehouse(commandItem);
            _repository.SaveChanges();

            return NoContent();
        }


    }
}
