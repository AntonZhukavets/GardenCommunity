using System;
using System.Collections.Generic;
using GardenCommunity.DAL.Entities;

namespace GardenCommunity.DAL.Interfaces
{
    public interface IDBManagerRate
    {
        void AddRate(Rate rate);
        void UpdateRate(Rate rate);
        void RemoveRate(int id);
        Rate GetRate(int id);
        IEnumerable<Rate> GetRates(DateTime beginDate, DateTime endTime);        
    }
}
