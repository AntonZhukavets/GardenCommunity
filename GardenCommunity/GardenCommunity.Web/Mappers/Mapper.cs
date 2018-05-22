﻿using System;
using System.Collections.Generic;
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
            if(member.Areas!=null)
            {
                mVCModelMember.Areas = new List<Area>();
                foreach(var area in member.Areas)
                {
                    mVCModelMember.Areas.Add(new Area()
                    {
                        Id = area.Id,
                        Square = area.Square,
                        IsPrivate = area.IsPrivate,
                        HasElectricity = area.HasElectricity,
                        ParentAreaId = area.ParentAreaId
                    });
                }
            }
            if(member.Payments!=null)
            {
                mVCModelMember.Payments = new List<Payment>();
                foreach (var payment in member.Payments)
                {
                    mVCModelMember.Payments.Add(new Payment()
                    {
                        Id = payment.Id,
                        DateOfPayment = payment.DateOfPayment,
                        PaidFor = payment.PaidFor,
                        ToPay = payment.ToPay,
                        RateId = payment.RateId
                    });
                }
            }
            return mVCModelMember;
        }

        public static Area FromDtoToMVCModelMap(DTO.Area area)
        {
            if(area==null)
            {
                throw new ArgumentNullException("area");
            }
            //var members = new List<Member>();
            //if(area.Members!=null)
            //{
            //    foreach(var member in area.Members)
            //    {
            //        members.Add(Mapper.FromDtoToMVCModelMap(member));
            //    }
            //}
            var mVCModelArea = new Area()
            {
                Id = area.Id,
                Square = area.Square,
                HasElectricity = area.HasElectricity,
                IsPrivate = area.IsPrivate,
                ParentAreaId = area.ParentAreaId                
            };
            if(area.Members!=null)
            {
                mVCModelArea.Members = new List<Member>();
                foreach(var member in area.Members)
                {
                    mVCModelArea.Members.Add(new Member()
                    {
                        Id = member.Id,
                        LastName = member.LastName,
                        FirstName = member.FirstName,
                        MiddleName = member.MiddleName,
                        Address = member.Address,
                        Phone = member.Phone,
                        AdditionalInfo = member.AdditionalInfo,
                        IsActiveMember = member.IsActiveMember
                    });
                }
            }
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

        public static DTO.Area FromMVCModelToDtoMap(Area area)
        {
            if(area==null)
            {
                throw new ArgumentNullException("area");
            }
            var dTOArea = new DTO.Area()
            {
                Id = area.Id,
                Square = area.Square,
                IsPrivate = area.IsPrivate,
                HasElectricity = area.HasElectricity,
                ParentAreaId = area.ParentAreaId,
                MemberId=area.MemberId
            };
            return dTOArea;
        }

        public static DTO.Payment FromMVCModelToDtoMap(Payment payment)
        {
            if (payment == null)
            {
                throw new ArgumentNullException("payment");
            }
            var dTOPayment = new DTO.Payment()
            {
                Id = payment.Id,
                DateOfPayment = payment.DateOfPayment,
                PaidFor = payment.PaidFor,
                ToPay = payment.ToPay,
                RateId = payment.RateId,
                MemberId = payment.MemberId
            };
            return dTOPayment;
        }
    }
}