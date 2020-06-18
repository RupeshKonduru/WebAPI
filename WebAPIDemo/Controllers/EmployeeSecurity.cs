using System;
using System.Linq;
using WebAPIDbConnect;

namespace WebAPIDemo.Controllers
{
    public class EmployeeSecurity
    {
        public static bool Login(string username, string password)
        {
            using (EmpEntities entities = new EmpEntities())
            {
                return entities.Users.Any(user =>
                       user.Username.Equals(username, StringComparison.OrdinalIgnoreCase)
                                          && user.Password == password);
            }
        }
    }
}