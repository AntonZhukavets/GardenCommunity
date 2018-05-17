using System;
using GardenCommunity.Web.Models;
using DTO = GardenCommunity.Business.DTO;

namespace GardenCommunity.Web.Mappers
{
    public static class Mapper
    {
        public static Member FromDtoToMVCModelMap(DTO.Member member)
        {
            if(member==null)
            {
                throw new ArgumentNullException("member");
            }
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
            if(area==null)
            {
                throw new ArgumentNullException("area");
            }
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
            if(payment==null)
            {
                throw new ArgumentNullException("payment");
            }
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
            if(indication==null)
            {
                throw new ArgumentNullException("indication");
            }
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
            if(rate==null)
            {
                throw new ArgumentNullException("rate");
            }
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

        public static DTO.Rate FromMVCModelToDtoMap(Rate rate)
        { 
            if(rate==null)
            {
                throw new ArgumentNullException("rate");
            }
            var dTORate = new DTO.Rate()
            {
                Id = rate.Id,
                RateName = rate.RateName,
                RateValue = rate.RateValue,
                FinePercent = rate.FinePercent,
                BankCollectionPercent = rate.BankCollectionPercent,
                Date = rate.Date
            };
            return dTORate;
        }

        public static DTO.Member FromMVCModelToDtoMap(Member member)
        {
            if (member == null)
            {
                throw new ArgumentNullException("member");
            }
            var dTOMember = new DTO.Member()
            {
                Id = member.Id,
                LastName = member.LastName,
                FirstName = member.FirstName,
                MiddleName = member.MiddleName,
                Address = member.Address,
                Phone = member.Phone,
                AdditionalInfo=member.AdditionalInfo,
                IsActiveMember=member.IsActiveMember
            };
            return dTOMember;
        }
    }
}