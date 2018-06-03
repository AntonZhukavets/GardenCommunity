using GardenCommunity.Business.Interfaces;
using GardenCommunity.Business.Providers;
using GardenCommunity.Common.Entities;
using GardenCommunity.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace GardenCommunity.Web.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IPaymentProvider paymentProvider;
        private readonly IMemberProvider memberProvider;
        private readonly IRateProvider rateProvider;
        public PaymentController(IPaymentProvider paymentProvider, IMemberProvider memberProvider, IRateProvider rateProvider)
        {
            this.paymentProvider = paymentProvider;
            this.memberProvider = memberProvider;
            this.rateProvider = rateProvider;
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
            var members = memberProvider.GetActiveMembers();
            var payers = new Dictionary<int, string>();
            payers.Add(0, string.Empty);
            foreach (var member in members)
            {
                payers.Add(member.Id, member.LastName + " " + member.FirstName + " " + member.MiddleName);
            }
            var modelPayers = new SelectList(payers, "Key", "Value");
            ViewBag.payers = modelPayers;            
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

        [HttpGet]
        public IActionResult GetLastPaymentByMemberId(int id)
        {
            var payment = paymentProvider.GetLastPaymentByMemberId(id);
            return Json(payment);
        }
    }
}