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
    [ODataRoutePrefix("joborderdescriptionofwork")]
    [Route("api/joborderdescriptionofwork")]
    [ApiController]

    public class JobOrderDescriptionOfWorkController : ODataController
    {
        private readonly IJobOrderDescriptionOfWork _repository;
        private readonly IMapper _mapper;

        public JobOrderDescriptionOfWorkController(IJobOrderDescriptionOfWork repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [EnableQuery(PageSize = 50)]
        [HttpGet]
        [ODataRoute]
        public ActionResult<IEnumerable<JobOrderDescriptionOfWorkReadDto>> GetAllJobOrderDescription()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var commandItems = _repository.GetJobOrderDescriptionOfWork();

            return Ok(_mapper.Map<IEnumerable<JobOrderDescriptionOfWorkReadDto>>(commandItems));
        }

        [HttpGet("{id}", Name = "JobOrderDescriptionOfWorkById")]
        [EnableQuery]
        [ODataRoute("({id})")]
        public ActionResult<JobOrderDescriptionOfWorkReadDto> JobOrderDescriptionOfWorkById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var commandItem = _repository.JobOrderDescriptionOfWorkById(id);
            if (commandItem == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<JobOrderDescriptionOfWorkReadDto>(commandItem));
        }

        [HttpPost]
        [ODataRoute]
        public ActionResult<JobOrderDescriptionOfWorkReadDto> CreateCommand(JobOrderDescriptionOfWorkCreateDto commandCreate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            JobOrderDescriptionOfWork commandItem = _mapper.Map<JobOrderDescriptionOfWork>(commandCreate);

            _repository.NewJobOrderDescriptionOfWork(commandItem);
            _repository.SaveChanges();

            JobOrderDescriptionOfWorkReadDto JobOrderDescriptionOfWorkReadDto = _mapper.Map<JobOrderDescriptionOfWorkReadDto>(commandItem);

            return CreatedAtRoute(nameof(JobOrderDescriptionOfWorkById), new { Id = JobOrderDescriptionOfWorkReadDto.JobOrderDescriptionOfWorkId }, JobOrderDescriptionOfWorkReadDto);
        }

        [HttpPut("{id}")]
        [ODataRoute("({id})")]
        public ActionResult UpdateJobOrderDescriptionOfWork(int id, JobOrderDescriptionOfWorkUpdateDto JobOrderDescriptionOfWorkUpdateDto)
        {
            var commandItem = _repository.JobOrderDescriptionOfWorkById(id);
            if (commandItem == null)
            {
                return NotFound();
            }

            _mapper.Map(JobOrderDescriptionOfWorkUpdateDto, commandItem);
            _repository.UpdateJobOrderDescriptionOfWork(commandItem);
            _repository.SaveChanges();
            return NoContent();
        }

        [HttpPatch("{id}")]
        [ODataRoute("({id})")]
        public ActionResult PartialUpdate(int id, JsonPatchDocument<JobOrderDescriptionOfWorkUpdateDto> patchDocument)
        {
            var commandItem = _repository.JobOrderDescriptionOfWorkById(id);
            if (commandItem == null)
            {
                return NotFound();
            }

            JobOrderDescriptionOfWorkUpdateDto commandToPatch = _mapper.Map<JobOrderDescriptionOfWorkUpdateDto>(commandItem);

            patchDocument.ApplyTo(commandToPatch, (Microsoft.AspNetCore.JsonPatch.Adapters.IObjectAdapter)ModelState);
            if (!TryValidateModel(commandToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(commandToPatch, commandItem);
            _repository.UpdateJobOrderDescriptionOfWork(commandItem);
            _repository.SaveChanges();

            return NoContent();
        }




        [HttpDelete("{id}")]
        [ODataRoute("({id})")]
        public ActionResult RemoveJobOrderDescriptionOfWork(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var commandItem = _repository.JobOrderDescriptionOfWorkById(id);
            if (commandItem == null)
            {
                return NotFound();
            }
            _repository.RemoveJobOrderDescriptionOfWork(commandItem);
            _repository.SaveChanges();

            return NoContent();
        }
    }

}
