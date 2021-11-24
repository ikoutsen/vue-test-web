
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VueTestWebAPI.Models;

namespace VueTestWebAPI.DAL {
    public class UnitOfWork : IUnitOfWork, IDisposable {
        private ContactsContext context;
        private GenericRepository<Employee> employeeRepository;
        private GenericRepository<Company> companyRepository;
        private GenericRepository<Position> positionRepository;

        public UnitOfWork(ContactsContext context) {
            this.context = context;
        }
        public GenericRepository<Employee> Employees {
            get {
                if (this.employeeRepository == null)
                    this.employeeRepository = new GenericRepository<Employee>(context);
                return employeeRepository;
            }
        }

        public GenericRepository<Company> Companies {
            get {
                if (this.companyRepository == null)
                    this.companyRepository = new GenericRepository<Company>(context);
                return companyRepository;
            }
        }

        public GenericRepository<Position> Positions {
            get {
                if (this.positionRepository == null)
                    this.positionRepository = new GenericRepository<Position>(context);
                return positionRepository;
            }
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing) {
            if (!disposed && disposing)
                context.Dispose();
            disposed = true;
        }

        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public async Task SaveAsync() {
            await context.SaveChangesAsync();
        }
    }
}
