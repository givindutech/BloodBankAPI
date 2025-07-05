namespace BloodBankAPI.Model
{
    public class BloodDonor
    {
        public int BloodDonorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string MobileNo { get; set; }
        public string BloodGroup { get; set; }

        public ICollection<BloodDonorDonation> BloodDonorDonations { get; set; }
    }
}
