using System;
using System.Collections.Generic;
using GardenCommunity.Business.DTO;

namespace GardenCommunity.Business.Interfaces
{
    public interface IPaymentProvider
    {
        void AddPayment(Payment payment);
        void UpdatePayment(Payment payment);
        void RemovePayment(int id);
        IEnumerable<Payment> GetPaymentsByMemberId(int id);
        IEnumerable<Payment> GetPaymentsByMemberId(int id, DateTime beginDate, DateTime endDate);
        IEnumerable<Payment> GetPayments();
        IEnumerable<Payment> GetPayments(DateTime beginDate, DateTime endDate);
    }
}
