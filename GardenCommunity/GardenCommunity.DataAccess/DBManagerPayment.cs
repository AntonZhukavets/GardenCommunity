using GardenCommunity.DataAccess.Entities;
using GardenCommunity.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GardenCommunity.DataAccess
{
    public class DBManagerPayment : IDBManagerPayment
    {
        public int AddPayment(Payment payment)
        {
            var Payment = payment ?? throw new ArgumentNullException("payment");
            using (var db = new GardenCommunityContext())
            {
                db.Payments.Add(payment);
                db.SaveChanges();
                return payment.Id;
            }            
        }

        public Payment GetLastPaymentByMemberId(int id)
        {
            using (var db = new GardenCommunityContext())
            {
                var payment = db.Payments
                    .Include(x => x.Member)
                    .Include(x => x.Rate)
                    .Include(x => x.Indication)
                    .Where(x => x.MemberId == id)
                    .LastOrDefault() ?? new Payment();
                return payment;
            }
        }

        public Payment GetPayment(int id)
        {
            using (var db = new GardenCommunityContext())
            {
                var payment = db.Payments
                    .Include(x => x.Member)
                    .Include(x => x.Rate)
                    .First(x => x.Id == id);
                return payment;
            }
        }

        public IEnumerable<Payment> GetPayments()
        {
            using (var db = new GardenCommunityContext())
            {
                var payments = db.Payments
                    .Include(x => x.Member)
                    .Include(x => x.Rate).ToList() ?? new List<Payment>();
                return payments;
            }
        }

        public IEnumerable<Payment> GetPayments(DateTime beginDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Payment> GetPaymentsByMemberId(int id)
        {
            using (var db = new GardenCommunityContext())
            {
                var payments = db.Payments
                    .Include(x => x.Member)
                    .Include(x => x.Rate)
                    .Include(x=>x.Indication)
                    .Where(x => x.MemberId == id)
                    .ToList() ?? new List<Payment>();
                return payments;
            }
        }

        public IEnumerable<Payment> GetPaymentsByMemberId(int id, DateTime beginDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public int RemovePayment(int id)
        {
            using (var db = new GardenCommunityContext())
            {
                var payment = db.Payments.First(x => x.Id == id);
                db.Payments.Remove(payment);
                return payment.Id;
            }
        }

        public int UpdatePayment(Payment payment)
        {
            var Payment = payment ?? throw new ArgumentNullException("payment");
            using (var db = new GardenCommunityContext())
            {
                var updatablePayment = db.Payments.First(x => x.Id == payment.Id);
                updatablePayment.DateOfPayment = payment.DateOfPayment;
                updatablePayment.RateId = payment.RateId;
                updatablePayment.MemberId = payment.MemberId;
                updatablePayment.PaidFor = payment.PaidFor;
                updatablePayment.ToPay = payment.ToPay;
                updatablePayment.Indication = payment.Indication;
                db.SaveChanges();
            }
            return payment.Id;
        }
    }
}
