using Anthurium.API.Dtos;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Anthurium.API.Controllers
{
    public interface IClientInformationController
    {
        ActionResult<ClientInformationReadDto> ClientInformationById(int id);
        ActionResult<ClientInformationReadDto> CreateCommand(ClientInformationCreateDto commandCreate);
        ActionResult<IEnumerable<ClientInformationReadDto>> GetAllCommands();
        ActionResult PartialUpdate(int id, JsonPatchDocument<ClientInformationUpdateDto> patchDocument);
        ActionResult RemoveClientInformation(int id);
        ActionResult UpdateClientInformation(int id, ClientInformationUpdateDto ClientInformationUpdateDto);
    }
}