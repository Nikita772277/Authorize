using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Authorize
{
    internal class Registration
    {
        private string _way = @"C:\Users\Студент 3\Desktop\Users.txt";
        private void SetLogin()
        {
            string login;
            while (true)
            {
                Console.WriteLine($"В логине должно быть минимум 4 символа");
                Console.WriteLine();
                Console.WriteLine($"Введите логин");
                login = Console.ReadLine();
                bool c = LoginIsBusy(login);
                if (c == true)
                {
                    bool a = CheckLogin(login);
                    if (a == true) { break; }
                }
            }
            using (StreamWriter writer = new StreamWriter(_way, true))
            {
                writer.Write ($"{login} ");
            }
        }
        private bool LoginIsBusy(string login)
        {
            using (StreamReader reader = new StreamReader(_way))
            {
                string? line;
                while ((line = reader.ReadLine()) != null)
                {
                    
                    if (login == line)
                    {
                        Console.WriteLine($"Логин занят");
                        Console.WriteLine();
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                return false;
            }
        }
        private bool CheckLogin(string login)
        {
            int number = 0;
            foreach (var pair in login)
            {
                if (pair != ' ')
                {
                    number++;
                }
            }
            if (number < 4)
            {
                Console.WriteLine($"Логин не валиден");
                Console.WriteLine();
                return false;
            }
            else
            {
                Console.WriteLine($"Логин валиден");
                Console.WriteLine();
                return true;
            }
        }
        private void SetPassword()
        {
            string password;
            while (true)
            {
                Console.WriteLine($"В пароле должно быть минимум 8 символов");
                Console.WriteLine();
                Console.WriteLine($"Введите пароль");                
                password = Console.ReadLine();
                    bool check2 = CheckPassword(password);
                    if (check2 == true) { break; }
            }
            using (StreamWriter writer = new StreamWriter(_way, true)) { writer.WriteLine(password); }
        }     
        private bool CheckPassword(string password)
        {
            int number = 0;
            foreach (var pair in password)
            {
                if (pair != ' ')
                {
                    number++;
                }
            }
            if (number < 8)
            {
                Console.WriteLine($"Пароль не валиден");
                Console.WriteLine();
                return false;
            }
            else
            {
                Console.WriteLine($"Пароль валиден");
                return true;
            }
        }
        public void UserRegistration()
        {
            SetLogin();
            SetPassword();
        }
    }
}
