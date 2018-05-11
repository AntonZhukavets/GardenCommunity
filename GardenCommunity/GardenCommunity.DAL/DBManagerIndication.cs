using System;
using System.Collections.Generic;
using System.Linq;
using GardenCommunity.DAL.Entities;
using GardenCommunity.DAL.Interfaces;

namespace GardenCommunity.DAL
{
    public class DBManagerIndication : IDBManagerIndication
    {
        public IEnumerable<Indication> GetIndicationsByMemberId(int id)
        {
            var indications = new List<Indication>();
            using (var db = new GardenCommunityDB())
            {
                var member = db.Members.Include("Payments").Where(x => x.Id == id).First();
                foreach (var payment in member.Payments)
                {
                    indications.Add(payment.Indication);
                }
            }
            return indications;
        }

        public void AddIndication(Indication indication)
        {
            using (var db = new GardenCommunityDB())
            {
                db.Indications.Add(indication);
                db.SaveChanges();
            }
        }

        public void UpdateIndication(Indication indication)
        {
            using (var db = new GardenCommunityDB())
            {
                var updatableIndication = db.Indications.Where(x => x.Id == indication.Id).First();
                updatableIndication.CurrentIndication = updatableIndication.CurrentIndication;
                updatableIndication.LastIndication = indication.LastIndication;
                updatableIndication.LoosesPercent = indication.LoosesPercent;
                updatableIndication.Payment = indication.Payment;
                updatableIndication.Year = indication.Year;
                updatableIndication.Month = indication.Month;
                db.SaveChanges();
            }
        }

        public void RemoveIndication(int id)
        {
            using (var db = new GardenCommunityDB())
            {
                var indication = db.Indications.Where(x => x.Id == id).First();
                db.Indications.Remove(indication);
                db.SaveChanges();
            }
        }
    }
}
