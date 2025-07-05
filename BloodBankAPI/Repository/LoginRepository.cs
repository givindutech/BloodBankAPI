using BloodBankAPI.Helper;
using BloodBankAPI.InterfaceRepository;
using BloodBankAPI.Model;

namespace BloodBankAPI.Repository
{
    public class LoginRepository :ILogin
    {
        public readonly DataBaseContextcs _dbContext = new();
        public LoginRepository(DataBaseContextcs dbContext)
        {
            _dbContext = dbContext;
        }
        public Login GetUserDetailsTest(Login loginUser)
        {
            try
            {
                Login loginDetails = new Login();
                var name = loginUser.name;
                BloodBank? login = _dbContext.BloodBanks.Where(x=>x.UserId.Contains(name)).FirstOrDefault();
                if (login != null)
                {
                    loginDetails.name = login.UserId;
                    loginDetails.password = login.Password;
                    return loginDetails;
                }
                else
                {
                    return loginDetails;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
