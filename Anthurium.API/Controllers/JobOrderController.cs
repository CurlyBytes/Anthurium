using Anthurium.API.Dtos;
using Anthurium.Shared.Models;
using Anthurium.Web.Repositories;
using AutoMapper;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
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
    [ODataRoutePrefix("joborder")]
    public class JobOrderController : ODataController
    {
        private readonly IJobOrderRepository _repository;
        private readonly IMapper _mapper;

        public JobOrderController(IJobOrderRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [EnableQuery(PageSize = 50)]
        [HttpGet]
        [ODataRoute]
        public ActionResult<IEnumerable<JobOrderReadDto>> GetJobOrders()
        {
            var commandItems = _repository.GetJobOrders();

            return Ok(_mapper.Map<IEnumerable<JobOrderReadDto>>(commandItems));
        }

        [HttpGet("{id}", Name = "JobOrderById")]
        [EnableQuery]
        [ODataRoute("({id})")]
        public ActionResult<JobOrderReadDto> JobOrderById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var commandItem = _repository.GetJobOrderById(id);
            if (commandItem == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<JobOrderReadDto>(commandItem));
        }

        [HttpPost]
        [ODataRoute]
        public ActionResult<JobOrderReadDto> CreateJobOrder(JobOrderCreateDto commandCreate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            JobOrder commandItem = _mapper.Map<JobOrder>(commandCreate);

            _repository.CreateJobOrder(commandItem);
            _repository.SaveChanges();

            JobOrderReadDto JobOrderReadDto = _mapper.Map<JobOrderReadDto>(commandItem);

            return CreatedAtRoute(nameof(JobOrderById), new { Id = JobOrderReadDto.JobOrderId }, JobOrderReadDto);
        }

        [HttpPut("{id}")]
        [ODataRoute("({id})")]
        public ActionResult UpdateJobOrder(int id, JobOrderUpdateDto JobOrderUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
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
        [ODataRoute("({id})")]
        public ActionResult PartialUpdate(int id, JsonPatchDocument<JobOrderUpdateDto> patchDocument)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
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
        [ODataRoute("({id})")]
        public ActionResult RemoveJobOrder(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
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
