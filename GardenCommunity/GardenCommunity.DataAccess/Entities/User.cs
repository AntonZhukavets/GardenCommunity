namespace GardenCommunity.DataAccess.Entities
{
    /// <summary>
    /// Class that describes table Users in database. Will use in Entity Framework code first
    /// </summary>
    public class User
    {
        /// <summary>
        /// Gets or sets Id column in table Users
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets UserName column in table Users
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets Password column in table Users
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets RoleId column in table Users
        /// </summary>
        public int RoleId { get; set; }
        
        /// <summary>
        /// Gets or sets navigation property
        /// </summary>
        public Role Role { get; set; }
    }
}
