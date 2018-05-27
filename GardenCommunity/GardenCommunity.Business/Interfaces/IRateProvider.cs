using GardenCommunity.Common.Entities;
using System;
using System.Collections.Generic;

namespace GardenCommunity.Business.Interfaces
{
    public interface IRateProvider
    {
        int AddRate(Rate rate);
        int UpdateRate(Rate rate);
        int RemoveRate(int id);
        Rate GetRate(int id);
        IEnumerable<Rate> GetRates(DateTime beginDate, DateTime endDate);
    }
}
