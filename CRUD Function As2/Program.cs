using Core;

namespace CRUD_Function_As2
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new AppDbContex())
            {
                context.Database.EnsureCreated();
                var PersonRepository = new PersonRepo(context);
                bool exit = false;

                Console.WriteLine("Enter commands: add, list, edit <id>, delete <id>, or exit");

                while (!exit)
                {
                    Console.Write("Enter your input> ");
                    string input = Console.ReadLine();
                    var PersonInput = input.Split(' ');

                    if (PersonInput[0].ToLower() == "add")
                    {
                        AddUser(PersonRepository);
                    }
                    else if (PersonInput[0].ToLower() == "list")
                    {
                        ListUsers(PersonRepository);
                    }
                    else if (PersonInput[0].ToLower() == "edit")
                    {
                        if (PersonInput.Length > 1 && int.TryParse(PersonInput[1], out int editId))
                        {
                            EditUser(PersonRepository, editId);
                        }
                        else
                        {
                            Console.WriteLine("Invalid command. Use: edit <id>");
                        }
                    }
                    else if (PersonInput[0].ToLower() == "delete")
                    {
                        if (PersonInput.Length > 1 && int.TryParse(PersonInput[1], out int deleteId))
                        {
                            DeleteUser(PersonRepository, deleteId);
                        }
                        else
                        {
                            Console.WriteLine("Invalid command. Use: delete <id>");
                        }
                    }
                    else if (PersonInput[0].ToLower() == "exit")
                    {
                        exit = true;
                    }
                    else
                    {
                        Console.WriteLine("Unknown command. Valid commands are: add, list, edit <id>, delete <id>, exit");
                    }
                }
            }
        }

        static void AddUser(IPersonRepo personRepository)
        {
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Email: ");
            string email = Console.ReadLine();

            var person = new Person { Name = name, Email = email };
            personRepository.AddUser(person);
            Console.WriteLine($"User {name} added.");
        }

        static void ListUsers(IPersonRepo personRepository)
        {
            var persons = personRepository.GetAllUsers();
            if (!persons.Any())
            {
                Console.WriteLine("No users found.");
            }
            else
            {
                Console.WriteLine("ID\tName\t\tEmail");
                Console.WriteLine("--------------------------------------------------");
                foreach (var person in persons)
                {
                    Console.WriteLine($"{person.Id}\t{person.Name}\t\t{person.Email}");
                }
            }
        }

        static void EditUser(IPersonRepo personRepository, int id)
        {
            var person = personRepository.GetUserById(id);
            if (person != null)
            {
                Console.Write("Enter new Name: ");
                string updatedName = Console.ReadLine();
                Console.Write("Enter new Email: ");
                string updatedEmail = Console.ReadLine();

                person.Name = updatedName;
                person.Email = updatedEmail;
                personRepository.UpdateUser(person);
                Console.WriteLine($"User updated.");
            }
            else
            {
                Console.WriteLine($"User not found.");
            }
        }

        static void DeleteUser(IPersonRepo personRepository, int id)
        {
            var person = personRepository.GetUserById(id);
            if (person != null)
            {
                personRepository.DeleteUser(id);
                Console.WriteLine($"User deleted.");
            }
            else
            {
                Console.WriteLine($"User not found.");
            }
        }
    }
}