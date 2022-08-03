using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Api.Application.Interfaces;
using TestTask.Api.Domain;

namespace TestTask.Api.Persistence.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly TestTaskDbContext _context;

        public AccountRepository(TestTaskDbContext context)
        {
            _context = context;
        }   

        public void Add(Account account)
        {
            account.Id = Guid.NewGuid();
            _context    .Accounts.Add(account);
            _context.SaveChanges();
        }

        public void AddMany(ICollection<Account> accounts)
        {
            accounts.ToList().ForEach(x=>x.Id=Guid.NewGuid());
            _context.Accounts.AddRange(accounts);
            _context.SaveChanges();
        }

        public Account Get(string accountNumber)
        {
          return _context.Accounts.Where(x => x.NumberAccount == accountNumber).FirstOrDefault();
        }

        public bool Remove(string accountNumber)
        {
            var account = _context.Accounts.Where(x => x.NumberAccount == accountNumber).FirstOrDefault();
            if(account != null)
            {
                _context.Accounts.Remove(account);
                return true;
            }
            else
            {
                return false;
            }
           
        }
    }
}
