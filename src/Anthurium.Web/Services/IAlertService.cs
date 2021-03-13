using Anthurium.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Anthurium.Web.Services
{
    public interface IAlertService
    {
        event Action<Alert> OnAlert;
        void Success(string message, bool keepAfterRouteChange = false, bool autoClose = true);
        void Error(string message, bool keepAfterRouteChange = false, bool autoClose = true);
        void Info(string message, bool keepAfterRouteChange = false, bool autoClose = true);
        void Warn(string message, bool keepAfterRouteChange = false, bool autoClose = true);
        void Alert(Alert alert);
        void Clear(string id = null);
    }
}
