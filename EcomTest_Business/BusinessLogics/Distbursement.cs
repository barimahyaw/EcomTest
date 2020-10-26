using EcomTest_Business.BusinessLogics.Interfaces;
using EcomTest_Business.DTO.Request;
using Ecomtest_Repository.Entities;
using Ecomtest_Repository.IRepositories;
using System.Threading.Tasks;

namespace EcomTest_Business
{
    public class Disbursement : IDisbursement
    {
        private readonly IDisbursementRepository _disbursementRepository;
        /// <summary>
        /// Constructor to inject DisbursementRepository
        /// </summary>
        public Disbursement(IDisbursementRepository disbursementRepository)
        {
            _disbursementRepository = disbursementRepository;
        }
        /// <summary>
        /// passes Disbursement details to repository to save 
        /// </summary>
        /// <param name="disbursement"></param>
        /// <returns>number of roles affected</returns>
        public async Task<int> SaveDistursement(DisbursementRequest disbursement)
        {
            var code = await _disbursementRepository.GetCustomerCodeAsync();
            // compute/generate Customer Code
            var cus_Code = code >= 1 ? code + 1 : 1;

            var entity = new Disbursement_Dtl
            {
                Cust_Code = cus_Code,
                Cust_Name = disbursement.Cust_Name,
                Disb_Date = disbursement.Disb_Date,
                Disb_Amount = disbursement.Disb_Amount,
                Int_Rate = disbursement.Int_Rate,
                Months = disbursement.Months,
                EMS_St_Date = disbursement.EMS_St_Date
            };

            return await _disbursementRepository.AddDisbursementAsync(entity);
        }
        /// <summary>
        /// Gets the last Customer Code from database
        /// </summary>
        /// <returns>Custoer Code as integer value</returns>
        public async Task<int> GetCustomerCode()
        {
            return await _disbursementRepository.GetCustomerCodeAsync();
        }
    }
}
