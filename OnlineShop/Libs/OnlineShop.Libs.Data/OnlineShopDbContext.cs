﻿using OnlineShop.Libs.Data.Contracts;
using System.Data.Entity;
using System;
using OnlineShop.Libs.Data.Factories;
using OnlineShop.Libs.Models;

namespace OnlineShop.Libs.Data
{
    public class OnlineShopDbContext : DbContext, IOnlineShopDbContext
    {
        private static string localConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=OnlineShop;Integrated Security=True;MultipleActiveResultSets=False";
        private readonly IStatefulFactory statefulFactory;

        // // needed for add-migration 
        //public OnlineShopDbContext()
        //    : base(localConnectionString)
        //{

        //}

        public OnlineShopDbContext(string connectionString, IStatefulFactory statefulFactory)
            : base(connectionString)
        {
            if (statefulFactory == null)
            {
                throw new ArgumentNullException("StatefulFactory");
            }

            this.statefulFactory = statefulFactory;
        }

        public virtual IDbSet<Category> Categories { get; set; }

        IDbSet<TEntity> IOnlineShopDbContext.Set<TEntity>()
        {
            return base.Set<TEntity>();
        }

        public IStateful<TEntity> GetStateful<TEntity>(TEntity entity) where TEntity : class
        {
            return this.statefulFactory.GetStateful(this.Entry(entity));
        }
    }
}
