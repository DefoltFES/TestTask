using System;
using System.Collections.Generic;

namespace TestTask.Api.Domain
{
    public class Payment
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Image { get; set; }
    }
}