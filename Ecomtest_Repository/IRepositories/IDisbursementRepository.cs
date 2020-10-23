using Ecomtest_Repository.Entities;
using System.Threading.Tasks;

namespace Ecomtest_Repository.IRepositories
{
    public interface IDisbursementRepository
    {
        /// <summary>
        /// Saves disbursement too database
        /// </summary>
        /// <param name="disbursement"></param>
        /// <returns>number of roles affected</returns>
        Task<int> AddDisbursementAsync(Disbursement_Dtl disbursement);
        /// <summary>
        /// Gets the last Customer Code from database
        /// </summary>
        /// <returns>Customer Code as integer value</returns>
        Task<int> GetCustomerCodeAsync();
    }
}
