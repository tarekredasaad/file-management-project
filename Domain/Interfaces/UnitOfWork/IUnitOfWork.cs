using Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
namespace Domain.Interfaces.UnitOfWork
{
    public interface IUnitOfWork :IDisposable
    {
        public IRepository<ApplicationUser> UserRepository { get; }
        public IRepository<Documents> DocumentRepository { get; }
        public IRepository<Priorities> PriorityRepository { get; }
        public IRepository<Permission> PermissionRepository { get; }
        void commit();
    }
}
