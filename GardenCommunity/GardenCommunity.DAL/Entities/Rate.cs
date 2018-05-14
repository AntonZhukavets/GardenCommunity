using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GardenCommunity.DAL.Entities
{
    [Table("Rates")]
    public class Rate
    {
        public int Id { get; set; }
        public string RateName { get; set; }
        public double RateValue { get; set; }
        public double BankCollectionPercent { get; set; }
        public double FinePercent { get; set; }
        public DateTime Date { get; set; }  
        public ICollection<Payment> Payments { get; set; }
    }
}

//static void TheRealQuery()
//{
//    using (var context = new AdventureWorksDWEntities())
//    {
//        Decimal salesMinimum = 1000;
//        var query = from customer in context.Customers.Where(c => c.InternetSales.Any()).Take(100)
//                    select new { customer, Sales = customer.InternetSales };
//        IEnumerable customers = query.ToList();
//        context.ContextOptions.LazyLoadingEnabled = false;
//        EnumerateCustomers(customers);
//    }
//}