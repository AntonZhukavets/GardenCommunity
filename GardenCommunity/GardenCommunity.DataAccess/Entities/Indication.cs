namespace GardenCommunity.DataAccess.Entities
{
    /// <summary>
    /// Class that describes table Indication in database. Will use in Entity Framework code first
    /// </summary
    public class Indication
    {
        /// <summary>
        /// Gets or sets Id column in table Indications
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets Month column in table Indications
        /// </summary>
        public int Month { get; set; }

        /// <summary>
        /// Gets or sets Year column in table Indications
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// Gets or sets LastIndication column in table Indications
        /// </summary>
        public double LastIndication { get; set; }

        /// <summary>
        /// Gets or sets CurrentIndication column in table Indications
        /// </summary>
        public double CurrentIndication { get; set; }

        /// <summary>
        /// Gets or sets LoosesPercent column in table Indications
        /// </summary>
        public double LoosesPercent { get; set; }

        /// <summary>
        /// Gets or sets Payment column in table Indications
        /// </summary>
        public Payment Payment { get; set; }
    }
}
