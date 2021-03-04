using Anthurium.API.Dtos;
using Anthurium.API.Repositories.SqlServer;
using Anthurium.Shared.Models;
using AutoMapper;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Anthurium.API.Controllers
{
    [ODataRoutePrefix("vendor")]
    [Route("api/vendor")]
    [ApiController]
    public class VendorController : ODataController
    {
        private readonly ISqlServerVendorRepository _repository;
        private readonly IMapper _mapper;

        public VendorController(ISqlServerVendorRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        [EnableQuery(PageSize = 50)]
        [HttpGet]
        [ODataRoute]
        public ActionResult<IEnumerable<VendorReadDto>> GetAllCommands()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var commandItems = _repository.GetVendor();
            if (commandItems?.Any() == false)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<IEnumerable<VendorReadDto>>(commandItems));
        }

        [HttpGet("{id}", Name = "VendorById")]
        [EnableQuery]
        [ODataRoute("({id})")]
        public ActionResult<VendorReadDto> VendorById([FromODataUri] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var commandItem = _repository.VendorById(id);
            if (commandItem == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<VendorReadDto>(commandItem));
        }




        [HttpPost]
        [ODataRoute]
        public ActionResult<VendorReadDto> CreateCommand([FromBody] VendorCreateDto commandCreate)
        {
            Vendor commandItem = _mapper.Map<Vendor>(commandCreate);

            _repository.NewVendor(commandItem);
            _repository.SaveChanges();

            VendorReadDto VendorReadDto = _mapper.Map<VendorReadDto>(commandItem);

            return CreatedAtRoute(nameof(VendorById), new { Id = VendorReadDto.VendorId }, VendorReadDto);
        }

        [HttpPut("{id}")]
        [ODataRoute("({id})")]
        public ActionResult UpdateVendor([FromODataUri] int id, [FromBody] VendorUpdateDto VendorUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var commandItem = _repository.VendorById(id);
            if (commandItem == null)
            {
                return NotFound();
            }

            _mapper.Map(VendorUpdateDto, commandItem);
            _repository.UpdateVendor(commandItem);
            _repository.SaveChanges();
            return NoContent();
        }


        [ODataRoute("({id})")]
        [HttpPatch("{id}")]
        public ActionResult PartialUpdate([FromODataUri] int id, Delta<VendorUpdateDto> patchDocument)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var commandItem = _repository.VendorById(id);
            if (commandItem == null)
            {
                return NotFound();
            }

            VendorUpdateDto commandToPatch = _mapper.Map<VendorUpdateDto>(commandItem);
            patchDocument.Patch(commandToPatch);

            if (!TryValidateModel(commandToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(commandToPatch, commandItem);
            _repository.UpdateVendor(commandItem);
            _repository.SaveChanges();

            return NoContent();
        }




        [HttpDelete("{id}")]
        [ODataRoute("({id})")]
        public ActionResult RemoveVendor([FromODataUri] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var commandItem = _repository.VendorById(id);
            if (commandItem == null)
            {
                return NotFound();
            }
            _repository.RemoveVendor(commandItem);
            _repository.SaveChanges();

            return NoContent();
        }


    }
}
