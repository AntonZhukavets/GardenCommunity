using System.Collections.Generic;

namespace GardenCommunity.DataAccess.Entities
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
        public ICollection<MembersAreas> MembersAreas { get; set; }
        public ICollection<Payment> Payments { get; set; }
        public Member()
        {
            MembersAreas = new List<MembersAreas>();
        }
    }
}
