
using Anthurium.Web.Models;
using Anthurium.Web.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Anthurium.Web.Services
{
    public interface IAccountService
    {
        User User { get; }
        Task Initialize();
        Task Login(Login model);
        Task Logout();
        Task Register(AddUser model);
        Task<IList<User>> GetAll();
        Task<User> GetById(string id);
        Task Update(string id, EditUser model);
        Task Delete(string id);
    }
}
