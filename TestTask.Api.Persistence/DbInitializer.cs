using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Api.Persistence
{
    internal class DbInitializer
    {
        public static void Initialize(TestTaskDbContext context)
        {
            context.Database.EnsureCreated();
        }

    }
}
