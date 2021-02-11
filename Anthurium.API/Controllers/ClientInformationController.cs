using Anthurium.API.Dtos;
using Anthurium.Shared.Models;
using Anthurium.Web.Repositories;
using AutoMapper;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Anthurium.API.Controllers
{
    [ODataRoutePrefix("clientinformation")]
    [Route("api/clientinformation")]
    [ApiController]
    [Authorize]
    public class ClientInformationController : ODataController, IClientInformationController
    {
        private readonly IClientInformation _repository;
        private readonly IMapper _mapper;

        public ClientInformationController(IClientInformation repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        [EnableQuery(PageSize = 50)]
        [HttpGet]
        [ODataRoute]
        public ActionResult<IEnumerable<ClientInformationReadDto>> GetAllCommands()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var commandItems = _repository.GetClientInformation();

            return Ok(_mapper.Map<IEnumerable<ClientInformationReadDto>>(commandItems));
        }

        [HttpGet("{id}", Name = "ClientInformationById")]
        [EnableQuery]
        [ODataRoute("({id})")]
        public ActionResult<ClientInformationReadDto> ClientInformationById([FromODataUri] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var commandItem = _repository.ClientInformationById(id);
            if (commandItem == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ClientInformationReadDto>(commandItem));
        }


        [HttpGet("{id}/joborders", Name = "JobOrderPerClientId")]
        [EnableQuery]
        [ODataRoute("JobOrders(clientInformationId={clientInformationId},jobOrderClientInformationId={jobOrderClientInformationId})")]
        public ActionResult<IEnumerable<JobOrderReadDto>> JobOrderPerClientId([FromODataUri] int clientInformationId, [FromODataUri] int jobOrderClientInformationId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var commandItem = _repository.JobOrderPerClientId(clientInformationId);
            if (commandItem == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<IEnumerable<JobOrderReadDto>>(commandItem));
        }


        [HttpPost]
        [ODataRoute]
        public ActionResult<ClientInformationReadDto> CreateCommand([FromBody] ClientInformationCreateDto commandCreate)
        {
            ClientInformation commandItem = _mapper.Map<ClientInformation>(commandCreate);

            _repository.NewClientInformation(commandItem);
            _repository.SaveChanges();

            ClientInformationReadDto ClientInformationReadDto = _mapper.Map<ClientInformationReadDto>(commandItem);

            return CreatedAtRoute(nameof(ClientInformationById), new { Id = ClientInformationReadDto.ClientInformationId }, ClientInformationReadDto);
        }

        [HttpPut("{id}")]
        [ODataRoute("({id})")]
        public ActionResult UpdateClientInformation([FromODataUri] int id, [FromBody] ClientInformationUpdateDto ClientInformationUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var commandItem = _repository.ClientInformationById(id);
            if (commandItem == null)
            {
                return NotFound();
            }

            _mapper.Map(ClientInformationUpdateDto, commandItem);
            _repository.UpdateClientInformation(commandItem);
            _repository.SaveChanges();
            return NoContent();
        }


        [ODataRoute("({id})")]
        [HttpPatch("{id}")]
        public ActionResult PartialUpdate([FromODataUri] int id, Delta<ClientInformationUpdateDto> patchDocument)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var commandItem = _repository.ClientInformationById(id);
            if (commandItem == null)
            {
                return NotFound();
            }

            ClientInformationUpdateDto commandToPatch = _mapper.Map<ClientInformationUpdateDto>(commandItem);
            patchDocument.Patch(commandToPatch);
           
            if (!TryValidateModel(commandToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(commandToPatch, commandItem);
            _repository.UpdateClientInformation(commandItem);
            _repository.SaveChanges();

            return NoContent();
        }




        [HttpDelete("{id}")]
        [ODataRoute("({id})")]
        public ActionResult RemoveClientInformation([FromODataUri] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var commandItem = _repository.ClientInformationById(id);
            if (commandItem == null)
            {
                return NotFound();
            }
            _repository.RemoveClientInformation(commandItem);
            _repository.SaveChanges();

            return NoContent();
        }


    }
}
