using GardenCommunity.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DTO = GardenCommunity.Business.DTO;
namespace GardenCommunity.Web.Mappers
{
    public static class Mapper
    {
        public static Member FromDtoToMVCModelMap(DTO.Member member)
        {
            var mVCModelMember = new Member()
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
            return mVCModelMember;
        }

        public static Area FromDtoToMVCModelMap(DTO.Area area)
        {
            var mVCModelArea = new Area()
            {
                Id = area.Id,
                Square = area.Square,
                HasElectricity = area.HasElectricity,
                IsPrivate = area.IsPrivate,
                ParentAreaId = area.ParentAreaId                
            };
            return mVCModelArea;
        }

        public static Payment FromDtoToMVCModelMap(DTO.Payment payment)
        {
            var mVCModelPayment = new Payment()
            {
                Id = payment.Id,
                MemberId = payment.MemberId,
                PaidFor = payment.PaidFor,
                ToPay = payment.ToPay,
                DateOfPayment = payment.DateOfPayment,
                RateId = payment.RateId
            };
            return mVCModelPayment;
        }

        public static Indication FromDtoToMVCModelMap(DTO.Indication indication)
        {
            var mVCModelIndication = new Indication()
            {
                Id = indication.Id,
                Month = indication.Month,
                Year = indication.Year,
                LastIndication = indication.LastIndication,
                CurrentIndication = indication.CurrentIndication,
                LoosesPercent = indication.LoosesPercent
            };
            return mVCModelIndication;
        }
        public static Rate FromDtoToMVCModelMap(DTO.Rate rate)
        {
            var mVCModelRate = new Rate()
            {
                Id = rate.Id,
                RateName = rate.RateName,
                RateValue = rate.RateValue,
                Date = rate.Date,
                BankCollectionPercent = rate.BankCollectionPercent,
                FinePercent = rate.FinePercent

            };
            return mVCModelRate;
        }
    }
}