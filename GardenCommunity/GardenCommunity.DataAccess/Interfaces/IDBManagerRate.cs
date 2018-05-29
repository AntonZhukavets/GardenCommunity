using GardenCommunity.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GardenCommunity.DataAccess.Interfaces
{
    public interface IDBManagerRate
    {
        int AddRate(Rate rate);
        int UpdateRate(Rate rate);
        int RemoveRate(int id);
        Rate GetRate(int id);
        IEnumerable<Rate> GetRates(DateTime beginDate, DateTime endDate);
    }
}
