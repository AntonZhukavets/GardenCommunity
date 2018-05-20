using GardenCommunity.Business.Interfaces;
using GardenCommunity.Business.Providers;
using GardenCommunity.DAL;
using GardenCommunity.Web.Mappers;
using GardenCommunity.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        public ActionResult GetPayments()
        {
            var payments = paymentProvider.GetPayments();
            var modelPayments = new List<Payment>();
            foreach(var payment in payments)
            {
                modelPayments.Add(Mapper.FromDtoToMVCModelMap(payment));
            }
            return View("GetPayments", modelPayments);
        }

        [HttpGet]
        public ActionResult AddPayment()
        {
            return View("AddPayment");
        }

        [HttpPost]
        public ActionResult AddPayment(Payment payment)
        {
            if (ModelState.IsValid)
            {
                paymentProvider.AddPayment(Mapper.FromMVCModelToDtoMap(payment));
                return RedirectToAction("GetPayments", "Payment");
            }
            return View(payment);
        }

        [HttpGet]
        public ActionResult EditPayment(int id)
        {
            var payment = paymentProvider.GetPayment(id);
            var modelPayment = Mapper.FromDtoToMVCModelMap(payment);
            return View("EditPayment", modelPayment);
        }

        [HttpPost]
        public ActionResult EditPayment(Payment payment)
        {
            if (ModelState.IsValid)
            {
                paymentProvider.UpdatePayment(Mapper.FromMVCModelToDtoMap(payment));
                return RedirectToAction("GetPayments", "Payment");
            }
            return View(payment);
        }

        [HttpGet]
        public ActionResult RemovePayment(int id)
        {
            paymentProvider.RemovePayment(id);
            return RedirectToAction("GetPayments", "Payment");
        }
    }
}