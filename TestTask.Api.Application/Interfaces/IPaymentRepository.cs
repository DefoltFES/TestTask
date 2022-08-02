using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Api.Domain;

namespace TestTask.Api.Application.Interfaces
{
    public interface IPaymentRepository
    {
        public void Add(Payment payment);

        public void Delete(Payment payment);

        public void Get(string namePayment);
    }
}
