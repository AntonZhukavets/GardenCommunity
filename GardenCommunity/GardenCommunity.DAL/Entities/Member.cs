using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GardenCommunity.DAL.Entities
{
    public class Member
    {        
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string AdditionalInfo { get; set; }
        public bool IsActiveMember { get; set; }
        public ICollection<Area> Areas { get; set; }
        public ICollection<Payment> Payments { get; set; }
        
    }
}
