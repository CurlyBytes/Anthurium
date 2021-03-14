using Anthurium.API.Dtos;
using Anthurium.API.Repositories;
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
    [ODataRoutePrefix("deliveryreceipt")]
    [Route("api/deliveryreceipt")]
    [ApiController]
    [Authorize]
    public class DeliveryReceiptController : ODataController
    {
        private readonly ISqlServerDeliveryReceiptRepository _repository;
        private readonly IMapper _mapper;

        public DeliveryReceiptController(ISqlServerDeliveryReceiptRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        [EnableQuery(PageSize = 50)]
        [HttpGet]
        [ODataRoute]
        public ActionResult<IEnumerable<DeliveryReceiptReadDto>> GetAllCommands()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var commandItems = _repository.GetDeliveryReceipt();
            if (commandItems?.Any() == false)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<IEnumerable<DeliveryReceiptReadDto>>(commandItems));
        }

        [HttpGet("{id}", Name = "DeliveryReceiptById")]
        [EnableQuery]
        [ODataRoute("({id})")]
        public ActionResult<DeliveryReceiptReadDto> DeliveryReceiptById([FromODataUri] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var commandItem = _repository.DeliveryReceiptById(id);
            if (commandItem == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<DeliveryReceiptReadDto>(commandItem));
        }




        [HttpPost]
        [ODataRoute]
        public ActionResult<DeliveryReceiptReadDto> CreateCommand([FromBody] DeliveryReceiptCreateDto commandCreate)
        {
            DeliveryReceipt commandItem = _mapper.Map<DeliveryReceipt>(commandCreate);

            _repository.NewDeliveryReceipt(commandItem);
            _repository.SaveChanges();

            DeliveryReceiptReadDto DeliveryReceiptReadDto = _mapper.Map<DeliveryReceiptReadDto>(commandItem);

            return CreatedAtRoute(nameof(DeliveryReceiptById), new { Id = DeliveryReceiptReadDto.DeliveryReceiptId }, DeliveryReceiptReadDto);
        }

        [HttpPut("{id}")]
        [ODataRoute("({id})")]
        public ActionResult UpdateDeliveryReceipt([FromODataUri] int id, [FromBody] DeliveryReceiptUpdateDto DeliveryReceiptUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var commandItem = _repository.DeliveryReceiptById(id);
            if (commandItem == null)
            {
                return NotFound();
            }

            _mapper.Map(DeliveryReceiptUpdateDto, commandItem);
            _repository.UpdateDeliveryReceipt(commandItem);
            _repository.SaveChanges();
            return NoContent();
        }


        [ODataRoute("({id})")]
        [HttpPatch("{id}")]
        public ActionResult PartialUpdate([FromODataUri] int id, Delta<DeliveryReceiptUpdateDto> patchDocument)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var commandItem = _repository.DeliveryReceiptById(id);
            if (commandItem == null)
            {
                return NotFound();
            }

            DeliveryReceiptUpdateDto commandToPatch = _mapper.Map<DeliveryReceiptUpdateDto>(commandItem);
            patchDocument.Patch(commandToPatch);

            if (!TryValidateModel(commandToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(commandToPatch, commandItem);
            _repository.UpdateDeliveryReceipt(commandItem);
            _repository.SaveChanges();

            return NoContent();
        }




        [HttpDelete("{id}")]
        [ODataRoute("({id})")]
        public ActionResult RemoveDeliveryReceipt([FromODataUri] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var commandItem = _repository.DeliveryReceiptById(id);
            if (commandItem == null)
            {
                return NotFound();
            }
            _repository.RemoveDeliveryReceipt(commandItem);
            _repository.SaveChanges();

            return NoContent();
        }


    }
}
