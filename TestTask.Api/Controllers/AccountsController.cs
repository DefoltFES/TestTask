using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TestTask.Api.Application.Interfaces;
using TestTask.Api.Domain;

namespace TestTask.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;
        public AccountsController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        [HttpPost]
        public void Add(Account account)
        {
           _accountRepository.Add(account);
        }

        [HttpPost("AddMany")]
        public void AddMany(ICollection<Account> accounts)
        {
            _accountRepository.AddMany(accounts);
        }


        [HttpGet]
        public ActionResult<Account> Get(string numberAccount)
        {
            return _accountRepository.Get(numberAccount);
        }
    }
}
