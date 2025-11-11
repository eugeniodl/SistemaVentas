using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVentasApp.Models.Repository.Interfaces
{
    internal interface IUserRepository
    {
        Task<string> AuthenticateUserAsync(string username, string password);
    }
}
