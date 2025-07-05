namespace BloodBankAPI.Model
{
    public class BloodDonationCamp
    {
        public int BloodDonationCampId { get; set; }
        public string CampName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string BloodBank { get; set; }
        public DateTime CampStartDate { get; set; }
        public DateTime CampEndDate { get; set; }
    }
}
