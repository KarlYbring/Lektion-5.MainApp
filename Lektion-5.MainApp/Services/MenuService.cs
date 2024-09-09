using Lektion_5.MainApp.Models;
using System.Xml;

namespace Lektion_5.MainApp.Services;
////internal class MenuService
////{
////    private string _fieldName;

////    public string PropertyName;

////   public string MethodName(string inputParameter, out string outputParameter)
////    {
////        return inputParameter;
////    }

////    public MenuService()
////    {
////        _fieldName = null;
////        PropertyName = null;
////    }
////    public MenuService(string fieldName, string propertyName)
////    {
////      _fieldName = fieldName;
////       PropertyName = propertyName;
////    }
//}


internal static class MenuService
{
    private static readonly UserService _userService = new();
    private static void CreateUserMenu()
    {
        var user = new User();
        Console.Clear();
        Console.WriteLine("--- CREATE USER ---");
        
        Console.Write("Enter first name: ");
                   
        user.FirstName = Console.ReadLine() ?? "";
        
        Console.Write("Enter last name: ");
        user.LastName = Console.ReadLine() ?? "";
        
        Console.Write("Enter email: ");
        user.Email = Console.ReadLine() ?? "";
        
        Console.Write("Enter Phonenumber: ");
        user.PhoneNumber = Console.ReadLine() ?? "";

        var response = _userService.CreateUser(user);
        Console.WriteLine(response.Message);
    }
    private static void ListAllUsersMenu()
    {
        Console.Clear();
        Console.WriteLine("--- USER LIST ---");
        var users = _userService.GetUsers();
        if (users != null)
        {
            foreach (var user in _userService.GetUsers())
            {
                Console.WriteLine($"{user.FirstName} {user.LastName} {user.Email}");
            }
        }
        else
        {
            Console.WriteLine("no users found");
        }
        Console.ReadKey();
    }

    private static void ExitAppMenu()
    {
        Console.Clear();
        Console.WriteLine("are you sure you want to exit (y/n)");
        var answer = Console.ReadLine() ?? "";
        if (answer.ToLower() == "y")
        {
            Environment.Exit(0);
        }
    }
    private static bool MenuOptions(string selectedOption)
    {
        if (int.TryParse(selectedOption, out int option))
        {
            switch (option)
            {
                case 1:
                    CreateUserMenu();
                    Console.ReadKey();
                    break;

                case 2:
                    ListAllUsersMenu();
                    Console.ReadKey();
                    break;

                case 0:
                    ExitAppMenu();
                    break;

                default:
                    Console.WriteLine("Invalid option");
                    Console.ReadKey();
                    return false;
            }
            return true;
        }
        return false;
    }
    public static void MainMenu()
    {
        Console.Clear();
        Console.WriteLine("1. Create new User");
        Console.WriteLine("2. List all Users");
        Console.WriteLine("0. Exit");
        
        Console.Write("Enter an option: ");
        var result = MenuOptions(Console.ReadLine() ?? "");
        if (!result)
        {
            Console.WriteLine("Invalid option!");
        }   
    }
}
