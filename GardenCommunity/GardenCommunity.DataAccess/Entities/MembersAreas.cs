using System;

namespace GardenCommunity.DataAccess.Entities
{
    /// <summary>
    /// Class that describes table MembersAreas in database. Will use in Entity Framework code first
    /// </summary>
    public class MembersAreas
    {
        public MembersAreas()
        {
            this.Member = new Member();
            this.Area = new Area();
        }

        /// <summary>
        /// Gets or sets MemberId column in table MembersAreas
        /// </summary>
        public int MemberId { get; set; }

        /// <summary>
        /// Gets or sets AreaId column in table MembersAreas
        /// </summary>
        public int AreaId { get; set; }

        /// <summary>
        /// Gets or sets Id column in table MembersAreas
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets navigation property
        /// </summary>
        public Area Area { get; set; }

        /// <summary>
        /// Gets or sets navigation property
        /// </summary>
        public Member Member { get; set; }

        /// <summary>
        /// Gets or sets OwnedFrom column in table MembersAreas
        /// </summary>
        public DateTime? OwnedFrom { get; set; }

        /// <summary>
        /// Gets or sets OwnedTo column in table MembersAreas
        /// </summary>
        public DateTime? OwnedTo { get; set; }
    }
}
