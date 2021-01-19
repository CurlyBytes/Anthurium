using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Dtos;
using WebApi.Models;
using WebApi.Repositories;

namespace WebApi.Controllers
{
    [Route("api/client")]
    [ApiController]
    public class ClientInformationController : ControllerBase
    {

        private readonly IClientInformation _repository;
        private readonly IMapper _mapper;

        public ClientInformationController(IClientInformation repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ClientInformationReadDto>> GetAllCommands()
        {
            var commandItems = _repository.GetClientInformation();

            return Ok(_mapper.Map<IEnumerable<ClientInformationReadDto>>(commandItems));
        }

        [HttpGet("{id}", Name = "ClientInformationById")]
        public ActionResult<ClientInformationReadDto> ClientInformationById(int id)
        {
            var commandItem = _repository.ClientInformationById(id);
            if (commandItem == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ClientInformationReadDto>(commandItem));
        }

        [HttpPost]
        public ActionResult<ClientInformationReadDto> CreateCommand(ClientInformationCreateDto commandCreate)
        {
            ClientInformation commandItem = _mapper.Map<ClientInformation>(commandCreate);

            _repository.NewClientInformation(commandItem);
            _repository.SaveChanges();

            ClientInformationReadDto ClientInformationReadDto = _mapper.Map<ClientInformationReadDto>(commandItem);

            return CreatedAtRoute(nameof(ClientInformationById), new { Id = ClientInformationReadDto.Id }, ClientInformationReadDto);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateClientInformation(int id, ClientInformationUpdateDto ClientInformationUpdateDto)
        {
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

        [HttpPatch("{id}")]
        public ActionResult PartialUpdate(int id, JsonPatchDocument<ClientInformationUpdateDto> patchDocument)
        {
            var commandItem = _repository.ClientInformationById(id);
            if (commandItem == null)
            {
                return NotFound();
            }

            ClientInformationUpdateDto commandToPatch = _mapper.Map<ClientInformationUpdateDto>(commandItem);

            patchDocument.ApplyTo(commandToPatch, ModelState);
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
        public ActionResult RemoveClientInformation(int id)
        {
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
