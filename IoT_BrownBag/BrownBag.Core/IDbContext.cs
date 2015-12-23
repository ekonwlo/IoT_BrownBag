using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.IoT.Core
{
    using DataModels;

    public interface IDbContext
    {
        string Database { get; set; }
        int Insert<T>(T model);
        Task <int> InsertAsync<T>(T model);

        T Find<T>();
        Task<T> FindAsync<T>();  

        IEnumerable<T> FindAll<T>();
        Task<IEnumerable<T>> FindAllAsync<T>();    

    }
}
