using System;

namespace LocalGoods.BLL.Exceptions.NotFoundException
{
    public class UserNotFoundException : NotFoundException
    {
        public UserNotFoundException() : base("User was not found") { }

        public UserNotFoundException(Guid id) : base($"User with id {id} was not found") { }

        public UserNotFoundException(string email): base($"User with email {email} was not found"){}
    }
}
