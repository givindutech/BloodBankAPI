using BloodBankAPI.Model;

namespace BloodBankAPI.InterfaceRepository
{
    public interface IUserRepository
    {
        public bool UserExists(string username, string Password);
        public void AddUseregistration(User user);
    }
}
