using GardenCommunity.Business.Interfaces;
using GardenCommunity.Common.Entities;
using GardenCommunity.Common.Mappers;
using GardenCommunity.DataAccess.Interfaces;
using System;
using System.Collections.Generic;

namespace GardenCommunity.Business.Providers
{
    public class PaymentProvider : IPaymentProvider
    {
        private readonly IDBManagerPayment dBManagerPayment;

        public PaymentProvider(IDBManagerPayment dBManagerPayment)
        {
            this.dBManagerPayment = dBManagerPayment;
        }

        public int AddPayment(Payment payment)
        {
            var Payment = payment ?? throw new ArgumentNullException("payment");
            return dBManagerPayment.AddPayment(Mapper.FromBusinessToDataAccessMap(payment));           
        }

        public double CalculetePayment(double lastIndication, double currentIndication, double rateValue, double finePercent, double bankCollectionPercent, double loosesPercent)
        {
            var result = (currentIndication*(1 + loosesPercent/100.0) - lastIndication) * rateValue * (1 + finePercent/100.0 + bankCollectionPercent/100.0);
            return result;
        }

        public Payment GetLastPaymentByMemberId(int id)
        {
            var payment = dBManagerPayment.GetLastPaymentByMemberId(id);
            return Mapper.FromDataAccessToBusinessMap(payment);
        }

        public Payment GetPayment(int id)
        {
            var payment = dBManagerPayment.GetPayment(id);
            return Mapper.FromDataAccessToBusinessMap(payment);
        }

        public IEnumerable<Payment> GetPayments()
        {
            var payments = new List<Payment>();
            var dALPayments = dBManagerPayment.GetPayments();
            foreach (var dALPayment in dALPayments)
            {
                payments.Add(Mapper.FromDataAccessToBusinessMap(dALPayment));
            }
            return payments;
        }

        public IEnumerable<Payment> GetPayments(DateTime beginDate, DateTime endDate)
        {
            var payments = new List<Payment>();
            var dALPayments = dBManagerPayment.GetPayments(beginDate, endDate);
            foreach (var dALPayment in dALPayments)
            {
                payments.Add(Mapper.FromDataAccessToBusinessMap(dALPayment));
            }
            return payments;
        }

        public IEnumerable<Payment> GetPaymentsByMemberId(int id)
        {
            var payments = new List<Payment>();
            var dALPayments = dBManagerPayment.GetPaymentsByMemberId(id);
            foreach (var dALPayment in dALPayments)
            {
                payments.Add(Mapper.FromDataAccessToBusinessMap(dALPayment));
            }
            return payments;
        }

        public IEnumerable<Payment> GetPaymentsByMemberId(int id, DateTime beginDate, DateTime endDate)
        {
            var payments = new List<Payment>();
            var dALPayments = dBManagerPayment.GetPaymentsByMemberId(id, beginDate, endDate);
            foreach (var dALPayment in dALPayments)
            {
                payments.Add(Mapper.FromDataAccessToBusinessMap(dALPayment));
            }
            return payments;
        }

        public int RemovePayment(int id)
        {
            return dBManagerPayment.RemovePayment(id);
        }

        public int UpdatePayment(Payment payment)
        {
            var Payment = payment ?? throw new ArgumentNullException("payment");
            return dBManagerPayment.UpdatePayment(Mapper.FromBusinessToDataAccessMap(payment));
        }
    }
}
