using System;
using System.Collections.Generic;
using System.Text;
using Models;

namespace Buisnes
{
    public interface IUserService
    {
        IEnumerable<UserModel> GetAll();
        void RegisterUser(UserModel user);
    }
}
