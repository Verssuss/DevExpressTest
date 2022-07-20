using System.Collections.Generic;
using System.Threading.Tasks;

namespace WpfApp3.Repositories
{
    public interface IDataStore<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<bool> Fetch(IEnumerable<T> items);
    }
}