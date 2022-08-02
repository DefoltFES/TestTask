using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Api.Domain;

namespace TestTask.Api.Application.Interfaces
{
    public interface IAccountRepository
    {
        public void Add(Account account);

        public bool Remove(string accountNumber);

        public void AddMany(ICollection<Account> accounts);

        public Account Get(string accountNumber);
    }
}
