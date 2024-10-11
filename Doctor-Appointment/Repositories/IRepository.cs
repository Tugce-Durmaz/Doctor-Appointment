
using Doctor_Appointment.Models;
using System.Threading.Tasks;
namespace Doctor_Appointment.Repositories
{
    public interface IRepository<T>
    {
            Task<int> CreateAsync(T entity);
            Task<T> FindByIdAsync(int id, string[] includeProperties = null);
            Task<IEnumerable<T>> GetAllAsync(string[] includeProperties = null);
            Task AddAsync(T entity);
            Task UpdateAsync(T entity);
            Task RemoveAsync(T entity);
        
    }
    }



