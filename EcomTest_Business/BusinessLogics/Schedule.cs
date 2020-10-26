using EcomTest_Business.BusinessLogics.Interfaces;
using EcomTest_Business.DTO.Request;
using EcomTest_Business.DTO.Response;
using Ecomtest_Repository.Entities;
using Ecomtest_Repository.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcomTest_Business.BusinessLogics
{
    public class Schedule : ISchedule
    {
        private readonly IDisbursementRepository _disbursementRepository;
        private readonly IScheduleRepository _scheduleRepository;
        /// <summary>
        /// constructor for depency injection
        /// </summary>
        public Schedule(IDisbursementRepository disbursementRepository, IScheduleRepository scheduleRepository)
        {
            _disbursementRepository = disbursementRepository;
            _scheduleRepository = scheduleRepository;
        }

        /// <summary>
        /// Compute the number of days between two dates
        /// </summary>
        /// <param name="firstDate"></param>
        /// <param name="secondDate"></param>
        /// <returns>Number of Days</returns>
        private double NumberOfDaysBetweentwoDates(DateTime firstDate, DateTime secondDate) => (firstDate - secondDate).TotalDays;

        /// <summary>
        /// Compute the first month interest
        /// </summary>
        /// <param name="disbursement"></param>
        /// <returns>interest amount</returns>
        private double InsterestCalculator(DisbursementRequest disbursement)
        => disbursement.Disb_Amount * disbursement.Int_Rate * (NumberOfDaysBetweentwoDates(disbursement.Disb_Date, disbursement.EMS_St_Date) / 365);

        /// <summary>
        /// Compute the second month interest
        /// </summary>
        /// <param name="disbursement"></param>
        /// <returns>interest amount</returns>
        private double SecondMonthInterestCalculator(DisbursementRequest disbursement, float balance)
         => balance * disbursement.Int_Rate * (NumberOfDaysBetweentwoDates(disbursement.Disb_Date, disbursement.EMS_St_Date) / 365);

        /// <summary>
        /// Compute the Principal month
        /// </summary>
        /// <param name="disbursements"></param>
        /// <returns></returns>
        private Tuple<float, float> PrincipalAmount(List<ScheduleResponse> schedules, int sNo)
        {
            // gets previous balance
            var previousBalance = schedules.FirstOrDefault(x => x.SL_NO == sNo - 1).Balance;
            // gets current schedule
            var schedule = schedules.FirstOrDefault(x => x.SL_NO == sNo - 1);
            // compute current principal amount
            var principalAmount = schedule.Total_Amount - schedule.Int_Amount;

            return Tuple.Create(principalAmount, previousBalance - principalAmount);
        }

        /// <summary>
        /// Generate schedule 
        /// </summary>
        /// <param name="disbursement"></param>
        /// <returns>List of schedules</returns>
        public async Task<IList<ScheduleResponse>> GenerateSchechule(DisbursementRequest disbursement)
        {
            var schedules = new List<ScheduleResponse>();

            if (disbursement == null) return schedules;

            var Cust_Code = await _disbursementRepository.GetCustomerCodeAsync();

            for (var i = 1; i <= disbursement.Months; i++)
            {
                var schedule = new ScheduleResponse();
                //compute SL_NO
                var sNo = Cust_Code + i;
                var currentBalance = 0F;

                schedule.Cust_Code = Cust_Code;
                schedule.EMI_Date = disbursement.EMS_St_Date;

                schedule.Total_Amount = schedules.Count == 0 ? disbursement.Disb_Amount : schedules.Sum(x => x.Total_Amount);

                if (schedules.Count > 0)
                    currentBalance = (float)PrincipalAmount(schedules, sNo).Item2;

                schedule.Balance = currentBalance == 0 ? disbursement.Disb_Amount : currentBalance;
                schedule.Prn_Amount = currentBalance == 0 ? disbursement.Disb_Amount : (float)PrincipalAmount(schedules, sNo).Item1;
                schedule.Int_Amount = i == 1 ? (float)InsterestCalculator(disbursement)
                                    : (float)SecondMonthInterestCalculator(disbursement, currentBalance);
                schedule.EMS_St_Date = DateTime.Now;
                schedule.SL_NO = sNo;


                schedules.Add(schedule);
            }

            return schedules;
        }
        /// <summary>
        /// prapare the Schedule data and pass to repository method to save to db
        /// </summary>
        /// <param name="scheduleObj"></param>
        /// <returns>the number of rows affected</returns>
        public async Task<int> Save(IList<ScheduleResponse> scheduleObj)
        {
            var i = 0;
            foreach (var obj in scheduleObj)
            {
                var schedule = new Schedule_Dtl
                {
                    Cust_Code = obj.Cust_Code,
                    EMI_Date = obj.EMI_Date,
                    Total_Amount = obj.Total_Amount,
                    Prn_Amount = obj.Prn_Amount,
                    Balance = obj.Balance,
                    Int_Amount = obj.Int_Amount,
                    EMS_St_Date = obj.EMS_St_Date,
                    SL_NO = obj.SL_NO
                };

                i += await _scheduleRepository.SaveAsync(schedule);
            }

            return i;
        }
    }
}
