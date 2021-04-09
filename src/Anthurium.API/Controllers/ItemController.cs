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

namespace Anthurium.API.Controllers {
  [ODataRoutePrefix("item")]
  [Route("api/item")]
  [ApiController]
  [Authorize]

  public class ItemController : ODataController {
    private readonly ISqlServerItemRepository _repository;
    private readonly IMapper _mapper;

    public ItemController(ISqlServerItemRepository repository, IMapper mapper) {
      _repository = repository;
      _mapper = mapper;
    }

    [EnableQuery(PageSize = 50)]
    [HttpGet]
    [ODataRoute]
    public ActionResult<IEnumerable<ItemReadDto>> GetAllCommands() {
      if (!ModelState.IsValid) {
        return BadRequest(ModelState);
      }
      var commandItems = _repository.GetItem();
      if (commandItems?.Any() == false) {
        return NotFound();
      }
      return Ok(_mapper.Map<IEnumerable<ItemReadDto>>(commandItems));
    }

    [HttpGet("{id}", Name = "ItemById")]
    [EnableQuery]
    [ODataRoute("({id})")]
    public ActionResult<ItemReadDto> ItemById([ FromODataUri ] int id) {
      if (!ModelState.IsValid) {
        return BadRequest(ModelState);
      }
      var commandItem = _repository.ItemById(id);
      if (commandItem == null) {
        return NotFound();
      }

      return Ok(_mapper.Map<ItemReadDto>(commandItem));
    }

    [HttpPost]
    [ODataRoute]
    public ActionResult<ItemReadDto>
    CreateCommand([ FromBody ] ItemCreateDto commandCreate) {
      Item commandItem = _mapper.Map<Item>(commandCreate);

      _repository.NewItem(commandItem);
      _repository.SaveChanges();

      ItemReadDto ItemReadDto = _mapper.Map<ItemReadDto>(commandItem);

      return CreatedAtRoute(nameof(ItemById), new {Id = ItemReadDto.ItemId},
                            ItemReadDto);
    }

    [HttpPut("{id}")]
    [ODataRoute("({id})")]
    public ActionResult UpdateItem([ FromODataUri ] int id,
                                   [ FromBody ] ItemUpdateDto ItemUpdateDto) {
      if (!ModelState.IsValid) {
        return BadRequest(ModelState);
      }
      var commandItem = _repository.ItemById(id);
      if (commandItem == null) {
        return NotFound();
      }

      _mapper.Map(ItemUpdateDto, commandItem);
      _repository.UpdateItem(commandItem);
      _repository.SaveChanges();
      return NoContent();
    }

    [ODataRoute("({id})")]
    [HttpPatch("{id}")]
    public ActionResult PartialUpdate([ FromODataUri ] int id,
                                      Delta<ItemUpdateDto> patchDocument) {
      if (!ModelState.IsValid) {
        return BadRequest(ModelState);
      }
      var commandItem = _repository.ItemById(id);
      if (commandItem == null) {
        return NotFound();
      }

      ItemUpdateDto commandToPatch = _mapper.Map<ItemUpdateDto>(commandItem);
      patchDocument.Patch(commandToPatch);

      if (!TryValidateModel(commandToPatch)) {
        return ValidationProblem(ModelState);
      }

      _mapper.Map(commandToPatch, commandItem);
      _repository.UpdateItem(commandItem);
      _repository.SaveChanges();

      return NoContent();
    }

    [HttpDelete("{id}")]
    [ODataRoute("({id})")]
    public ActionResult RemoveItem([ FromODataUri ] int id) {
      if (!ModelState.IsValid) {
        return BadRequest(ModelState);
      }
      var commandItem = _repository.ItemById(id);
      if (commandItem == null) {
        return NotFound();
      }
      _repository.RemoveItem(commandItem);
      _repository.SaveChanges();

      return NoContent();
    }
  }
}
