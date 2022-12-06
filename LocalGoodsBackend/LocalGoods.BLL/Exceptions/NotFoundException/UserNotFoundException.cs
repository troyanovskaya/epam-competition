using System;

namespace LocalGoods.BLL.Exceptions.NotFoundException
{
    public class UserNotFoundException : NotFoundException
    {
        public UserNotFoundException() : base("User was not found") { }

        public UserNotFoundException(Guid id) : base($"User with id {id} was not found") { }
    }
}
