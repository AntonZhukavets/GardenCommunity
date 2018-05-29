using System.Collections.Generic;

namespace GardenCommunity.DataAccess.Entities
{
    /// <summary>
    /// Class that describes table Members in database. Will use in Entity Framework code first
    /// </summary>
    public class Member
    {
        /// <summary>
        /// Initializes a new instance of the Member class. 
        /// </summary>
        public Member()
        {
            this.MembersAreas = new List<MembersAreas>();
            this.Payments = new List<Payment>();
        }

        /// <summary>
        /// Gets or sets Id column in table Members
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets LastName column in table Members
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets FirstName column in table Members
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets MiddleName column in table Members
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// Gets or sets Address column in table Members
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets Phone column in table Members
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Gets or sets AdditionalInfo column in table Members
        /// </summary>
        public string AdditionalInfo { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether IsActiveMember is enabled in table Area
        /// </summary>
        public bool IsActiveMember { get; set; }

        /// <summary>
        /// Gets or sets navigation property
        /// /// </summary>
        public ICollection<MembersAreas> MembersAreas { get; set; }

        /// <summary>
        /// Gets or sets navigation property
        /// /// </summary>
        public ICollection<Payment> Payments { get; set; }        
    }
}
