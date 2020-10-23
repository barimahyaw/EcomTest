using EcomTest_Business.DTO.Request;
using System.Threading.Tasks;

namespace EcomTest_Business.BusinessLogics.Interfaces
{
    public interface IDisbursement
    {
        /// <summary>
        /// passes Disbursement details to repository to save 
        /// </summary>
        /// <param name="disbursement"></param>
        /// <returns>number of roles affected</returns>
        Task<int> SaveDistursement(DisbursementRequest disbursement);
    }
}
