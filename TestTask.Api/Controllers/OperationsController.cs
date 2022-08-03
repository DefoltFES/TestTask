using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TestTask.Api.Application.Interfaces;
using TestTask.Api.Domain;
using TestTask.Api.Persistence.Repository;

namespace TestTask.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OperationsController:ControllerBase
    {
        private readonly IOperationRepository _operationsRepository;
        public OperationsController(IOperationRepository operationRepository)
        {
            _operationsRepository = operationRepository;
        }

        [HttpPost]
        public void Add(Operation operation)
        {
            _operationsRepository.Add(operation);
        }

        [HttpPost("AddMany")]
        public void AddMany(ICollection<Operation> operations)
        {
            _operationsRepository.AddMany(operations);
        }


        [HttpGet]
        public ICollection<Operation> GetAll()
        {
            return _operationsRepository.GetAll();
        }
    }
}
