﻿using GardenCommunity.Business.DTO;
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
            if (member.Areas != null)
            {
                foreach (var area in member.Areas)
                {
                    areas.Add(FromDtoToDalMap(area));
                }
            }
            if (member.Payments != null)
            {
                foreach (var payment in member.Payments)
                {
                    payments.Add(FromDtoToDalMap(payment));
                }
            }
            var dataAccessMember = new DataAccess.Member()
            {
                Id = member.Id,
                FirstName = member.FirstName,
                LastName = member.LastName,
                MiddleName = member.MiddleName,
                Address = member.Address,
                Phone = member.Phone,
                AdditionalInfo = member.AdditionalInfo,
                Areas = areas,
                IsActiveMember = member.IsActiveMember,
                Payments = payments
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
                Square = area.Square,
                //MemberId = area.MemberId
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
            var areas = new List<Area>();
            var payments = new List<Payment>();
            if (member.Areas != null)
            {
                foreach (var area in member.Areas)
                {
                    areas.Add(FromDalToDtoMap(area));
                }
            }
            if (member.Payments != null)
            {
                foreach (var payment in member.Payments)
                {
                    payments.Add(FromDalToDtoMap(payment));
                }
            }
            var dTOMember = new Member()
            {
                Id = member.Id,
                FirstName = member.FirstName,
                LastName = member.LastName,
                MiddleName = member.MiddleName,
                Address = member.Address,
                Phone = member.Phone,
                IsActiveMember = member.IsActiveMember,
                AdditionalInfo = member.AdditionalInfo,
                Areas = areas,
                Payments = payments
            };
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
