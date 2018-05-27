using GardenCommunity.Business.DTO;
using System.Collections.Generic;
using DataAccess = GardenCommunity.DAL.Entities;


namespace GardenCommunity.Business.Mappers
{
    public static class Mapper
    {
        public static DataAccess.Member FromDtoToDalMap(Member member)
        {           
            var dataAccessMember = new DataAccess.Member()
            {
                Id = member.Id,
                FirstName = member.FirstName,
                LastName = member.LastName,
                MiddleName = member.MiddleName,
                Address = member.Address,
                Phone = member.Phone,
                AdditionalInfo = member.AdditionalInfo,                
                IsActiveMember = member.IsActiveMember               
            };
            return dataAccessMember;
        }

        public static DataAccess.Area FromDtoToDalMap(Area area)
        {          
            var dataAccessArea = new DataAccess.Area()
            {
                Id = area.Id,
                ParentAreaId = area.ParentAreaId,
                HasElectricity = area.HasElectricity,
                IsPrivate = area.IsPrivate,
                Square = area.Square                
            };
            if(area.Members!=null)
            {               
                foreach(var member in area.Members)
                {
                    var dataAccessMember = FromDtoToDalMap(member);
                    dataAccessArea.MembersAreas.Add(new DataAccess.MembersAreas()
                    {
                        Member = dataAccessMember
                    });
                }
                
            }
            return dataAccessArea;           
        }

        public static DataAccess.Payment FromDtoToDalMap(Payment payment)
        {
            var dataAccessPayment = new DataAccess.Payment()
            {
                Id = payment.Id,
                DateOfPayment = payment.DateOfPayment,
                MemberId = payment.MemberId,
                PaidFor = payment.PaidFor,
                ToPay = payment.ToPay,
                RateId = payment.RateId                 
            };
            return dataAccessPayment;
        }

        public static DataAccess.Indication FromDtoToDalMap(Indication indication)
        {
            var dataAccessIndication = new DataAccess.Indication()
            {
                Id = indication.Id,
                CurrentIndication = indication.CurrentIndication,
                LastIndication = indication.LastIndication,
                LoosesPercent = indication.LoosesPercent,
                Month = indication.Month,
                Year = indication.Year
            };
            return dataAccessIndication;
        }

        public static DataAccess.Rate FromDtoToDalMap(Rate rate)
        {
            var payments = new List<DataAccess.Payment>();
            if (rate.Payments != null)
            {
                foreach (var payment in rate.Payments)
                {
                    payments.Add(FromDtoToDalMap(payment));
                }
            }
            var dataAccessRate = new DataAccess.Rate()
            {
                Id = rate.Id,
                Date = rate.Date,
                BankCollectionPercent = rate.BankCollectionPercent,
                FinePercent = rate.FinePercent,
                RateName = rate.RateName,
                RateValue = rate.RateValue,
                Payments =payments
            };
            return dataAccessRate;
        }

        public static Member FromDalToDtoMap(DataAccess.Member member)
        {
            var dTOMember = new Member()
            {
                Id = member.Id,
                FirstName = member.FirstName,
                LastName = member.LastName,
                MiddleName = member.MiddleName,
                Address = member.Address,
                Phone = member.Phone,
                IsActiveMember = member.IsActiveMember,
                AdditionalInfo = member.AdditionalInfo
            };
            if (member.MembersAreas != null)
            {
                dTOMember.Areas = new List<Area>();
                foreach (var memberArea in member.MembersAreas)
                {
                    if (memberArea.Area != null)
                    {
                        dTOMember.Areas.Add(new Area()
                        {
                            Id = memberArea.Area.Id,
                            Square = memberArea.Area.Square,
                            IsPrivate = memberArea.Area.IsPrivate,
                            HasElectricity = memberArea.Area.HasElectricity,
                            ParentAreaId = memberArea.Area.ParentAreaId
                        });
                    }
                }
            }
            if (member.Payments != null)
            {
                dTOMember.Payments = new List<Payment>();
                foreach (var payment in member.Payments)
                {
                    dTOMember.Payments.Add(new Payment()
                    {
                        Id = payment.Id,
                        DateOfPayment = payment.DateOfPayment,
                        PaidFor = payment.PaidFor,
                        ToPay = payment.ToPay,
                        RateId = payment.RateId
                    });
                }
            }
            return dTOMember;            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="area"></param>
        /// <returns></returns>
        public static Area FromDalToDtoMap(DataAccess.Area area)
        {
            var dTOArea = new Area()
            {
                Id = area.Id,
                IsPrivate = area.IsPrivate,
                HasElectricity = area.HasElectricity,
                Square = area.Square,
                ParentAreaId = area.ParentAreaId
            };
            if (area.MembersAreas != null)
            {
                dTOArea.Members = new List<Member>();
                foreach (var memberArea in area.MembersAreas)
                {
                    if (memberArea.Member != null)
                    {
                        dTOArea.Members.Add(new Member()
                        {
                            Id = memberArea.Member.Id,
                            FirstName = memberArea.Member.FirstName,
                            LastName = memberArea.Member.LastName,
                            MiddleName = memberArea.Member.MiddleName,
                            AdditionalInfo = memberArea.Member.AdditionalInfo,
                            Address = memberArea.Member.Address,
                            Phone = memberArea.Member.Phone,
                            IsActiveMember = memberArea.Member.IsActiveMember
                        });
                    }
                }
            }
            return dTOArea;            
        }

        public static Payment FromDalToDtoMap(DataAccess.Payment payment)
        {
            var dTOPayment = new Payment()
            {
                Id = payment.Id,
                DateOfPayment = payment.DateOfPayment,
                PaidFor = payment.PaidFor,
                ToPay = payment.ToPay,
                MemberId = payment.MemberId,
                RateId = payment.RateId
            };
            return dTOPayment;
        }

        public static Indication FromDalToDtoMap(DataAccess.Indication indication)
        {
            var dTOindication = new Indication()
            {
                Id = indication.Id,
                CurrentIndication = indication.CurrentIndication,
                LastIndication = indication.LastIndication,
                LoosesPercent = indication.LoosesPercent,
                Month = indication.Month,
                Year = indication.Year,
                Payment = FromDalToDtoMap(indication.Payment)
            };
            return dTOindication;
        }

        public static Rate FromDalToDtoMap(DataAccess.Rate rate)
        {
            var paymets = new List<Payment>();
            var payments = rate.Payments;
            if (payments != null)
            { 
                foreach (var payment in payments)
                {
                    paymets.Add(FromDalToDtoMap(payment));
                }
            }
            var dTORate = new Rate()
            {
                Id = rate.Id,
                Date = rate.Date,
                BankCollectionPercent = rate.BankCollectionPercent,
                FinePercent = rate.FinePercent,
                RateName = rate.RateName,
                RateValue = rate.RateValue,
                Payments=paymets
            };
            return dTORate;
        }

    }
}
