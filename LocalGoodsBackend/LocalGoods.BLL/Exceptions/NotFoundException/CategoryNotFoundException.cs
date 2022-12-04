using System;

namespace LocalGoods.BLL.Exceptions.NotFoundException
{
    public class CategoryNotFoundException : NotFoundException
    {
        public CategoryNotFoundException() { }

        public CategoryNotFoundException(Guid id) : base($"Category with id {id} was not found") { }
    }
}
