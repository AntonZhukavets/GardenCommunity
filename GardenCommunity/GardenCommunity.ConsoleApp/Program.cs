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
            foreach(var member in memberProvider.GetMembers())
            {
                Console.WriteLine("{0} {1} {2}", member.FirstName, member.LastName, member.Areas.Count);
            }
            Console.WriteLine("Done");
            Console.Read();            
        }
    }
}
