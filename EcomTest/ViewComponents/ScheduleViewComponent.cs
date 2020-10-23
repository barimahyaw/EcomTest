using EcomTest_Business.BusinessLogics.Interfaces;
using EcomTest_Business.DTO.Request;
using EcomTest_Business.DTO.Response;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EcomTest.ViewComponents
{
    [ViewComponent(Name = "Schedule")]
    public class ScheduleViewComponent : ViewComponent
    {
        private readonly ISchedule _schedule;

        public ScheduleViewComponent(ISchedule schedule)
        {
            _schedule = schedule;
        }

        public async Task<IList<ScheduleResponse>> GenerateSchechule(DisbursementRequest disbursement)
        {
            return await Task.FromResult(await _schedule.GenerateSchechule(disbursement));
        }

        public async Task<IViewComponentResult> InvokeAsync(DisbursementRequest disbursement)
        {
            return View(await GenerateSchechule(disbursement));
        }
    }
}
