using Anthurium.Web.Repositories;
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
        public ActionResult RunningTotalOfClients()
        {
   
            var returnResult = _iClientInformation.RunningTotalOfClients();
     

            return Ok(returnResult);
        }

        [HttpGet("joborderwithinmonth", Name = "NewJobOrderByDateWithin30Days")]
        [EnableQuery]
        [ODataRoute("joborderwithinmonth")]
        public ActionResult NewJobOrderByDateWithin30Days()
        {

            var returnResult = _iJobOrderRepository.NewJobOrderByDateWithin30Days();


            return Ok(returnResult);
        }

        [HttpGet("joborderperclient", Name = "JobOrderPerClient")]
        [EnableQuery]
        [ODataRoute("joborderperclient")]
        public ActionResult JobOrderPerClient()
        {

            var returnResult = _iJobOrderRepository.JobOrderPerClient();


            return Ok(returnResult);
        }
    }
}
