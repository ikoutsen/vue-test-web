
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VueTestWebAPI.Models;

namespace VueTestWebAPI.DAL {
    public interface IUnitOfWork {
        public GenericRepository<Employee> Employees { get; }
        public GenericRepository<Company> Companies { get; }
        public GenericRepository<Position> Positions { get; }
        public Task SaveAsync();
    }
}
