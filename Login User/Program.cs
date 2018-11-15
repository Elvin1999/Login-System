using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ConsoleApp2
{
    class User
    {
        string Name;
        string SurName;
        string Username;
        string MobileNumber;
        string Password;
        public string _Name { get { return Name; } private set { this.Name = value; } }
        public string _SurName { get { return SurName; } private set { this.SurName = value; } }
        public string _Username { get { return Username; } private set { this.Username = value; } }
        public string _Password { get { return Password; } private set { this.Password = value; } }
        public bool setUsername(string value)
        {
            if (value.Length > 6)
            {
                this.Username = value; return true;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Count of letter must be greater than 6");
                Console.ForegroundColor = ConsoleColor.White;
                return false;
            }

        }
        public bool setPassword(string value)
        {
            if (value.Length > 8)
            {
                this.Password = value; return true;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Count of letter must be greater than 8");
                Console.ForegroundColor = ConsoleColor.White;
                return false;
            }

        }
        public void create()
        {
            Console.Write("Name :");
            this.Name = Console.ReadLine(); Console.WriteLine(); Console.Write("Surname :");
            this.SurName = Console.ReadLine(); Console.WriteLine();
            string temp;
            do
            {
                Console.Write("Username :");
                temp = Console.ReadLine();
            } while (!setUsername(temp));
            Console.WriteLine(); Console.Write("Mobile number :");
            this.MobileNumber = Console.ReadLine(); Console.WriteLine();
            do
            {
                Console.Write("Password :");
                temp = Console.ReadLine();
            } while (!setPassword(temp));
            Console.WriteLine();
        }
        public User() { }
        public User(User user)
        {
        }
        public User(string Name, string Surname, string Username, string MobileNUmber, string Password)
        {
            this.Name = Name;
            this.SurName = Surname;
            setUsername(Username);
            this.MobileNumber = MobileNUmber;
            this.Password = Password;
        }
        public void ShowUserProperty()
        {
            Console.WriteLine($"Name :{Name}");
            Console.WriteLine($"Surname :{SurName}");
            Console.WriteLine($"Username :{Username}");
            Console.WriteLine($"Mobile number :{MobileNumber}");
            Console.Write($"Password :"); for (int i = 0; i < Password.Length; i++)
            {
                Console.Write("*");
            }
            Console.WriteLine();
        }
    }
    class Login
    {
        int cur = 0;
        User[] arr = new User[0];
        public void show()
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine($"{i + 1}.______________________________");
                arr[i].ShowUserProperty();
                Console.WriteLine("______________________________");
            }
        }
        public bool CheckOnlyUsername(string username)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i]._Username == username)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("This  \"Username\" is already exist");
                    Console.ForegroundColor = ConsoleColor.White;
                    return false;
                }
            }
            return true;
        }
        public bool CheckLog(string Username, string Password)
        {

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i]._Username == Username && arr[i]._Password == Password)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("You entered");
                    Console.ForegroundColor = ConsoleColor.White;
                    return true;
                }
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid username or password");
            Console.ForegroundColor = ConsoleColor.White;
            return false;
        }
        public void Add(User data)
        {
            Array.Resize(ref arr, arr.Length + 1);
            arr[cur] = data;
            ++cur;
        }
        public void Remove(int index)
        {

            if (cur == 0) return;
            if (index > cur || index < 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Number did not find");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }
            index -= 1;//it is for similarity with real list
            User[] temp = new User[cur - 1];
            for (int i = 0; i < index; i++)
            {
                temp[i] = arr[i];
            }
            for (int i = index + 1, i2 = index; i < arr.Length; i++, i2++)
            {
                temp[i2] = arr[i];
            }
            --cur;
            arr = temp;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Login list = new Login();
           
            int selection = Convert.ToInt32(Console.ReadLine());
            if (selection == 2)
            {
                User person = new User();
                person.create();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Person passed registration successfully");
                Console.ForegroundColor = ConsoleColor.White;
                list.Add(person);
                while (true)
                {
                    Console.WriteLine("Log in select [1] , \nLog up select [2]\nshow list select[3]" +
                        "\ndelete person by list number select [4]");
                    selection = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();
                    if (selection == 1)
                    {
                        string Username; string Password;
                        do
                        {
                            Console.Write("Username :");
                            Username = Console.ReadLine();
                            Console.Write("Password :");
                            Password = Console.ReadLine();
                            Console.Clear();
                        }
                        while (!list.CheckLog(Username, Password));
                    }
                    else if (selection == 2)
                    {
                        person = new User();
                        do
                        {
                            person.create();
                        } while (!list.CheckOnlyUsername(person._Username));
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Person passed registration successfully");
                        Console.ForegroundColor = ConsoleColor.White;
                        list.Add(person);
                    }
                    else if (selection == 4)
                    {
                        Console.Write("Write number of person in list :");
                        int index = Convert.ToInt32(Console.ReadLine());
                        list.Remove(index);
                    }
                    else if (selection == 3)
                    {
                        Console.Clear();
                        list.show();
                    }
                    else
                    {
                        Console.WriteLine("You can select only 1 or 2");
                    }
                }

            }
            else if (selection == 1)
            {
                Console.WriteLine("You left the system");
            }
            else
            {
                Console.WriteLine("You can select only 1 or 2");
            }
        }
    }
}
