using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using GardenCommunity.DAL.Entities;

namespace GardenCommunity.DAL
{
    public class DBManager
    {
        public IEnumerable<Area> GetAreas()
        {
            using (var db = new GardenCommunityDB())
            {
                return db.Areas.ToList();
            }
                  
        }

        public IEnumerable<Area> GetAreasByMemberId(int memberId)
        {            
            using (var db = new GardenCommunityDB())
            {
                var member = db.Members.Include("Areas").Where(x => x.Id == memberId).FirstOrDefault();
                var areaIdList = new List<int>();
                if(member!=null && member.Areas.Count>0)
                {
                    var membersAreas = new List<Area>();
                    membersAreas.AddRange(member.Areas);
                    
                    foreach (var area in member.Areas)
                    {
                        var additionalAreas = db.Areas.Where(x => x.AdditionalAreaId.Value == area.Id).ToList();
                        membersAreas.AddRange(additionalAreas);
                    }
                    return membersAreas;
                }
                
                return null;
            }            
        }

        public IEnumerable<Member> GetMembersByAreaId(int id)
        {
            using (var db = new GardenCommunityDB())
            {
                var members = new List<Member>();                
                int mainAreaId = 0;
                var area = db.Areas.Include("Members").Where(x => x.Id == id).FirstOrDefault();
                //if (area.Members.Count != 0)
                //{
                //    members.AddRange(area.Members);
                //}
                //if (area.AdditionalAreaId != null)
                //{
                //    mainAreaId = area.AdditionalAreaId.Value;
                //    area = db.Areas.Include("Members").Where(x => x.Id == mainAreaId).FirstOrDefault();
                //    members.AddRange(area.Members);
                //}             
                return members;                       
            }
        }

        

        public Area GetArea(int id)
        {
            using (var db = new GardenCommunityDB())
            {
                return db.Areas.Find(id);
            }
        }

        public void AddArea(Area area)
        {
            if (area != null)
            {
                using (var db = new GardenCommunityDB())
                {
                    db.Areas.Add(area);
                    db.SaveChanges();
                }
            }
        }       

        public void UpdateArea(Area area)
        {
            using (var db = new GardenCommunityDB())
            {
                var targetArea = db.Areas.Find(area.Id);
                if(targetArea!=null)
                {
                    targetArea.Square = area.Square;
                    targetArea.IsPrivate = area.IsPrivate;
                    targetArea.HasElectricity = area.HasElectricity;
                    targetArea.AdditionalArea = area.AdditionalArea;
                    db.SaveChanges();
                }
            }
        }

        public void RemoveArea(int id)
        {
            using (var db = new GardenCommunityDB())
            {
                var targetArea = db.Areas.Find(id);
                if (targetArea != null)
                {
                    db.Areas.Remove(targetArea);
                }                
            }
        }

        public IEnumerable<Member> GetMembers()
        {
            using (var db = new GardenCommunityDB())
            {
                return db.Members.ToList();
            }
        }

        public Member GetMember(int id)
        {
            using (var db = new GardenCommunityDB())
            {
                var member = db.Members.Where(x => x.Id == id).First();
                return member;
            }
        }

        public void AddMember(Member member)
        {
            using (var db = new GardenCommunityDB())
            {
                db.Members.Add(member);
                db.SaveChanges();
            }                    
        }

        public void UpdateMember(Member member)
        {
            using (var db = new GardenCommunityDB())
            {
                var updatableMember = db.Members.Where(x => x.Id == member.Id).First();
                updatableMember.FirstName = member.FirstName;
                updatableMember.LastName = member.LastName;
                updatableMember.MiddleName = member.MiddleName;
                updatableMember.Address = member.Address;
                updatableMember.Phone = member.Phone;
                updatableMember.IsActiveMember = member.IsActiveMember;
                updatableMember.Payments = member.Payments;
                updatableMember.Areas = member.Areas;
                db.SaveChanges();
            }
        }       

        public void RemoveMember (int id)
        {
            using (var db = new GardenCommunityDB())
            {
                var deletableMember = db.Members.Where(x => x.Id == id).First();
                db.Members.Remove(deletableMember);
                db.SaveChanges();                               
            }
        }

        public IEnumerable<Payment> GetPayments()
        {
            using (var db = new GardenCommunityDB())
            {
                return db.Payments.Include("Member").Include("Rate").ToList();
            }
            
        }

        public IEnumerable<Payment> GetPaymentsByMemberId(int id)
        {
            using (var db = new GardenCommunityDB())
            {
                var payments = db.Payments.Include("Rate").Where(x => x.MemberId == id).ToList();
                return payments;
            }
        }

        public IEnumerable<Payment> GetPaymentsByMemberId(int id, DateTime beginDate, DateTime endDate)
        {
            var payments = GetPaymentsByMemberId(id).Where(x => x.DateOfPayment >= beginDate && x.DateOfPayment <= endDate).ToList();
            return payments;
        }
        public void AddPayment(Payment payment)
        {
            using (var db = new GardenCommunityDB())
            {
                db.Payments.Add(payment);
                db.SaveChanges();
            }
        }

        public void UpdatePayment(Payment payment)
        {
            using (var db = new GardenCommunityDB())
            {
                var updatabePayment = db.Payments.Where(x => x.Id == payment.Id).First();
                updatabePayment.DateOfPayment = payment.DateOfPayment;
                updatabePayment.Indication = payment.Indication;
                updatabePayment.Member = payment.Member;
                updatabePayment.PaidFor = payment.PaidFor;
                updatabePayment.ToPay = payment.ToPay;
                updatabePayment.Rate = payment.Rate;
                db.SaveChanges();
            }
        }

        public void RemovePayment(int id)
        {
            using (var db = new GardenCommunityDB())
            {
                var deletablePayment = db.Payments.Where(x => x.Id == id).First();
                db.Payments.Remove(deletablePayment);
                db.SaveChanges();
            }
        }
        public IEnumerable<Indication> GetIndicationsByMemberId(int id)
        {
            var indications = new List<Indication>();
            using (var db = new GardenCommunityDB())
            {                
                var member = db.Members.Include("Payments").Where(x => x.Id == id).First();
                foreach(var payment in member.Payments)
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
            if(rate == null)
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

        


    }
}
