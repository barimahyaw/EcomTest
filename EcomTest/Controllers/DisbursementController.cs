using EcomTest_Business.BusinessLogics.Interfaces;
using EcomTest_Business.DTO.Request;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EcomTest.Controllers
{
    public class DisbursementController : Controller
    {
        private readonly IDisbursement _business;
        public DisbursementController(IDisbursement disbursement)
        {
            _business = disbursement;
        }
        public IActionResult EquatedMonthlyInstallment()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EquatedMonthlyInstallment(DisbursementRequest disbursement)
        {
            if (!ModelState.IsValid) return View();

            await _business.SaveDistursement(disbursement);

            return View(disbursement);
        }
    }
}
