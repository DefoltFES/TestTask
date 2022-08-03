using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TestTask.Api.Application.Interfaces;
using TestTask.Api.Domain;
using TestTask.Api.Persistence.Repository;

namespace TestTask.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentsController:ControllerBase
    {
        private readonly IPaymentRepository _paymentRepository;
        public PaymentsController(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        [HttpDelete]
        public void Delete(Payment payment)
        {
            _paymentRepository.Delete(payment);
        }

        [HttpPost]

        public void Add(Payment payment)
        {
            _paymentRepository.Add(payment);
        }

        [HttpPost("AddMany")]

        public void AddMany(ICollection<Payment> payments)
        {
            _paymentRepository.AddMany(payments);
        }


        [HttpGet]
        public ICollection<Payment> GetAll()
        {
            return _paymentRepository.GetAll();
        }
    }
}
