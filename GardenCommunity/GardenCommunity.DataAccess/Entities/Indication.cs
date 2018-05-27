namespace GardenCommunity.DataAccess.Entities
{
    public class Indication
    {
        public int Id { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public double LastIndication { get; set; }
        public double CurrentIndication { get; set; }
        public double LoosesPercent { get; set; }
        public Payment Payment { get; set; }
    }
}
