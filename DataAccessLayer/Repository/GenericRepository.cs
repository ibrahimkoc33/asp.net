﻿using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class GenericRepository<T> : IGeneric<T> where T : class
    {
        public void Add(T t)
        {
            using var c = new Context();
            c.Add(t);
            c.SaveChanges();
        }

        public void Delete(T t)
        {
            using var c = new Context();
            c.Remove(t);
            c.SaveChanges();
        }

        public T GetById(int id)
        {
            using var c = new Context();
            return c.Set<T>().Find(id);
        }

        public List<T> ListAll()
        {
            using var c = new Context();
            return c.Set<T>().ToList();
        }

		public List<T> ListAll(Expression<Func<T, bool>> filter)
		{
            using var c = new Context();
			return c.Set<T>().Where(filter).ToList();
		}

		public void Update(T t)
        {
            using var c = new Context();
            c.Update(t);
            c.SaveChanges(); 
        }
    }
}
