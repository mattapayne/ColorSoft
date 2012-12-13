using System;
using System.Collections.Generic;
using ColorSoft.Web.Data.Models;

namespace ColorSoft.Web.Services.Users
{
    public interface IUserService : IApplicationService
    {
        IEnumerable<User> GetAllNonDeletedUsers();
        User GetById(Guid id);
        void Create(User user);
        void Update(User user);
        void Delete(params Guid[] ids);
    }
}