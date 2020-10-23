using EcomTest_Business.DTO.Request;
using EcomTest_Business.DTO.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EcomTest_Business.BusinessLogics.Interfaces
{
    public interface ISchedule
    {
        /// <summary>
        /// Generate schedule 
        /// </summary>
        /// <param name="disbursement"></param>
        /// <returns>List of schedules</returns>
        Task<IList<ScheduleResponse>> GenerateSchechule(DisbursementRequest disbursement);
        /// <summary>
        /// prapare the Schedule data and pass to repository method to save to db
        /// </summary>
        /// <param name="scheduleObj"></param>
        /// <returns>the number of rows affected</returns>
        Task<int> Save(IList<ScheduleResponse> scheduleObj);
    }
}
