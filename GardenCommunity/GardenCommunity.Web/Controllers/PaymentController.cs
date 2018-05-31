using GardenCommunity.Business.Interfaces;
using GardenCommunity.Business.Providers;
using GardenCommunity.Common.Entities;
using GardenCommunity.DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace GardenCommunity.Web.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IPaymentProvider paymentProvider;
        public PaymentController()
        {
            this.paymentProvider = new PaymentProvider(new DBManagerPayment());
        }

        [HttpGet]
        public IActionResult GetPayments()
        {
            var payments = paymentProvider.GetPayments();
            return View("GetPayments", payments);
        }

        [HttpGet]
        public IActionResult AddPayment()
        {
            return View("AddPayment");
        }

        [HttpPost]
        public IActionResult AddPayment(Payment payment)
        {
            if (ModelState.IsValid)
            {
                paymentProvider.AddPayment(payment);
                return RedirectToAction("GetPayments", "Payment");
            }
            return View(payment);
        }

        [HttpGet]
        public IActionResult EditPayment(int id)
        {
            var payment = paymentProvider.GetPayment(id);
            return View("EditPayment", payment);
        }

        [HttpPost]
        public IActionResult EditPayment(Payment payment)
        {
            if (ModelState.IsValid)
            {
                paymentProvider.UpdatePayment(payment);
                return RedirectToAction("GetPayments", "Payment");
            }
            return View(payment);
        }

        [HttpGet]
        public IActionResult RemovePayment(int id)
        {
            paymentProvider.RemovePayment(id);
            return RedirectToAction("GetPayments", "Payment");
        }
    }
}