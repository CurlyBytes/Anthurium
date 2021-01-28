using Anthurium.API.Dtos;
using Microsoft.AspNet.OData;
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
        ActionResult PartialUpdate(int id, Delta<ClientInformationUpdateDto> patchDocument);
        ActionResult RemoveClientInformation(int id);
        ActionResult UpdateClientInformation(int id, ClientInformationUpdateDto ClientInformationUpdateDto);
    }
}