using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Api.Domain;

namespace TestTask.Api.Application.Interfaces
{
    public interface IOperationRepository
    {
        public void Add(Operation operation);

        public void AddMany(ICollection<Operation> operations);

        public ICollection<Operation> GetAll();

        


    }
}
