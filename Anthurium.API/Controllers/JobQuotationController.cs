using Anthurium.API.Dtos;
using Anthurium.API.Repositories;
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

    [Route("api/jobquotation")]
    [ApiController]
    [ODataRoutePrefix("jobquotation")]
    [Authorize]
    public class JobQuotationController : ODataController
    {
        private readonly ISqlServerJobQuotationRepository _repository;
        
        private readonly IMapper _mapper;

        public JobQuotationController(ISqlServerJobQuotationRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [EnableQuery(PageSize = 50)]
        [HttpGet]
        [ODataRoute]
        public ActionResult<IEnumerable<JobQuotationReadDto>> GetJobOrders()
        {
            var jobOrderItems = _repository.GetJobQuotations();

            return Ok(_mapper.Map<IEnumerable<JobQuotationReadDto>>(jobOrderItems));
        }

        [HttpGet("{id}", Name = "JobQuotationById")]
        [EnableQuery]
        [ODataRoute("({id})")]
        public ActionResult<JobQuotationReadDto> JobQuotationById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var jobOrderItem = _repository.JobOrderQuotationByIdOnly(id);
            if (jobOrderItem == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<JobQuotationReadDto>(jobOrderItem));
        }

        [HttpGet("clientinformation/{id}", Name = "JobOrderQuotationByClient")]
        [EnableQuery]
        [ODataRoute("ClientInformation(ClientInformationId={id})")]
        public ActionResult<IEnumerable<ClientInformationReadDto>> JobOrderQuotationByClient([FromODataUri] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var jobQuotationItem = _repository.JobQuotationByClient(id);
            if (jobQuotationItem?.Any() == false)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<IEnumerable<ClientInformationReadDto>>(jobQuotationItem));

        }


        [HttpPost]
        [ODataRoute]
        public ActionResult<JobQuotationReadDto> NewJobQuotation([FromBody] JobQuotationCreateDto jobQuotationCreate)
        {
            JobQuotation jobQuotationItem = _mapper.Map<JobQuotation>(jobQuotationCreate);

            _repository.NewJobQuotation(jobQuotationItem);
            // begin


           //end


            _repository.SaveChanges();

            JobQuotationReadDto jobQuotationsReadDto = _mapper.Map<JobQuotationReadDto>(jobQuotationItem);

            return CreatedAtRoute(nameof(JobQuotationById), new { Id = jobQuotationsReadDto.JobQuotationId }, jobQuotationsReadDto);
        }


        [HttpPut("{id}")]
        [ODataRoute("({id})")]
        public ActionResult UpdateJobQuotation([FromODataUri] int id, [FromBody] JobQuotationUpdateDto jobQuotationDetailsUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var jobQuotationDetailItem = _repository.JobOrderQuotationByIdOnly(id);
            if (jobQuotationDetailItem == null)
            {
                return NotFound();
            }

            _mapper.Map(jobQuotationDetailsUpdateDto, jobQuotationDetailItem);
            _repository.UpdateJobQuotation(jobQuotationDetailItem);
            _repository.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ODataRoute("({id})")]
        public ActionResult RemoveJobQuotation([FromODataUri] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var JobQuotationItem = _repository.JobOrderQuotationByIdOnly(id);
            if (JobQuotationItem == null)
            {
                return NotFound();
            }
            _repository.RemoveJobQuotation(JobQuotationItem);
            _repository.SaveChanges();

            return NoContent();
        }
    }

}
