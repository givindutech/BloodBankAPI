namespace BloodBankAPI.Model
{
    public class BloodInventory
    {
        public int BloodInventoryID { get; set; }
        public string BloodGroup { get; set; }
        public int NumberOfBottles { get; set; }
        public int BloodBankID { get; set; }  // Foreign key to BloodBank entity
        public DateTime ExpiryDate { get; set; }
    }
}
