using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Api.Application.Interfaces;
using TestTask.Api.Domain;

namespace TestTask.Api.Persistence.Repository
{
    public class PaymemtRepository : IPaymentRepository
    {
        private readonly TestTaskDbContext _context;

        public PaymemtRepository(TestTaskDbContext context)
        {
            _context = context;
        }


        public void Add(Payment payment)
        {
            payment.Id = Guid.NewGuid();
            _context.Payments.Add(payment);
            _context.SaveChanges();
        }

        public void AddMany(ICollection<Payment> payment)
        {
            payment.ToList().ForEach(x => x.Id = Guid.NewGuid());
            _context.Payments.AddRange(payment);
            _context.SaveChanges();
        }

        public void Delete(Payment payment)
        {
            _context.Payments.Remove(payment);
        }

        public ICollection<Payment> GetAll()
        {
            return _context.Payments.ToList();
        }
    }
}
