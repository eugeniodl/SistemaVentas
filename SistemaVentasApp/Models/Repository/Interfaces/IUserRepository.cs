using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVentasApp.Models.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<string> ValidateCredentialsAsync(string username, string password);
    }
}
