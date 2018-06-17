using System;
using System.Collections.Generic;
using DAL = GardenCommunity.DataAccess.Entities;
using GardenCommunity.Common.Entities;

namespace GardenCommunity.Common.Mappers
{
    public static class Mapper 
    {        
        public static DAL.Area FromBusinessToDataAccessMap(Area area)
        {
            var Area = area ?? throw new ArgumentException("area");
            var dataAccessArea = new DAL.Area()
            {
                Id = Area.Id,
                IsPrivate = Area.IsPrivate,
                HasElectricity = Area.HasElectricity,
                ParentAreaId = Area.ParentAreaId,
                Square = Area.Square
            };
            var membersAreas = new List<DAL.MembersAreas>();
            foreach(var member in area.Members)
            {
                membersAreas.Add(new DAL.MembersAreas()
                {
                    AreaId = Area.Id,
                    Member = new DAL.Member()
                    {
                        Id = member.Id,
                        LastName = member.LastName,
                        FirstName = member.FirstName,
                        MiddleName = member.MiddleName,
                        AdditionalInfo = member.AdditionalInfo,
                        Address = member.Address,
                        IsActiveMember = member.IsActiveMember,
                        Phone = member.Phone
                    },
                    MemberId = member.Id,
                    OwnedFrom = Area.OwnedFrom,
                    OwnedTo = Area.OwnedTo
                });
            }
            dataAccessArea.MembersAreas = membersAreas;
            return dataAccessArea;
        }

        public static DAL.Member FromBusinessToDataAccessMap(Member member)
        {
            var Member = member ?? throw new ArgumentNullException("member");
            var dataAccessMember = new DAL.Member()
            {
                Id = Member.Id,
                LastName = Member.LastName,
                FirstName = Member.FirstName,
                MiddleName = Member.MiddleName,
                Address = Member.Address,
                Phone = Member.Phone,
                AdditionalInfo = Member.AdditionalInfo,
                IsActiveMember = Member.IsActiveMember
            };
            var membersAreas = new List<DAL.MembersAreas>();
            if (member.Areas != null)
            {
                foreach (var area in member.Areas)
                {
                    membersAreas.Add(new DAL.MembersAreas()
                    {
                        Area = new DAL.Area()
                        {
                            Id = area.Id,
                            Square = area.Square,
                            HasElectricity = area.HasElectricity,
                            IsPrivate = area.IsPrivate,
                            ParentAreaId = area.ParentAreaId
                        },
                        OwnedFrom = area.OwnedFrom,
                        OwnedTo = area.OwnedTo,
                        AreaId = area.Id
                    });
                }
                dataAccessMember.MembersAreas = membersAreas;
            }
            return dataAccessMember;
        }

        public static DAL.Payment FromBusinessToDataAccessMap(Payment payment)
        {
            var Payment = payment ?? throw new ArgumentNullException("payment");
            var dataAccessPayment = new DAL.Payment()
            {
                Id = payment.Id,
                DateOfPayment = payment.DateOfPayment,
                MemberId = payment.MemberId,
                PaidFor = payment.PaidFor,
                ToPay = payment.ToPay,
                RateId = payment.RateId,
                Indication = new DAL.Indication()
                {
                    Id = payment.Indication.Id,
                    CurrentIndication = payment.Indication.CurrentIndication,
                    LastIndication = payment.Indication.LastIndication,
                    LoosesPercent = payment.Indication.LoosesPercent,
                    Month = payment.Indication.Month,
                    Year = payment.Indication.Year

                }
            };
            return dataAccessPayment;

        }

        public static DAL.Rate FromBusinessToDataAccessMap(Rate rate)
        {
            var Rate = rate ?? throw new ArgumentNullException("rate");
            var dataAccessRate = new DAL.Rate()
            {
                Id = rate.Id,
                Date = rate.Date,
                BankCollectionPercent = rate.BankCollectionPercent,
                FinePercent = rate.FinePercent,
                RateName = rate.RateName,
                RateValue = rate.RateValue
            };
            var dataAccessPayments = new List<DAL.Payment>();            
            foreach(var payment in rate.Payments)
            {

                dataAccessPayments.Add(new DAL.Payment()
                {
                    Id = payment.Id,
                    DateOfPayment = payment.DateOfPayment,
                    MemberId = payment.MemberId,
                    PaidFor = payment.PaidFor,
                    ToPay = payment.ToPay,
                    RateId = payment.RateId
                });
            }
            return dataAccessRate;
        }

        public static DAL.Indication FromBusinessToDataAccessMap(Indication indication)
        {
            var Indication = indication ?? throw new ArgumentNullException("indication");
            var dataAccessIndication = new DAL.Indication()
            {
                Id = indication.Id,
                CurrentIndication = indication.CurrentIndication,
                LastIndication = indication.LastIndication,
                LoosesPercent = indication.LoosesPercent,
                Month = indication.Month,
                Year = indication.Year               
                
            };
            var dataAccessPayment = new DAL.Payment()
            {
                Id = indication.Payment.Id,
                DateOfPayment = indication.Payment.DateOfPayment,
                MemberId = indication.Payment.MemberId,
                PaidFor = indication.Payment.PaidFor,
                ToPay = indication.Payment.ToPay,
                RateId = indication.Payment.RateId
            };
            dataAccessIndication.Payment = dataAccessPayment;
            return dataAccessIndication;
            
        }

        public static DAL.Role FromBusinessToDataAccessMap(Role role)
        {
            var Role = role ?? throw new ArgumentNullException("role");
            var dataAccessRole = new DAL.Role()
            {
                Id = role.Id,
                Name = role.Name
            };
            return dataAccessRole;
        }

        public static DAL.User FromBusinessToDataAccessMap(User user)
        {
            var User = user ?? throw new ArgumentNullException("user");
            var dataAccessUser = new DAL.User()
            {
                Id = user.Id,
                UserName = user.UserName,
                Password = user.Password,
                RoleId = user.Role.Id
            };
            return dataAccessUser;
        }

        public static Area FromDataAccessToBusinessMap(DAL.Area area)
        {
            var Area = area ?? throw new ArgumentNullException("area");
            var dTOArea = new Area()
            {
                Id = area.Id,
                Square = area.Square,
                HasElectricity = area.HasElectricity,
                IsPrivate = area.IsPrivate,
                ParentAreaId = area.ParentAreaId                
            };
            var members = new List<Member>();
            foreach(var memberArea in area.MembersAreas)
            {
                members.Add(new Member()
                {
                    Id = memberArea.Member.Id,
                    LastName = memberArea.Member.LastName,
                    FirstName = memberArea.Member.FirstName,
                    MiddleName = memberArea.Member.MiddleName,
                    Address = memberArea.Member.Address,
                    Phone = memberArea.Member.Phone,
                    IsActiveMember = memberArea.Member.IsActiveMember,
                    AdditionalInfo = memberArea.Member.AdditionalInfo
                });
            }
            dTOArea.Members = members;
            return dTOArea;
        }

        public static Member FromDataAccessToBusinessMap(DAL.Member member)
        {
            var Member = member ?? throw new ArgumentNullException("member");
            var dTOMember = new Member()
            {
                Id = member.Id,
                LastName = member.LastName,
                FirstName = member.FirstName,
                MiddleName = member.MiddleName,
                Address = member.Address,
                Phone = member.Phone,
                IsActiveMember = member.IsActiveMember,
                AdditionalInfo = member.AdditionalInfo
            };
            var areas = new List<Area>();
            foreach(var memberArea in member.MembersAreas)
            {
                areas.Add(new Area()
                {
                    Id = memberArea.Area.Id,
                    Square = memberArea.Area.Square,
                    HasElectricity = memberArea.Area.HasElectricity,
                    IsPrivate = memberArea.Area.IsPrivate,
                    OwnedFrom = memberArea.OwnedFrom,
                    OwnedTo = memberArea.OwnedTo,
                    ParentAreaId = memberArea.Area.ParentAreaId
                });
            }
            dTOMember.Areas = areas;
            return dTOMember;
        }

        public static Payment FromDataAccessToBusinessMap(DAL.Payment payment)
        {
            var Payment = payment ?? throw new ArgumentNullException("payment");
            var dTOPayment = new Payment()
            {
                Id = payment.Id,
                DateOfPayment = payment.DateOfPayment,
                MemberId = payment.MemberId,
                PaidFor = payment.PaidFor,
                ToPay = payment.ToPay,
                RateId = payment.RateId
            };
            var dTOIndication = new Indication()
            {
                Id = payment.Indication.Id,
                CurrentIndication = payment.Indication.CurrentIndication,
                LastIndication = payment.Indication.LastIndication,
                LoosesPercent = payment.Indication.LoosesPercent,
                Month = payment.Indication.Month,
                Year = payment.Indication.Year
            };
            var dTORate = new Rate()
            {
                Id = payment.Rate.Id,
                RateName = payment.Rate.RateName,
                RateValue = payment.Rate.RateValue,
                BankCollectionPercent = payment.Rate.BankCollectionPercent,
                Date = payment.Rate.Date,
                FinePercent = payment.Rate.FinePercent
            };
            var dTOMember = new Member()
            {
                Id = payment.Member.Id,
                FirstName = payment.Member.FirstName,
                LastName = payment.Member.LastName,
                MiddleName = payment.Member.MiddleName,
                AdditionalInfo = payment.Member.AdditionalInfo,
                Address = payment.Member.Address,
                Phone = payment.Member.Phone,
                IsActiveMember = payment.Member.IsActiveMember
            };
            dTOPayment.Indication = dTOIndication;
            dTOPayment.Rate = dTORate;
            dTOPayment.Member = dTOMember;
            return dTOPayment;
        }

        public static Rate FromDataAccessToBusinessMap(DAL.Rate rate)
        {
            var Rate = rate ?? throw new ArgumentNullException("rate");
            var dTORate = new Rate()
            {
                Id = rate.Id,
                RateName = rate.RateName,
                RateValue = rate.RateValue,
                BankCollectionPercent = rate.BankCollectionPercent,
                FinePercent = rate.FinePercent,
                Date = rate.Date
            };
            var dTOPayments = new List<Payment>();
            foreach(var payment in rate.Payments)
            {
                dTOPayments.Add(new Payment()
                {
                    Id = payment.Id,
                    DateOfPayment = payment.DateOfPayment,
                    MemberId = payment.MemberId,
                    PaidFor = payment.PaidFor,
                    ToPay = payment.ToPay,
                    Indication = new Indication()
                    {
                        Id = payment.Indication.Id,
                        CurrentIndication = payment.Indication.CurrentIndication,
                        LastIndication = payment.Indication.LastIndication,
                        LoosesPercent = payment.Indication.LoosesPercent,
                        Month = payment.Indication.Month,
                        Year = payment.Indication.Year
                    }
                });
            }
            dTORate.Payments = dTOPayments;
            return dTORate;
        }

        public static Indication FromDataAccessToBusinessMap(DAL.Indication indication)
        {
            var Indication = indication ?? throw new ArgumentNullException("indication");
            var dTOIndication = new Indication()
            {
                Id = indication.Id,
                CurrentIndication = indication.CurrentIndication,
                LastIndication = indication.LastIndication,
                Month = indication.Month,
                Year = indication.Year,
                LoosesPercent = indication.LoosesPercent
            };
            var dTOPayment = new Payment()
            {
                Id = indication.Payment.Id,
                DateOfPayment = indication.Payment.DateOfPayment,
                MemberId = indication.Payment.MemberId,
                PaidFor = indication.Payment.PaidFor,
                ToPay = indication.Payment.ToPay,
                RateId = indication.Payment.RateId,
                Rate = new Rate()
                {
                    Id = indication.Payment.Rate.Id,
                    RateName = indication.Payment.Rate.RateName,
                    RateValue = indication.Payment.Rate.RateValue,
                    BankCollectionPercent = indication.Payment.Rate.BankCollectionPercent,
                    Date = indication.Payment.Rate.Date,
                    FinePercent = indication.Payment.Rate.FinePercent
                }
            };
            dTOIndication.Payment = dTOPayment;
            return dTOIndication;
        }

        public static Role FromDataAccessToBusinessMap(DAL.Role role)
        {
            var Role = role ?? throw new ArgumentNullException("role");
            var dTORole = new Role()
            {
                Id = role.Id,
                Name = role.Name
            };
            return dTORole;
        }

        public static User FromDataAccessToBusinessMap(DAL.User user)
        {
            var User = user ?? throw new ArgumentNullException("user");
            var dTOUser = new User()
            {
                Id = user.Id,
                UserName = user.UserName,
                Password = user.Password,
                Role = new Role()
                {
                    Id = user.Role.Id,
                    Name = user.Role.Name
                }
            };
            return dTOUser;
        }
    }
}
