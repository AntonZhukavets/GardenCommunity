using System.Collections.Generic;

namespace GardenCommunity.DataAccess.Entities
{    
    /// <summary>
    /// Class that describes table Areas in database. Will use in Entity Framework code first
    /// </summary>
    public class Area
    {
        /// <summary>
        /// Initializes a new instance of the Area class. 
        /// </summary>
        public Area()
        {
            this.MembersAreas = new List<MembersAreas>();
        }

        /// <summary>
        /// Gets or sets Id column in table Areas
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets Square column in table Areas
        /// </summary>
        public int Square { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether IsPrivate enabled in table Areas
        /// </summary>
        public bool IsPrivate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether HasElectricity is enabled in table Areas
        /// </summary>
        public bool HasElectricity { get; set; }

        /// <summary>
        /// Gets or sets navigation property in table Areas
        /// </summary>
        public Area ParentArea { get; set; }

        /// <summary>
        /// Gets or sets Foreign key column in table Areas
        /// </summary>
        public int? ParentAreaId { get; set; }

        /// <summary>
        /// Gets or sets navigation property in table Areas
        /// </summary>
        public ICollection<MembersAreas> MembersAreas { get; set; }        
    }
}
