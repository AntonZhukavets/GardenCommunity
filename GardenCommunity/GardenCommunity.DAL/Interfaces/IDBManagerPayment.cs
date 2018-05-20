using System;
using System.Collections.Generic;
using GardenCommunity.DAL.Entities;

namespace GardenCommunity.DAL.Interfaces
{
    public interface IDBManagerPayment
    {        
        void AddPayment(Payment payment);
        void UpdatePayment(Payment payment);
        void RemovePayment(int id);
        Payment GetPayment(int id);
        IEnumerable<Payment> GetPayments();
        IEnumerable<Payment> GetPayments(DateTime beginDate, DateTime endDate);
        IEnumerable<Payment> GetPaymentsByMemberId(int id);
        IEnumerable<Payment> GetPaymentsByMemberId(int id, DateTime beginDate, DateTime endDate);
    }
}
