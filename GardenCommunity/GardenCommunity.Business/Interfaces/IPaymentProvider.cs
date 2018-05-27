using GardenCommunity.Common.Entities;
using System;
using System.Collections.Generic;

namespace GardenCommunity.Business.Interfaces
{
    public interface IPaymentProvider
    {
        int AddPayment(Payment payment);
        int UpdatePayment(Payment payment);
        int RemovePayment(int id);
        Payment GetPayment(int id);
        IEnumerable<Payment> GetPaymentsByMemberId(int id);
        IEnumerable<Payment> GetPaymentsByMemberId(int id, DateTime beginDate, DateTime endDate);
        IEnumerable<Payment> GetPayments();
        IEnumerable<Payment> GetPayments(DateTime beginDate, DateTime endDate);
    }
}
