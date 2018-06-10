using GardenCommunity.Business.Interfaces;
using GardenCommunity.Business.Providers;
using GardenCommunity.Common.Entities;
using GardenCommunity.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

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
            var members = memberProvider.GetActiveMembers();
            var payers = new Dictionary<int, string>();
            payers.Add(0, string.Empty);
            foreach (var member in members)
            {
                payers.Add(member.Id, member.LastName + " " + member.FirstName + " " + member.MiddleName);
            }
            var modelPayers = new SelectList(payers, "Key", "Value", payment.MemberId);
            ViewBag.payers = modelPayers;
            if (payment.MemberId!=0 && payment.ToPay!=0 && payment.Indication.CurrentIndication >= payment.Indication.LastIndication && payment.Indication.CurrentIndication!=0 && payment.RateId!=0)
            {
                paymentProvider.AddPayment(payment);
                return RedirectToAction("GetPayments", "Payment");
            }
            payment.DateOfPayment = DateTime.Now;
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

        [HttpGet]
        public double CalculatePayment()
        {
            double result = 0;             
            var lastIndication = Convert.ToDouble(Request.Query.FirstOrDefault(x => x.Key == "lastIndication").Value);
            var currentIndication = Convert.ToDouble(Request.Query.FirstOrDefault(x => x.Key == "currentIndication").Value);
            var rateValue = Convert.ToDouble(Request.Query.FirstOrDefault(x => x.Key == "rateValue").Value);
            var bankCollectionPercent = Convert.ToDouble(Request.Query.FirstOrDefault(x => x.Key == "bankCollection").Value);
            var finePercent = Convert.ToDouble(Request.Query.FirstOrDefault(x => x.Key == "finePercent").Value);
            var loosesPercent = Convert.ToDouble(Request.Query.FirstOrDefault(x => x.Key == "loosesPercent").Value);
            result = paymentProvider.CalculetePayment(lastIndication, currentIndication, rateValue, finePercent, bankCollectionPercent, loosesPercent);
            return Math.Round(result, 2);
        }
    }
}