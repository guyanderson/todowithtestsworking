﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace ToDoXUnitTest.Models.Repositories
{
    public class EFItemRepository : IItemRepository
    {
        ToDoDbContext db = new ToDoDbContext();
        public EFItemRepository(ToDoDbContext connection = null)
        {
            if (connection == null)
            {
                this.db = new ToDoDbContext();
            }
            else
            {
                this.db = connection;
            }
        }
        public IQueryable<Item> Items
        { get { return db.Items; } }

        public Item Save(Item item)
        {
            db.Items.Add(item);
            db.SaveChanges();
            return item;
        }

        public Item Edit(Item item)
        {
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
            return item;
        }

        public void Remove(Item item)
        {
            db.Items.Remove(item);
            db.SaveChanges();
        }
        public void RemoveAll(IQueryable<Item> items)
        {
            db.Items.RemoveRange(items);
            db.SaveChanges();
        }
    }
}
