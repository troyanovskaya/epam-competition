﻿using System;

namespace LocalGoods.BLL.Exceptions.NotFoundException
{
    public class UnitTypeNotFoundException : NotFoundException
    {
        public UnitTypeNotFoundException() : base() { }

        public UnitTypeNotFoundException(Guid id) : base($"Unit type with id {id} was not found") { }
    }
}
