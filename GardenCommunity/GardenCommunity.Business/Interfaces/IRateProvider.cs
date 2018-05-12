using System;
using System.Collections.Generic;
using GardenCommunity.Business.DTO;

namespace GardenCommunity.Business.Interfaces
{
    public interface IRateProvider
    {
        void AddRate(Rate rate);
        void UpdateRate(Rate rate);
        void RemoveRate(int id);
        IEnumerable<Rate> GetRates(DateTime beginDate, DateTime endDate);
        IEnumerable<Rate> GetRates(DateTime date);
    }
}
