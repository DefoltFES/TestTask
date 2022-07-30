using System;

namespace TestTask.Api.Models
{
    public class Favorite
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Payment Payment { get; set; }
    }
}
