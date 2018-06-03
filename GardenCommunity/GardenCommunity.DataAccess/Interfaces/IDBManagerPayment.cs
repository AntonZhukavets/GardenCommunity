using GardenCommunity.DataAccess.Entities;
using System;
using System.Collections.Generic;

namespace GardenCommunity.DataAccess.Interfaces
{
    public interface IDBManagerPayment
    {
        int AddPayment(Payment payment);
        int UpdatePayment(Payment payment);
        int RemovePayment(int id);
        Payment GetPayment(int id);
        Payment GetLastPaymentByMemberId(int id);
        IEnumerable<Payment> GetPayments();
        IEnumerable<Payment> GetPayments(DateTime beginDate, DateTime endDate);
        IEnumerable<Payment> GetPaymentsByMemberId(int id);
        IEnumerable<Payment> GetPaymentsByMemberId(int id, DateTime beginDate, DateTime endDate);
    }
}
