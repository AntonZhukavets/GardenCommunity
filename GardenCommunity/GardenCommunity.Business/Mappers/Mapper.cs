using GardenCommunity.Business.DTO;
using System;
using System.Collections.Generic;
using DataAccess = GardenCommunity.DAL.Entities;


namespace GardenCommunity.Business.Mappers
{
    public static class Mapper
    {
        public static DataAccess.Member FromDtoToDalMap(Member member)
        {
            var areas = new List<DataAccess.Area>();
            var payments = new List<DataAccess.Payment>();
            //if (member.Areas != null)
            //{
            //    foreach (var area in member.Areas)
            //    {
            //        areas.Add(FromDtoToDalMap(area));
            //    }
            //}
            //if (member.Payments != null)
            //{
            //    foreach (var payment in member.Payments)
            //    {
            //        payments.Add(FromDtoToDalMap(payment));
            //    }
            //}
            var dataAccessMember = new DataAccess.Member()
            {
                Id = member.Id,
                FirstName = member.FirstName,
                LastName = member.LastName,
                MiddleName = member.MiddleName,
                Address = member.Address,
                Phone = member.Phone,
                AdditionalInfo = member.AdditionalInfo,
                //Areas = areas,
                IsActiveMember = member.IsActiveMember
                //Payments = payments
            };
            return dataAccessMember;
        }

        public static DataAccess.Area FromDtoToDalMap(Area area)
        {
            var members = new List<DataAccess.Member>();
            if(area.Members!=null)
            {
                foreach(var member in area.Members)
                {
                    members.Add(Mapper.FromDtoToDalMap(member));
                }
            }
            var dataAccessArea = new DataAccess.Area()
            {
                Id = area.Id,
                ParentAreaId = area.ParentAreaId,
                HasElectricity = area.HasElectricity,
                IsPrivate = area.IsPrivate,
                Square = area.Square,
                Members = members
            };
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
            if(member.Areas != null)
            {
                dTOMember.Areas = new List<Area>();
                foreach(var area in member.Areas)
                {
                    dTOMember.Areas.Add(new Area()
                    {
                        Id = area.Id,
                        Square = area.Square,
                        IsPrivate = area.IsPrivate,
                        HasElectricity = area.HasElectricity,
                        ParentAreaId = area.ParentAreaId
                    });
                }
            }
            if(member.Payments != null)
            {
                dTOMember.Payments = new List<Payment>();
                foreach(var payment in member.Payments)
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
            if (area.Members != null)
            {
                dTOArea.Members = new List<Member>(); 
                foreach(var member in area.Members)
                {
                    dTOArea.Members.Add(new Member()
                    {
                        Id = member.Id,
                        FirstName = member.FirstName,
                        LastName = member.LastName,
                        MiddleName = member.MiddleName,
                        AdditionalInfo = member.AdditionalInfo,
                        Address = member.Address,
                        Phone = member.Phone,
                        IsActiveMember = member.IsActiveMember
                    });
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
