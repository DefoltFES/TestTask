using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Api.Application.Interfaces;
using TestTask.Api.Domain;

namespace TestTask.Api.Persistence.Repository
{
    public class OperationRepository:IOperationRepository
    {
        private readonly TestTaskDbContext _context;

        public OperationRepository(TestTaskDbContext context)
        {
            _context = context;
        }

        public void Add(Operation operation)
        {
            operation.Id = Guid.NewGuid();
            _context.Operations.Add(operation);
            _context.SaveChanges();
        }

        public void AddMany(ICollection<Operation> operations)
        {
            operations.ToList().ForEach(x => x.Id = Guid.NewGuid());
            _context.Operations.AddRange(operations);
            _context.SaveChanges();
        }

          
        public ICollection<Operation> GetAll()
        {
            return _context.Operations.ToList();
        }

        
    }
}
