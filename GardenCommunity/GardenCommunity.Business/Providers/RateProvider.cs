using GardenCommunity.Business.Interfaces;
using GardenCommunity.Common.Entities;
using GardenCommunity.Common.Mappers;
using GardenCommunity.DataAccess.Interfaces;
using System;
using System.Collections.Generic;

namespace GardenCommunity.Business.Providers
{
    public class RateProvider : IRateProvider
    {
        private readonly IDBManagerRate dBManagerRate;

        public RateProvider(IDBManagerRate dBManagerRate)
        {
            this.dBManagerRate = dBManagerRate;
        }

        public int AddRate(Rate rate)
        {
            var Rate = rate ?? throw new ArgumentNullException("rate");
            return dBManagerRate.AddRate(Mapper.FromBusinessToDataAccessMap(rate));
        }

        public Rate GetRate(int id)
        {
            var rate = dBManagerRate.GetRate(id);
            return Mapper.FromDataAccessToBusinessMap(rate);
        }

        public IEnumerable<Rate> GetRates(DateTime beginDate, DateTime endDate)
        {
            var rates = new List<Rate>();
            var dALRates = dBManagerRate.GetRates(beginDate, endDate);
            foreach(var dALRate in dALRates)
            {
                rates.Add(Mapper.FromDataAccessToBusinessMap(dALRate));
            }
            return rates;
        }

        public int RemoveRate(int id)
        {
            return dBManagerRate.RemoveRate(id);
        }

        public int UpdateRate(Rate rate)
        {
            var Rate = rate ?? throw new ArgumentNullException("rate");
            return dBManagerRate.UpdateRate(Mapper.FromBusinessToDataAccessMap(rate));
        }
    }
}
