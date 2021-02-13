using Anthurium.API.Dtos;
using Anthurium.Web.Repositories;
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
    [ODataRoutePrefix("dashboard")]
    [Route("api/dashboard")]
    [ApiController]

    public class DashBoardController : Controller
    {
        private readonly IClientInformation _iClientInformation;
        private readonly IJobOrderRepository _iJobOrderRepository;
    

        public DashBoardController(
            IClientInformation iClientInformation,
            IJobOrderRepository iJobOrderRepository
            )
        {
            _iClientInformation = iClientInformation;
            _iJobOrderRepository = iJobOrderRepository;
        
        }


        [HttpGet("totalclients", Name = "RunningTotalOfClients")]
        [EnableQuery]
        [ODataRoute("totalclients", RouteName = "RunningTotalOfClients")]
        public ActionResult<int> RunningTotalOfClients()
        {
   
            var RunningTotalOfClientsReadDto = _iClientInformation.RunningTotalOfClients();


            return Ok(RunningTotalOfClientsReadDto);
        }

        [HttpGet("joborderwithinmonth", Name = "NewJobOrderByDateWithin30Days")]
        [EnableQuery]
        [ODataRoute("joborderwithinmonth")]
        public ActionResult<NewJobOrderByDateWithin30DaysReadDto> NewJobOrderByDateWithin30Days()
        {

            var returnResult = _iJobOrderRepository.NewJobOrderByDateWithin30Days();

            NewJobOrderByDateWithin30DaysReadDto count = new NewJobOrderByDateWithin30DaysReadDto();

            count.NewJobOrderByDateWithin30DaysCount = returnResult;

            return Ok(count.NewJobOrderByDateWithin30DaysCount);
        }

        [HttpGet("joborderperclient", Name = "JobOrderPerClient")]
        [EnableQuery]
        [ODataRoute("joborderperclient")]
        public ActionResult<JobOrderPerClientReadDto> JobOrderPerClient()
        {

            var returnResult = _iJobOrderRepository.JobOrderPerClient();



            return Ok(returnResult);
        }
    }
}
