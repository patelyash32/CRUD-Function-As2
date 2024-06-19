using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public interface IPersonRepo
    {
        void AddUser(Person person);
        IEnumerable<Person> GetAllUsers();
        Person GetUserById(int id);
        void UpdateUser(Person person);
        void DeleteUser(int id);
    }
}
