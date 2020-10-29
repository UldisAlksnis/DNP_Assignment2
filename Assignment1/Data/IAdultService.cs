using System.Collections.Generic;
using System.Threading.Tasks;
using Assignment1.Models;

namespace Assignment1.Data
{
    public interface IAdultService
    {
        Task<IList<Adult>> GetAdults();
        Task AddAdultAsync(Adult adult);
        Task EditAdultAsync(Adult adult);
        Task<Adult> GetById(int Id);
        Task UpdateAdultAsync(Adult adultToUpdate);
        Task RemoveAdultAsync(int id);
    }
}