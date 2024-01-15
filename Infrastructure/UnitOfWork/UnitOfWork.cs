using Domain;
using Domain.Interfaces.Repository;
using Infrastructure.Repository;
using Domain.Interfaces.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public readonly Context Context;
        public IRepository<ApplicationUser> UserRepository { get;private set; }

        public IRepository<Documents> DocumentRepository { get; private set; }
        public IRepository<Priorities> PriorityRepository { get; private set; }




        //public IRepository<User> Users => throw new NotImplementedException();

        public UnitOfWork(Context context) 
        {
            Context = context;
            UserRepository = new Repository<ApplicationUser>(Context);
            DocumentRepository = new Repository<Documents>(Context);
            PriorityRepository = new Repository<Priorities>(Context);

        }
        public void commit() 
        {
            try
            {
                Context.SaveChanges();
                //Context.Database.CurrentTransaction.Commit();
            }
            catch
            {
                Context.Database.CurrentTransaction.Rollback();
            }
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
