namespace BloodBankAPI.Model
{
    public class BloodDonorDonation
    {
        public int BloodDonorDonationId { get; set; }
        public int BloodDonorId { get; set; }  // Foreign key to BloodDonor entity
        public DateTime BloodDonationDate { get; set; }
        public int NumberOfBottles { get; set; }
        public double Weight { get; set; }
        public double HBCount { get; set; }

        public BloodDonor BloodDonor { get; set; }
    }
}
