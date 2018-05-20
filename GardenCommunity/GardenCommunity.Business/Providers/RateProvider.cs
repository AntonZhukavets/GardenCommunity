using System;
using System.Collections.Generic;
using GardenCommunity.Business.DTO;
using GardenCommunity.Business.Interfaces;
using GardenCommunity.Business.Mappers;
using GardenCommunity.DAL.Interfaces;

namespace GardenCommunity.Business.Providers
{
    public class RateProvider : IRateProvider
    {
        private readonly IDBManagerRate dBManagerRate;
        public RateProvider(IDBManagerRate dBManagerRate)
        {
            this.dBManagerRate = dBManagerRate;
        }

        public void AddRate(Rate rate)
        {
            if(rate==null)
            {
                throw new ArgumentNullException("rate");
            }
            dBManagerRate.AddRate(Mapper.FromDtoToDalMap(rate));
        }

        public Rate GetRate(int id)
        {
            return Mapper.FromDalToDtoMap(dBManagerRate.GetRate(id));
        }

        public IEnumerable<Rate> GetRates(DateTime beginDate, DateTime endDate)
        {
            var dALRates = dBManagerRate.GetRates(beginDate, endDate);
            if(dALRates!=null)
            {
                var dTORates = new List<Rate>();
                foreach(var dALRate in dALRates)
                {
                    dTORates.Add(Mapper.FromDalToDtoMap(dALRate));
                }
                return dTORates;
            }
            return null;
        }       

        public void RemoveRate(int id)
        {
            dBManagerRate.RemoveRate(id);
        }

        public void UpdateRate(Rate rate)
        {
            if (rate == null)
            {
                throw new ArgumentNullException("rate");
            }
            dBManagerRate.UpdateRate(Mapper.FromDtoToDalMap(rate));
        }
    }
}
