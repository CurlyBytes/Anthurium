using Anthurium.API.Dtos;
using Anthurium.API.Repositories;
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

    [ODataRoutePrefix("jobquotationdetails")]
    [Route("api/jobquotationdetails")]
    [ApiController]
    public class JobQuotationDetailsController : ODataController
    {

        private readonly ISqlServerJobOrderQuotationDetails _repository;
        private readonly IMapper _mapper;

        public JobQuotationDetailsController(ISqlServerJobOrderQuotationDetails repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [EnableQuery(PageSize = 50)]
        [HttpGet]
        [ODataRoute]
        public ActionResult<IEnumerable<JobQuotationDetailsReadDto>> GetAllJobOrderQuotatationDetails()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var jobQuotationDetailItems = _repository.GetJobQuotationDetails();
            if (jobQuotationDetailItems?.Any(p => p.Description == null) == true)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<IEnumerable<JobQuotationDetailsReadDto>>(jobQuotationDetailItems));
        }


        [HttpGet("{id}", Name = "JobQuotationDetailsById")]
        [EnableQuery]
        [ODataRoute("({id})")]
        public ActionResult<JobQuotationDetailsReadDto> JobQuotationDetailsById([FromODataUri] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var jobQuotationDetailItem = _repository.GetJobQuotationDetailsById(id);
            if (jobQuotationDetailItem == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<JobQuotationDetailsReadDto>(jobQuotationDetailItem));
        }

        [HttpGet("jobquotation/{id}", Name = "GetJobQuotationDetailsByJobQuotation")]
        [EnableQuery]
        [ODataRoute("jobquotation(JobQuotationId={id})")]
        public ActionResult<IEnumerable<JobQuotationDetailsReadDto>> GetJobQuotationDetailsByJobQuotation([FromODataUri] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var jobQuotationDetailItem = _repository.GetJobQuotationDetailsByJobQuotation(id);
            if (jobQuotationDetailItem?.Any() == false)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<IEnumerable<JobQuotationDetailsReadDto>>(jobQuotationDetailItem));
     
        }



        [HttpPost]
        [ODataRoute]
        public ActionResult<JobQuotationDetailsReadDto> NewJobQuotationDetails([FromBody] JobQuotationDetailsCreateDto jobQuotationDetailCreate)
        {
            JobQuotationDetails jobQuotationDetailItem = _mapper.Map<JobQuotationDetails>(jobQuotationDetailCreate);

            _repository.NewJobQuotationDetails(jobQuotationDetailItem);
            _repository.SaveChanges();

            JobQuotationDetailsReadDto jobQuotationDetailsReadDto = _mapper.Map<JobQuotationDetailsReadDto>(jobQuotationDetailItem);

            return CreatedAtRoute(nameof(JobQuotationDetailsById), new { Id = jobQuotationDetailsReadDto.JobQuotationId }, jobQuotationDetailsReadDto);
        }

        [HttpPut("{id}")]
        [ODataRoute("({id})")]
        public ActionResult UpdateJobQuotationDetails([FromODataUri] int id, [FromBody] JobQuotationDetailsUpdateDto jobQuotationDetailsUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var jobQuotationDetailItem = _repository.GetJobQuotationDetailsById(id);
            if (jobQuotationDetailItem == null)
            {
                return NotFound();
            }

            _mapper.Map(jobQuotationDetailsUpdateDto, jobQuotationDetailItem);
            _repository.UpdateJobQuotationDetails(jobQuotationDetailItem);
            _repository.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ODataRoute("({id})")]
        public ActionResult RemoveJobQuotationDetails([FromODataUri] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var JobQuotationDetailItem = _repository.GetJobQuotationDetailsById(id);
            if (JobQuotationDetailItem == null)
            {
                return NotFound();
            }
            _repository.RemoveJobQuotationDetails(JobQuotationDetailItem);
            _repository.SaveChanges();

            return NoContent();
        }

    }
}
