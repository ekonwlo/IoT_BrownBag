using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.IoT.Core
{
    using DbContexts;

    public class ContextFactory
    {



        public static IDbContext Create(string url)
        {

            return new IoTMongoDbContext(url);            
        }

    }
}
