using AutoMapper;
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
        public ActionResult<IEnumerable<ClientInformationReadDto>> GetAllClientInformation()
        {
            var valuesFromRepository = _repository.GetJobOrders();

            return Ok(_mapper.Map<IEnumerable<ClientInformationReadDto>>(valuesFromRepository));
        }
    }
}
