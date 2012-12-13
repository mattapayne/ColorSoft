using System;
using System.Collections.Generic;
using ColorSoft.Web.Commands.Users;
using ColorSoft.Web.Data.Models;
using ColorSoft.Web.Queries.Users;

namespace ColorSoft.Web.Services.Users
{
    public class UserService : IUserService
    {
        private readonly ICreateUserCommand _createUserCommand;
        private readonly IDeleteUserCommand _deleteUserCommand;
        private readonly IGetAllNonDeletedUsersQuery _getAllNonDeletedUsersQuery;
        private readonly IGetUserByIdQuery _getUserByIdQuery;
        private readonly IUpdateUserCommand _updateUserCommand;

        public UserService(IDeleteUserCommand deleteUserCommand,
                           IUpdateUserCommand updateUserCommand,
                           ICreateUserCommand createUserCommand,
                           IGetUserByIdQuery getUserByIdQuery,
                           IGetAllNonDeletedUsersQuery getAllNonDeletedUsersQuery)
        {
            _deleteUserCommand = deleteUserCommand;
            _updateUserCommand = updateUserCommand;
            _createUserCommand = createUserCommand;
            _getUserByIdQuery = getUserByIdQuery;
            _getAllNonDeletedUsersQuery = getAllNonDeletedUsersQuery;
        }

        #region IUserService Members

        public IEnumerable<User> GetAllNonDeletedUsers()
        {
            return _getAllNonDeletedUsersQuery.Execute();
        }

        public User GetById(Guid id)
        {
            return _getUserByIdQuery.Execute(id);
        }

        public void Create(User user)
        {
            //TODO - additional business logic here
            //TODO - catch exceptions
            _createUserCommand.Execute(user);
        }

        public void Update(User user)
        {
            //TODO - additional business logic here
            //TODO - catch exceptions
            _updateUserCommand.Execute(user);
        }

        public void Delete(params Guid[] ids)
        {
            if(ids == null)
            {
                return;
            }
            //TODO - additional business logic here
            //TODO - catch exceptions
            foreach (var id in ids)
            {
                _deleteUserCommand.Execute(id);   
            }
        }

        #endregion
    }
}