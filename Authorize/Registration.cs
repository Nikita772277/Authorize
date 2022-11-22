using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Authorize
{
    internal class Registration
    {
        private string _way = @"C:\Users\Студент 3\Desktop\Users.txt";
        public void SetWay()
        {
            Console.WriteLine($"Введите имя пользователя windows");
            string path = Console.ReadLine();
            _way = $@"C:\Users\{path}\Desktop\Users.txt";
        }
        private string SetLogin()
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
                writer.Write ($"Логин - {login} ");
            }
            return login;
        }
        private bool LoginIsBusy(string login)
        {
            using (StreamReader reader = new(_way))
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
            }
            return false;
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
        private string SetPassword()
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
            using (StreamWriter writer = new StreamWriter(_way, true)) { writer.Write($"Пароль - {password} "); }
            return password;
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
        private string Setnumber()
        {
            while (true)
            {
                Console.WriteLine($"Введите ваш номер телефона");
                string number = Console.ReadLine();
                bool check = CheckNumber(number);
                if (check == true)
                {
                    return number;
                    break;
                }
                else
                {
                    Console.WriteLine($"Вы ввели не подходяший условиям номер");
                    Console.WriteLine();
                }
            }
            return "";
        }
        private bool CheckNumber(string number)
        {
            Regex regex = new(@"^+7\d{10}$");
            Regex regex2 = new(@"^8 [0-9]{3} [0-9]{3} [0-9]{2} [0-9]{2}$");
            var a= regex.IsMatch(number);
            var b= regex2.IsMatch(number);
            if(a== true || b == true)
            {
                Console.WriteLine($"Номер подходит");
                return true;
            }
            else { Console.WriteLine($"Не подходит"); return false; }            
            return false;
        }
        public void UserRegistration()
        {
            FileInfo fileInfo = new FileInfo(_way);
            if (!fileInfo.Exists)
            {
                using (File.Create(_way)) ;
            }
            string login= SetLogin();
            string password= SetPassword();
            Setnumber();
            Console.WriteLine();
            Console.WriteLine($"Вы успешно зарегистрировались");
            Console.WriteLine();
            Authorization._authorization.Add(login, password);
        }
    }
}
