﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoXUnitTest.Models.Repositories
{
    public interface IItemRepository
    {
        IQueryable<Item> Items { get; }
        Item Save(Item item);
        Item Edit(Item item);
        void Remove(Item item);
        void RemoveAll(IQueryable<Item> Items);
    }
}
