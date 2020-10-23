using Ecomtest_Repository.Entities;
using System.Threading.Tasks;

namespace Ecomtest_Repository.IRepositories
{
    public interface IScheduleRepository
    {
        /// <summary>
        /// Saves disbursement too database
        /// </summary>
        /// <param name="disbursement"></param>0
        /// <returns>number of roles affected</returns>
        Task<int> SaveAsync(Schedule_Dtl schedule);
    }
}
