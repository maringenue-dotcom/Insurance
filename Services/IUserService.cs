using API.DBModels;
using API.Models;

namespace API.Services
{
    public interface IUserService
    {
        User GetById(int id);
        int IsValidUserInformation(LoginModel model);
    }
}
