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
    }
}