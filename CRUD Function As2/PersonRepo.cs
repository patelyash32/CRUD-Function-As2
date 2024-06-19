using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Function_As2
{
    public class PersonRepo: IPersonRepo
    {
        private readonly AppDbContex _context;

        public PersonRepo(AppDbContex context)
        {
            _context = context;
        }

        public void AddUser(Person person)
        {
            _context.person.Add(person);
            _context.SaveChanges();
        }

        public IEnumerable<Person> GetAllUsers()
        {
            return _context.person.ToList();
        }

        public Person GetUserById(int id)
        {
            return _context.person.Find(id);
        }

        public void UpdateUser(Person person)
        {
            var existingUser = _context.person.Find(person.Id);
            if (existingUser != null)
            {
                existingUser.Name = person.Name;
                existingUser.Email = person.Email;
                _context.SaveChanges();
            }
        }

        public void DeleteUser(int id)
        {
            var person = _context.person.Find(id);
            if (person != null)
            {
                _context.person.Remove(person);
                _context.SaveChanges();
            }
        }
    }
}
