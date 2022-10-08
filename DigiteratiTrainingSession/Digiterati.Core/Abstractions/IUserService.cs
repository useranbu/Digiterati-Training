using Core.ViewModel;
using Digiterati.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digiterati.Core.Abstractions
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        IEnumerable<Users> GetAll();
        Users GetById(int id);
    }
}
