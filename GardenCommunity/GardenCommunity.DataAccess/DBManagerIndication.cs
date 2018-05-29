using GardenCommunity.DataAccess.Entities;
using GardenCommunity.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GardenCommunity.DataAccess
{
    public class DBManagerIndication : IDBManagerIndication
    {
        public int AddIndication(Indication indication)
        {
            var Indication = indication ?? throw new ArgumentNullException("indication");
            using (var db = new GardenCommunityContext())
            {
                db.Indications.Add(indication);
                db.SaveChanges();
            }
            return indication.Id;
        }

        public Indication GetIndication(int id)
        {
            using (var db = new GardenCommunityContext())
            {
                var indication = db.Indications
                    .Include(x => x.Payment)
                    .ThenInclude(x => x.Member)
                    .First(x => x.Id == id);
                return indication;
            }
        }

        public IEnumerable<Indication> GetIndications()
        {
            using (var db = new GardenCommunityContext())
            {
                var indications = db.Indications
                    .Include(x => x.Payment)
                    .ThenInclude(x => x.Member)
                    .ToList() ?? new List<Indication>();
                return indications;
            }
        }

        public IEnumerable<Indication> GetIndicationsByMemberId(int id)
        {            
            using (var db = new GardenCommunityContext())
            {
                var indications = new List<Indication>();
                var member = db.Members.Include("Payments").Where(x => x.Id == id).First();
                foreach (var payment in member.Payments)
                {
                    indications.Add(payment.Indication);
                }
                return indications;
            }
            
        }

        public int RemoveIndication(int id)
        {
            using (var db = new GardenCommunityContext())
            {
                var indication = db.Indications.First(x => x.Id == id);
                db.Indications.Remove(indication);
                db.SaveChanges();
                return indication.Id;
            }
        }

        public int UpdateIndication(Indication indication)
        {
            var Indication = indication ?? throw new ArgumentNullException("indication");
            using (var db = new GardenCommunityContext())
            {
                var updatableIndication = db.Indications.First(x => x.Id == indication.Id);
                updatableIndication.CurrentIndication = indication.CurrentIndication;
                updatableIndication.LastIndication = indication.LastIndication;
                updatableIndication.Month = indication.Month;
                updatableIndication.Year = indication.Year;
                updatableIndication.LoosesPercent = indication.LoosesPercent;
                updatableIndication.Payment = indication.Payment;
                db.SaveChanges();
                return indication.Id;
            }
        }
    }
}
