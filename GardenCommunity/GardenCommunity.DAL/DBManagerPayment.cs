using System;
using System.Collections.Generic;
using System.Linq;
using GardenCommunity.DAL.Entities;
using GardenCommunity.DAL.Interfaces;

namespace GardenCommunity.DAL
{
    public class DBManagerPayment : IDBManagerPayment
    {
        public IEnumerable<Payment> GetPayments()
        {
            using (var db = new GardenCommunityDB())
            {
                return db.Payments.Include("Member").Include("Rate").ToList();
            }

        }

        public IEnumerable<Payment> GetPayments(DateTime beginDate, DateTime endDate)
        {
            using (var db = new GardenCommunityDB())
            {
                return db.Payments
                    .Include("Member")
                    .Include("Rate")
                    .Where(x => x.DateOfPayment >= beginDate && x.DateOfPayment <= endDate)
                    .ToList();
            }

        }

        public IEnumerable<Payment> GetPaymentsByMemberId(int id)
        {
            using (var db = new GardenCommunityDB())
            {
                var payments = db.Payments.Include("Rate").Where(x => x.MemberId == id).ToList();
                return payments;
            }
        }

        public IEnumerable<Payment> GetPaymentsByMemberId(int id, DateTime beginDate, DateTime endDate)
        {
            var payments = GetPaymentsByMemberId(id).Where(x => x.DateOfPayment >= beginDate && x.DateOfPayment <= endDate).ToList();
            return payments;
        }
        public void AddPayment(Payment payment)
        {
            using (var db = new GardenCommunityDB())
            {
                db.Payments.Add(payment);
                db.SaveChanges();
            }
        }

        public void UpdatePayment(Payment payment)
        {
            using (var db = new GardenCommunityDB())
            {
                var updatabePayment = db.Payments.First(x => x.Id == payment.Id);
                updatabePayment.DateOfPayment = payment.DateOfPayment;
                updatabePayment.Indication = payment.Indication;
                updatabePayment.MemberId = payment.MemberId;
                updatabePayment.PaidFor = payment.PaidFor;
                updatabePayment.ToPay = payment.ToPay;
                updatabePayment.RateId = payment.RateId;
                db.SaveChanges();
            }
        }

        public void RemovePayment(int id)
        {
            using (var db = new GardenCommunityDB())
            {
                var deletablePayment = db.Payments.Where(x => x.Id == id).First();
                db.Payments.Remove(deletablePayment);
                db.SaveChanges();
            }
        }

        public Payment GetPayment(int id)
        {
            using (var db = new GardenCommunityDB())
            {
                return db.Payments.First(x => x.Id == id);
            }
        }
    }
}
