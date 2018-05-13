using System;
using System.Collections.Generic;
using System.Linq;
using GardenCommunity.DAL.Entities;
using GardenCommunity.DAL.Interfaces;

namespace GardenCommunity.DAL
{
    public class DBManagerRate : IDBManagerRate
    {
        public void AddRate(Rate rate)
        {
            using (var db = new GardenCommunityDB())
            {
                db.Rates.Add(rate);
                db.SaveChanges();
            }
        }

        public void UpdateRate(Rate rate)
        {
            if (rate == null)
            {
                throw new ArgumentNullException("rate");
            }
            using (var db = new GardenCommunityDB())
            {
                var updatableRate = db.Rates.Where(x => x.Id == rate.Id).First();
                updatableRate.RateName = rate.RateName;
                updatableRate.RateValue = rate.RateValue;
                updatableRate.BankCollectionPercent = rate.BankCollectionPercent;
                updatableRate.Date = rate.Date;
                updatableRate.Payments = rate.Payments;
                db.SaveChanges();
            }
        }

        public void RemoveRate(int id)
        {
            using (var db = new GardenCommunityDB())
            {
                var rate = db.Rates.Where(x => x.Id == id).First();
                db.Rates.Remove(rate);
                db.SaveChanges();
            }
        }

        public IEnumerable<Rate> GetRates(DateTime beginDate, DateTime endTime)
        {
            using (var db = new GardenCommunityDB())
            {
                var rates = db.Rates.Where(x => x.Date >= beginDate && x.Date <= endTime).ToList();
                return rates;
            }
        }
    }
}
