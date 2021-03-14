using Anthurium.API.Dtos;
using Anthurium.API.Repositories.SqlServer;
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
    [ODataRoutePrefix("deliveryreceiptdetails")]
    [Route("api/deliveryreceiptdetails")]
    [ApiController]
    [Authorize]
    public class DeliveryReceiptDetailsController : ODataController
    {
        private readonly ISqlServerDeliveryReceiptDetailsRepository _repository;
        private readonly IMapper _mapper;

        public DeliveryReceiptDetailsController(ISqlServerDeliveryReceiptDetailsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        [EnableQuery(PageSize = 50)]
        [HttpGet]
        [ODataRoute]
        public ActionResult<IEnumerable<DeliveryReceiptDetailsReadDto>> GetAllCommands()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var commandDeliveryReceiptDetailss = _repository.GetDeliveryReceiptDetails();
            if (commandDeliveryReceiptDetailss?.Any() == false)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<IEnumerable<DeliveryReceiptDetailsReadDto>>(commandDeliveryReceiptDetailss));
        }

        [HttpGet("{id}", Name = "DeliveryReceiptDetailsById")]
        [EnableQuery]
        [ODataRoute("({id})")]
        public ActionResult<DeliveryReceiptDetailsReadDto> DeliveryReceiptDetailsById([FromODataUri] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var commandDeliveryReceiptDetails = _repository.DeliveryReceiptDetailsById(id);
            if (commandDeliveryReceiptDetails == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<DeliveryReceiptDetailsReadDto>(commandDeliveryReceiptDetails));
        }




        [HttpPost]
        [ODataRoute]
        public ActionResult<DeliveryReceiptDetailsReadDto> CreateCommand([FromBody] DeliveryReceiptDetailsCreateDto commandCreate)
        {
            DeliveryReceiptDetails commandDeliveryReceiptDetails = _mapper.Map<DeliveryReceiptDetails>(commandCreate);

            _repository.NewDeliveryReceiptDetails(commandDeliveryReceiptDetails);
            _repository.SaveChanges();

            DeliveryReceiptDetailsReadDto DeliveryReceiptDetailsReadDto = _mapper.Map<DeliveryReceiptDetailsReadDto>(commandDeliveryReceiptDetails);

            return CreatedAtRoute(nameof(DeliveryReceiptDetailsById), new { Id = DeliveryReceiptDetailsReadDto.DeliveryReceiptDetailsId }, DeliveryReceiptDetailsReadDto);
        }

        [HttpPut("{id}")]
        [ODataRoute("({id})")]
        public ActionResult UpdateDeliveryReceiptDetails([FromODataUri] int id, [FromBody] DeliveryReceiptDetailsUpdateDto DeliveryReceiptDetailsUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var commandDeliveryReceiptDetails = _repository.DeliveryReceiptDetailsById(id);
            if (commandDeliveryReceiptDetails == null)
            {
                return NotFound();
            }

            _mapper.Map(DeliveryReceiptDetailsUpdateDto, commandDeliveryReceiptDetails);
            _repository.UpdateDeliveryReceiptDetails(commandDeliveryReceiptDetails);
            _repository.SaveChanges();
            return NoContent();
        }


        [ODataRoute("({id})")]
        [HttpPatch("{id}")]
        public ActionResult PartialUpdate([FromODataUri] int id, Delta<DeliveryReceiptDetailsUpdateDto> patchDocument)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var commandDeliveryReceiptDetails = _repository.DeliveryReceiptDetailsById(id);
            if (commandDeliveryReceiptDetails == null)
            {
                return NotFound();
            }

            DeliveryReceiptDetailsUpdateDto commandToPatch = _mapper.Map<DeliveryReceiptDetailsUpdateDto>(commandDeliveryReceiptDetails);
            patchDocument.Patch(commandToPatch);

            if (!TryValidateModel(commandToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(commandToPatch, commandDeliveryReceiptDetails);
            _repository.UpdateDeliveryReceiptDetails(commandDeliveryReceiptDetails);
            _repository.SaveChanges();

            return NoContent();
        }




        [HttpDelete("{id}")]
        [ODataRoute("({id})")]
        public ActionResult RemoveDeliveryReceiptDetails([FromODataUri] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var commandDeliveryReceiptDetails = _repository.DeliveryReceiptDetailsById(id);
            if (commandDeliveryReceiptDetails == null)
            {
                return NotFound();
            }
            _repository.RemoveDeliveryReceiptDetails(commandDeliveryReceiptDetails);
            _repository.SaveChanges();

            return NoContent();
        }


    }
}
