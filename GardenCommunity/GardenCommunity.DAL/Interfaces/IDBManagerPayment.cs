using System;
using System.Collections.Generic;
using GardenCommunity.DAL.Entities;

namespace GardenCommunity.DAL.Interfaces
{
    public interface IDBManagerPayment
    {
        IEnumerable<Payment> GetPayments();
        IEnumerable<Payment> GetPaymentsByMemberId(int id);
        IEnumerable<Payment> GetPaymentsByMemberId(int id, DateTime beginDate, DateTime endDate);
        void AddPayment(Payment payment);
        void UpdatePayment(Payment payment);
        void RemovePayment(int id);
    }
}
