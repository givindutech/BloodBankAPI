using BloodBankAPI.Model;

namespace BloodBankAPI.InterfaceRepository
{
    public interface IUserDetails
    {
        public List<BloodBank> getBloodBankDetails();
       // public List<BloodBank> GetBloodBankDetailsByDistrict(string? District);
    }
}
