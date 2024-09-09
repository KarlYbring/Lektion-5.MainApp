using Lektion_5.MainApp.Models;
using System.Diagnostics;
namespace Lektion_5.MainApp.Services;
public class UserService
{
    private List<User> _users = [];
    public UserServiceResponse CreateUser(User user)
    {
        try
        {
            if (string.IsNullOrEmpty(user.FirstName) || string.IsNullOrEmpty(user.LastName))
            
                return new UserServiceResponse { Succeeded = false, Message = "First name and last name must be provided" };
            
            if(string.IsNullOrEmpty(user.Email))
            
                return new UserServiceResponse { Succeeded = false, Message = "Email must be provided" };
            
            if (_users.Any(var => var.Email == user.Email))
            
                return new UserServiceResponse { Succeeded = false, Message = "Email already exists" };
            
            _users.Add(user);
            return new UserServiceResponse { Succeeded = true, Message = "User was created" };
        }
        catch (Exception ex)
        { 
          Debug.Write(ex.Message);
            return new UserServiceResponse {Succeeded = false, Message = ex.Message};
        }
        
    }
    public IEnumerable<User> GetUsers()
    {
        try
        {
            return _users;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null;
        }
    }
}
