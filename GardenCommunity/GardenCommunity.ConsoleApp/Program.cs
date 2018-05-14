using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using GardenCommunity.Business.DTO;
using GardenCommunity.Business.Providers;
using GardenCommunity.DAL;

namespace GardenCommunity.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var memberProvider = new MemberProvider(new DBManagerMember());
            var members = memberProvider.GetMembers();
            foreach (var member in members)
            {

                Console.WriteLine("Id:{0} RateName:{1} RateValue:{2} ", member.Id, member.FirstName, member.LastName);
            }
            //var member = new Member()
            //{
            //    Id=8,
            //    FirstName = "Kevin",
            //    LastName = "Leuies",
            //    IsActiveMember = true,
            //    Address = "Marcel",
            //    Phone = "+892839302"
            //};

            //var payment = new Payment()
            //{
            //    DateOfPayment = DateTime.Now,
            //    PaidFor = 100,
            //    ToPay = 200,                
            //    RateId = 2
            //};
            //var payments = new List<Payment>();
            //payments.Add(payment);
            //member.Payments = payments;
            //memberProvider.UpdateMember(member);
            //foreach(var member in memberProvider.GetMembers())
            //{
            //    Console.WriteLine("{0} {1}", member.FirstName, member.LastName);
            //    foreach(var area in member.Areas)
            //    {
            //        Console.WriteLine("Id:{0} ParentAreaId:{1} Square:{2}", area.Id, area.ParentAreaId, area.Square);
            //    }
            //}
            //var areaProvider = new AreaProvider(new DBManagerArea());
            //var areas = areaProvider.GetAreasByMemberId(3);
            //foreach(var area in areas)
            //{
            //    Console.WriteLine("Id:{0} ParentAreaId:{1} Square:{2}", area.Id, area.ParentAreaId, area.Square);
            //}
            //var rateProvider = new RateProvider(new DBManagerRate());
            //var rates = rateProvider.GetRates(DateTime.Now,DateTime.Now);
            //foreach (var rate in rates)
            //{
            //    Console.WriteLine("Id:{0} RateName:{1} RateValue:{2} ",rate.Id,rate.RateName,rate.RateValue);
            //}
            Console.WriteLine("Done");
            Console.Read();            
        }
    }
}
