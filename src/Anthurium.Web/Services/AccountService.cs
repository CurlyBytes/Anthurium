using Anthurium.Web.Models;
using Anthurium.Web.Models.Account;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Anthurium.Web.Services
{
    public class AccountService : IAccountService
    {
        private IHttpService _httpService;
        private NavigationManager _navigationManager;
        private ILocalStorageService _localStorageService;
        private string _userKey = "user";

        public User User { get; private set; }

        public AccountService(
            IHttpService httpService,
            NavigationManager navigationManager,
            ILocalStorageService localStorageService
        )
        {
            _httpService = httpService;
            _navigationManager = navigationManager;
            _localStorageService = localStorageService;
        }

        public async Task Initialize()
        {
            User = await _localStorageService.GetItem<User>(_userKey);
        }

        public async Task Login(Login model)
        {
            User = await _httpService.Post<User>("/api/user/authenticate", model);
            await _localStorageService.SetItem(_userKey, User);
        }

        public async Task Logout()
        {
            User = null;
            await _localStorageService.RemoveItem(_userKey);
            _navigationManager.NavigateTo("account/login");
        }

        public async Task Register(AddUser model)
        {
            await _httpService.Post("/api/user/register", model);
        }

        public async Task<IList<User>> GetAll()
        {
            return await _httpService.Get<IList<User>>("/api/user");
        }

        public async Task<User> GetById(string id)
        {
            return await _httpService.Get<User>($"/api/user/{id}");
        }

        public async Task Update(string id, EditUser model)
        {
            await _httpService.Put($"/api/user/{id}", model);

            // update stored user if the logged in user updated their own record
            if (id == User.Id)
            {
                // update local storage
                User.FirstName = model.FirstName;
                User.LastName = model.LastName;
                User.Username = model.Username;
                await _localStorageService.SetItem(_userKey, User);
            }
        }

        public async Task Delete(string id)
        {
            await _httpService.Delete($"/api/user/{id}");

            // auto logout if the logged in user deleted their own record
            if (id == User.Id)
                await Logout();
        }
    }
}
