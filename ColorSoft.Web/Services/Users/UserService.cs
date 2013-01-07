using System;
using System.Collections.Generic;
using ColorSoft.Web.Commands.Users;
using ColorSoft.Web.Data.Models;
using ColorSoft.Web.Queries.Users;
using ColorSoft.Web.Validation;

namespace ColorSoft.Web.Services.Users
{
    public class UserService : IUserService
    {
        private readonly ICreateUserCommand _createUserCommand;
        private readonly IDeleteUserCommand _deleteUserCommand;
        private readonly IGetAllNonDeletedUsersQuery _getAllNonDeletedUsersQuery;
        private readonly IGetUserByIdQuery _getUserByIdQuery;
        private readonly IUpdateUserCommand _updateUserCommand;
        private readonly IGetUserByUsernameQuery _getUserByUsernameQuery;
        private readonly IGetUserByEmailQuery _getUserByEmailQuery;

        public UserService(IDeleteUserCommand deleteUserCommand,
                           IUpdateUserCommand updateUserCommand,
                           ICreateUserCommand createUserCommand,
                           IGetUserByIdQuery getUserByIdQuery,
                           IGetAllNonDeletedUsersQuery getAllNonDeletedUsersQuery,
                           IGetUserByUsernameQuery getUserByUsernameQuery, 
                           IGetUserByEmailQuery getUserByEmailQuery)
        {
            _deleteUserCommand = deleteUserCommand;
            _updateUserCommand = updateUserCommand;
            _createUserCommand = createUserCommand;
            _getUserByIdQuery = getUserByIdQuery;
            _getAllNonDeletedUsersQuery = getAllNonDeletedUsersQuery;
            _getUserByUsernameQuery = getUserByUsernameQuery;
            _getUserByEmailQuery = getUserByEmailQuery;
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
            CheckCreateOrUpdateArguments(user);
            _createUserCommand.Execute(user);
        }

        public void Update(User user)
        {
            CheckCreateOrUpdateArguments(user);
            _updateUserCommand.Execute(user);
        }

        public void Delete(params Guid[] ids)
        {
            if(ids == null)
            {
                return;
            }

            foreach (var id in ids)
            {
                _deleteUserCommand.Execute(id);   
            }
        }

        private void CheckCreateOrUpdateArguments(User user)
        {
            var otherWithUserName = _getUserByUsernameQuery.Execute(user.UserName);
            var otherWithEmail = _getUserByEmailQuery.Execute(user.EmailAddress);

            if (otherWithEmail != null || otherWithUserName != null)
            {
                var ex = new ApplicationValidationException();

                if(otherWithUserName != null)
                {
                    ex.AddError("UserName", "The user name selected is not available.");
                }

                if(otherWithEmail != null)
                {
                    ex.AddError("EmailAddress", "The email address selected is not available.");
                }

                throw ex;
            }
        }

        #endregion
    }
}