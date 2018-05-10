using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using GardenCommunity.DAL;
using GardenCommunity.DAL.Entities;


namespace GardenCommunity.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            DBManager dBManager = new DBManager();
            Member member1 = new Member()
            {
                FirstName = "F",
                LastName = "L",
                Address = "A",
                IsActiveMember = true,
                Phone = "+333343434"
            };

            try
            {
                foreach(var payment in dBManager.GetPayments())
                {
                    Console.WriteLine("{0} {1} {2}", payment.Id, payment.Member.FirstName, payment.Rate.RateName);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }            
            Console.WriteLine("Done");
            Console.Read();            
        }
    }
}
