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
    [Route("api/joborderdescriptionofwork")]
    [ApiController]
    
    public class JobOrderDescriptionOfWorkController : ControllerBase
    {
        private readonly IJobOrderDescriptionOfWork _repository;
        private readonly IMapper _mapper;

        public JobOrderDescriptionOfWorkController(IJobOrderDescriptionOfWork repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<JobOrderDescriptionOfWorkReadDto>> GetAllJobOrderDescription()
        {
            var commandItems = _repository.GetJobOrderDescriptionOfWork();

            return Ok(_mapper.Map<IEnumerable<JobOrderDescriptionOfWorkReadDto>>(commandItems));
        }

        [HttpGet("{id}", Name = "JobOrderDescriptionOfWorkById")]
        public ActionResult<JobOrderDescriptionOfWorkReadDto> JobOrderDescriptionOfWorkById(int id)
        {
            var commandItem = _repository.JobOrderDescriptionOfWorkById(id);
            if (commandItem == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<JobOrderDescriptionOfWorkReadDto>(commandItem));
        }

        [HttpPost]
        public ActionResult<JobOrderDescriptionOfWorkReadDto> CreateCommand(JobOrderDescriptionOfWorkCreateDto commandCreate)
        {
            JobOrderDescriptionOfWork commandItem = _mapper.Map<JobOrderDescriptionOfWork>(commandCreate);

            _repository.NewJobOrderDescriptionOfWork(commandItem);
            _repository.SaveChanges();

            JobOrderDescriptionOfWorkReadDto JobOrderDescriptionOfWorkReadDto = _mapper.Map<JobOrderDescriptionOfWorkReadDto>(commandItem);

            return CreatedAtRoute(nameof(JobOrderDescriptionOfWorkById), new { Id = JobOrderDescriptionOfWorkReadDto.Id }, JobOrderDescriptionOfWorkReadDto);
        }

        [HttpPut("{id}")]
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
        public ActionResult PartialUpdate(int id, JsonPatchDocument<JobOrderDescriptionOfWorkUpdateDto> patchDocument)
        {
            var commandItem = _repository.JobOrderDescriptionOfWorkById(id);
            if (commandItem == null)
            {
                return NotFound();
            }

            JobOrderDescriptionOfWorkUpdateDto commandToPatch = _mapper.Map<JobOrderDescriptionOfWorkUpdateDto>(commandItem);

            patchDocument.ApplyTo(commandToPatch, ModelState);
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
        public ActionResult RemoveJobOrderDescriptionOfWork(int id)
        {
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
