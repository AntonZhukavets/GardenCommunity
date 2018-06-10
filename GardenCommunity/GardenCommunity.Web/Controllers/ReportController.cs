using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GardenCommunity.Business.Interfaces;
using GardenCommunity.Common.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;

namespace GardenCommunity.Web.Controllers
{
    public class ReportController : Controller
    {
        private readonly IPaymentProvider paymentProvider;
        private readonly IMemberProvider memberProvider;
        public ReportController(IPaymentProvider paymentProvider, IMemberProvider memberProvider)
        {
            this.paymentProvider = paymentProvider;
            this.memberProvider = memberProvider;
        }
        [HttpGet]
        public IActionResult GetReport()
        {
            var endDate = DateTime.Now;
            var beginDate = new DateTime(endDate.Year, endDate.Month, 1);
            var payments = paymentProvider.GetPayments(beginDate, endDate);
            var gardenCommunityPayments = payments.Where(x => x.MemberId == 1).ToList() ?? new List<Payment>();
            var gardenCommunityConsumption = gardenCommunityPayments.Last().Indication.CurrentIndication - gardenCommunityPayments.First().Indication.LastIndication;
            var garedenCommunityTotalPay = gardenCommunityPayments.Sum(x => x.ToPay);
            var membersPayments = payments.Except(payments.Where(x => x.MemberId == 1)).ToList() ?? new List<Payment>();
            var membersConsumption = membersPayments.Sum(x => x.Indication.CurrentIndication) - membersPayments.Sum(x => x.Indication.LastIndication);
            var membersTotalPay = membersPayments.Sum(x => x.ToPay);
            var consumptionDebt = gardenCommunityConsumption - membersConsumption;
            var moneyDept = garedenCommunityTotalPay - membersTotalPay;
            ViewBag.garedenCommunityTotalPay = garedenCommunityTotalPay;
            ViewBag.membersTotalPay = membersTotalPay;
            ViewBag.membersConsumption = membersConsumption;
            ViewBag.consumptionDebt = consumptionDebt;
            ViewBag.moneyDept = moneyDept;
            return View(payments);
        }

        [HttpGet]
        public IActionResult GetReportByDate(DateTime date)
        {
            int days = DateTime.DaysInMonth(date.Year, date.Month);
            var beginDate = new DateTime(date.Year, date.Month, 1);
            var endDate = new DateTime(date.Year, date.Month, days);
            var payments = paymentProvider.GetPayments(beginDate, endDate);            
            return PartialView(payments);
        }      
        
    }
}