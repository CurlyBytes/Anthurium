using Anthurium.API.Dtos;
using Anthurium.API.Repositories.SqlServer;
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
    [ODataRoutePrefix("asset")]
    [Route("api/asset")]
    [ApiController]
    [Authorize]
    public class AssetController : ODataController
    {
        private readonly ISqlServerAssetRepository _repository;
        private readonly IMapper _mapper;

        public AssetController(ISqlServerAssetRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        [EnableQuery(PageSize = 50)]
        [HttpGet]
        [ODataRoute]
        public ActionResult<IEnumerable<AssetReadDto>> GetAllCommands()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var commandAssets = _repository.GetAsset();
            if (commandAssets?.Any() == false)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<IEnumerable<AssetReadDto>>(commandAssets));
        }

        [HttpGet("{id}", Name = "AssetById")]
        [EnableQuery]
        [ODataRoute("({id})")]
        public ActionResult<AssetReadDto> AssetById([FromODataUri] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var commandAsset = _repository.AssetById(id);
            if (commandAsset == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<AssetReadDto>(commandAsset));
        }




        [HttpPost]
        [ODataRoute]
        public ActionResult<AssetReadDto> CreateCommand([FromBody] AssetCreateDto commandCreate)
        {
            Asset commandAsset = _mapper.Map<Asset>(commandCreate);

            _repository.NewAsset(commandAsset);
            _repository.SaveChanges();

            AssetReadDto AssetReadDto = _mapper.Map<AssetReadDto>(commandAsset);

            return CreatedAtRoute(nameof(AssetById), new { Id = AssetReadDto.AssetId }, AssetReadDto);
        }

        [HttpPut("{id}")]
        [ODataRoute("({id})")]
        public ActionResult UpdateAsset([FromODataUri] int id, [FromBody] AssetUpdateDto AssetUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var commandAsset = _repository.AssetById(id);
            if (commandAsset == null)
            {
                return NotFound();
            }

            _mapper.Map(AssetUpdateDto, commandAsset);
            _repository.UpdateAsset(commandAsset);
            _repository.SaveChanges();
            return NoContent();
        }


        [ODataRoute("({id})")]
        [HttpPatch("{id}")]
        public ActionResult PartialUpdate([FromODataUri] int id, Delta<AssetUpdateDto> patchDocument)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var commandAsset = _repository.AssetById(id);
            if (commandAsset == null)
            {
                return NotFound();
            }

            AssetUpdateDto commandToPatch = _mapper.Map<AssetUpdateDto>(commandAsset);
            patchDocument.Patch(commandToPatch);

            if (!TryValidateModel(commandToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(commandToPatch, commandAsset);
            _repository.UpdateAsset(commandAsset);
            _repository.SaveChanges();

            return NoContent();
        }




        [HttpDelete("{id}")]
        [ODataRoute("({id})")]
        public ActionResult RemoveAsset([FromODataUri] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var commandAsset = _repository.AssetById(id);
            if (commandAsset == null)
            {
                return NotFound();
            }
            _repository.RemoveAsset(commandAsset);
            _repository.SaveChanges();

            return NoContent();
        }


    }
}
