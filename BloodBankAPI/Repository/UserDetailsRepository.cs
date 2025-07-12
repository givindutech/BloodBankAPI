using BloodBankAPI.Helper;
using BloodBankAPI.InterfaceRepository;
using BloodBankAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace BloodBankAPI.Repository
{
    public class UserDetailsRepository : IUserDetails
    {
        public readonly DataBaseContextcs _dataBaseContextcs = new();
        public UserDetailsRepository(DataBaseContextcs dataBaseContextcs)
        {
            _dataBaseContextcs = dataBaseContextcs;
        }

        public List<BloodBank> getBloodBankDetails()
        {
          return  _dataBaseContextcs.BloodBanks.ToList();
        }
        //public List<User> GetBloodBankDetailsByDistrict(string? District)
        //{
        //    List<User>? districtDetails = null;
        //    if (districtDetails != null)
        //    {
        //        districtDetails = _dataBaseContextcs.tbl_BloodBank.Where(x => x.District == District).ToList();
        //    }
        //    else
        //    {
        //        districtDetails = _dataBaseContextcs.tbl_BloodBank.ToList();
        //    }
        //    return districtDetails;
        //}
    }
}
