using GardenCommunity.DataAccess.Entities;
using GardenCommunity.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GardenCommunity.DataAccess
{
    public class DBManagerRate : IDBManagerRate
    {
        public int AddRate(Rate rate)
        {
            var Rate = rate ?? throw new ArgumentNullException("rate");
            using (var db = new GardenCommunityContext())
            {
                db.Rates.Add(rate);
                db.SaveChanges();
                return rate.Id;               
            }
        }

        public Rate GetRate(int id)
        {
            using (var db = new GardenCommunityContext())
            {
                var rate = db.Rates.First(x => x.Id == id);
                return rate;
            }
        }

        public IEnumerable<Rate> GetRates(DateTime beginDate, DateTime endDate)
        {
            using (var db = new GardenCommunityContext())
            {
                var rates = db.Rates
                    .Where(x => x.Date >= beginDate && x.Date <= endDate)
                    .ToList() ?? new List<Rate>();
                return rates;
            }
        }

        public int RemoveRate(int id)
        {
            using (var db = new GardenCommunityContext())
            {
                var rate = db.Rates.First(x => x.Id == id);
                db.Rates.Remove(rate);
                db.SaveChanges();
                return rate.Id;
            }
        }

        public int UpdateRate(Rate rate)
        {
            var Rate = rate ?? throw new ArgumentNullException("rate");
            using (var db = new GardenCommunityContext())
            {
                var updatableRate = db.Rates.First(x => x.Id == rate.Id);
                updatableRate.RateName = rate.RateName;
                updatableRate.RateValue = rate.RateValue;
                updatableRate.Date = rate.Date;
                updatableRate.BankCollectionPercent = rate.BankCollectionPercent;
                updatableRate.FinePercent = rate.FinePercent;
                db.SaveChanges();
                return updatableRate.Id;
            }
        }
    }
}
