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

        public ICollection<Operation> GetAll(Card account);

        public void Delete(Operation operation);

        public void Remove(Operation operation);

    }
}
