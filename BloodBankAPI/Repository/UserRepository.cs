using BloodBankAPI.Helper;
using BloodBankAPI.InterfaceRepository;
using BloodBankAPI.Model;

namespace BloodBankAPI.Repository
{
    public class UserRepository :IUserRepository
    {
        public readonly DataBaseContextcs _dbContext = new();
        public UserRepository(DataBaseContextcs dbcontext)
        {
            _dbContext = dbcontext;
        }
        public bool UserExists(string username, string password)
        {
            return _dbContext.BloodBanks.Any(u =>u.UserId == username);
        }
        public void AddUseregistration(User user)
        {
            try
            {
                var details = _dbContext.BloodBanks.Where(x => x.UserId == user.Password).SingleOrDefault();
                if (details == null)    
                {
                    _dbContext.Add(user);
                    _dbContext.SaveChanges();
                }
            }catch (Exception ex) {
                throw ex;
            };
        }

    }
}



//Create table tbl_BloodBank(BloodBankID int not null identity(1,1), BloodBankName Varchar(30),
//Address varchar(max), Pincode varchar(20), Username varchar(30), password varchar(20),
//confirmPwd varchar(30), Email varchar(30), phonenum int, District varchar(30), Area Varchar(30))

