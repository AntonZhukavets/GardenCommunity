using System;
using System.Collections.Generic;
using GardenCommunity.Business.DTO;
using GardenCommunity.Business.Interfaces;
using GardenCommunity.Business.Mappers;
using GardenCommunity.DAL.Interfaces;

namespace GardenCommunity.Business.Providers
{
    public class PaymentProvider : IPaymentProvider
    {
        private readonly IDBManagerPayment dBManagerPayment;
        public PaymentProvider(IDBManagerPayment dBManagerPayment)
        {
            this.dBManagerPayment = dBManagerPayment;
        }

        public void AddPayment(Payment payment)
        {
            if(payment==null)
            {
                throw new ArgumentNullException("payment");
            }
            dBManagerPayment.AddPayment(Mapper.FromDtoToDalMap(payment));            
        }

        public Payment GetPayment(int id)
        {
            var payment = dBManagerPayment.GetPayment(id);
            return Mapper.FromDalToDtoMap(payment);
        }

        public IEnumerable<Payment> GetPayments()
        {            
            var dALPayments = dBManagerPayment.GetPayments();
            if(dALPayments!=null)
            {
                var dTOPayments = new List<Payment>();
                foreach (var dALPayment in dALPayments)
                {
                    dTOPayments.Add(Mapper.FromDalToDtoMap(dALPayment));
                }
                return dTOPayments;
            }
            return null;            
        }

        public IEnumerable<Payment> GetPayments(DateTime beginDate, DateTime endDate)
        {
            if(beginDate == default(DateTime))
            {
                throw new ArgumentNullException("beginDate");
            }
            if (endDate == default(DateTime))
            {
                throw new ArgumentNullException("endDate");
            }
            var dALPayments = dBManagerPayment.GetPayments(beginDate, endDate);
            if (dALPayments != null)
            {
                var dTOPayments = new List<Payment>();
                foreach (var dALPayment in dALPayments)
                {
                    dTOPayments.Add(Mapper.FromDalToDtoMap(dALPayment));
                }
                return dTOPayments;
            }
            return null;            
        }

        public IEnumerable<Payment> GetPaymentsByMemberId(int id)
        {
            var dALPayments = dBManagerPayment.GetPaymentsByMemberId(id);
            if (dALPayments != null)
            {
                var dTOPayments = new List<Payment>();
                foreach (var dALPayment in dALPayments)
                {
                    dTOPayments.Add(Mapper.FromDalToDtoMap(dALPayment));
                }
                return dTOPayments;
            }
            return null;
        }

        public IEnumerable<Payment> GetPaymentsByMemberId(int id, DateTime beginDate, DateTime endDate)
        {
            var dALPayments = dBManagerPayment.GetPaymentsByMemberId(id, beginDate, endDate);
            if (dALPayments != null)
            {
                var dTOPayments = new List<Payment>();
                foreach (var dALPayment in dALPayments)
                {
                    dTOPayments.Add(Mapper.FromDalToDtoMap(dALPayment));
                }
                return dTOPayments;
            }
            return null;
        }

        public void RemovePayment(int id)
        {
            dBManagerPayment.RemovePayment(id);
        }

        public void UpdatePayment(Payment payment)
        {
            if(payment == null)
            {
                throw new ArgumentNullException("payment");
            }
            dBManagerPayment.UpdatePayment(Mapper.FromDtoToDalMap(payment));
        }
    }
}
