using Anthurium.API.Dtos;
using Anthurium.Shared.Models;
using Anthurium.Web.Repositories;
using AutoMapper;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Anthurium.API.Controllers
{
    [Route("api/joborder")]
    [ApiController]

    public class JobOrderController : ODataController
    {
        private readonly IJobOrderRepository _repository;
        private readonly IMapper _mapper;

        public JobOrderController(IJobOrderRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<JobOrderReadDto>> GetJobOrders()
        {
            var commandItems = _repository.GetJobOrders();

            return Ok(_mapper.Map<IEnumerable<JobOrderReadDto>>(commandItems));
        }

        [HttpGet("{id}", Name = "JobOrderById")]
        public ActionResult<JobOrderReadDto> JobOrderById(int id)
        {
            var commandItem = _repository.GetJobOrderById(id);
            if (commandItem == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<JobOrderReadDto>(commandItem));
        }

        [HttpPost]
        public ActionResult<JobOrderReadDto> CreateJobOrder(JobOrderCreateDto commandCreate)
        {
            JobOrder commandItem = _mapper.Map<JobOrder>(commandCreate);

            _repository.CreateJobOrder(commandItem);
            _repository.SaveChanges();

            JobOrderReadDto JobOrderReadDto = _mapper.Map<JobOrderReadDto>(commandItem);

            return CreatedAtRoute(nameof(JobOrderById), new { Id = JobOrderReadDto.Id }, JobOrderReadDto);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateJobOrder(int id, JobOrderUpdateDto JobOrderUpdateDto)
        {
            var commandItem = _repository.GetJobOrderById(id);
            if (commandItem == null)
            {
                return NotFound();
            }

            _mapper.Map(JobOrderUpdateDto, commandItem);
            _repository.UpdateCJobOrder(commandItem);
            _repository.SaveChanges();
            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult PartialUpdate(int id, JsonPatchDocument<JobOrderUpdateDto> patchDocument)
        {
            var commandItem = _repository.GetJobOrderById(id);
            if (commandItem == null)
            {
                return NotFound();
            }

            JobOrderUpdateDto commandToPatch = _mapper.Map<JobOrderUpdateDto>(commandItem);

            patchDocument.ApplyTo(commandToPatch, (Microsoft.AspNetCore.JsonPatch.Adapters.IObjectAdapter)ModelState);
            if (!TryValidateModel(commandToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(commandToPatch, commandItem);
            _repository.UpdateCJobOrder(commandItem);
            _repository.SaveChanges();

            return NoContent();
        }




        [HttpDelete("{id}")]
        public ActionResult RemoveJobOrder(int id)
        {
            var commandItem = _repository.GetJobOrderById(id);
            if (commandItem == null)
            {
                return NotFound();
            }
            _repository.DeleteJobOrder(commandItem);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}
